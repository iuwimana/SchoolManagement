using System;
using System.Text;
using System.Xml;
using System.IO;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace WebApp
{
    public class DBAccess
    {

        public static IDbInterface MISDB
        {
            get
            {
                IDbInterface db = (IDbInterface)StaticStorage.Get(typeof(DBAccess), "MISDB");

                //If the database connection had not been initialized, initialize it now
                //using the default connection type
                if (db == null)
                {
                    InitDB(new KeepConnectionOpen());

                    db = (IDbInterface)StaticStorage.Get(typeof(DBAccess), "MISDB");
                }

                return db;
            }

            private set
            {
                StaticStorage.Set(typeof(DBAccess), "MISDB", value);
            }
        }

        private static void ParseConfigFile(string dir,
                                     string configFileName,
                                     string dbNameOverride,
                                     out string username,
                                     out string password,
                                     out string server,
                                     out string database)
        {
            try
            {
                password = null;
                server = null;
                database = null;
                username = null;

                //Get the connection string
                var doc = new XmlDocument();

                string configFile = String.Format("{0}\\{1}", dir, configFileName);

                if (!File.Exists(configFile))
                {
                    throw new FileNotFoundException("Database configuration file cannot be found: " + configFile);
                }

                doc.Load(configFile);

                var dbsettings = doc.GetElementsByTagName("Setting");


                string passwordEncrypted = null;

                foreach (var dbsetting in dbsettings)
                {
                    var setting = (XmlElement)dbsetting;

                    if (setting.GetAttribute("name") == "database")
                        database = setting.GetAttribute("value");

                    if (setting.GetAttribute("name") == "server")
                        server = setting.GetAttribute("value");

                    if (setting.GetAttribute("name") == "user")
                        username = setting.GetAttribute("value");

                    if (setting.GetAttribute("name") == "password")
                        passwordEncrypted = setting.GetAttribute("value");
                }

                if (passwordEncrypted != null)
                {
                    password = CryptoUtil.Decrypt(passwordEncrypted);
                }

                if (dbNameOverride != null)
                {
                    database = dbNameOverride;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void ParseConnectionString(string connectionString, out string username, out string password, out string server, out string database)
        {
            try
            {
                password = null;
                server = null;
                database = null;
                username = null;

                string passwordEncrypted = null;

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);

                server = builder.DataSource;
                database = builder.InitialCatalog;
                username = builder.UserID;
                passwordEncrypted = builder.Password;

                if (!String.IsNullOrEmpty(passwordEncrypted))
                {
                    password = CryptoUtil.Decrypt(passwordEncrypted);
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void ParseConnectionString(string connectionString, out string server, out string database, bool integratedSecurity)
        {
            try
            {
                server = null;
                database = null;
                integratedSecurity = true;

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);

                server = builder.DataSource;
                database = builder.InitialCatalog;
                integratedSecurity = builder.IntegratedSecurity;

            }
            catch (Exception)
            {
                throw;
            }
        }

        private static DatabaseConfiguration GetDatabaseConfigurationFromString(string connectionString)
        {
            string username;
            string password;
            string server;
            string dbName;

            ParseConnectionString(connectionString, out username, out password, out server, out dbName);

            var dbConfig = new DatabaseConfiguration
            {
                Database = dbName,
                Server = server,
                Username = username,
                Password = password, // already decrypted due to side effect of "parsing"
            };


            return dbConfig;
        }

        private static DatabaseConfiguration GetDatabaseConfigurationFromString(string connectionString, bool integrated)
        {
            string server;
            string dbName;

            ParseConnectionString(connectionString, out server, out dbName, integrated);

            var dbConfig = new DatabaseConfiguration
            {
                Database = dbName,
                Server = server,
                TrustedConnection = true,
            };


            return dbConfig;
        }


        private static DatabaseConfiguration GetDatabaseConfigurationFromCustomConfigFile(string dir, string configFile, string dbNameOverride)
        {
            string username;
            string password;
            string server;
            string dbName;

            ParseConfigFile(dir, configFile, dbNameOverride, out username, out password, out server, out dbName);
            var dbConfig = new DatabaseConfiguration
            {
                Database = dbName,
                Server = server,
                Username = username,
                Password = password, // already decrypted due to side effect of "parsing"
            };

            if (dbNameOverride != null)
            {
                dbConfig.Database = dbNameOverride;
            }

            return dbConfig;
        }


        public static DatabaseConfiguration InitDB(IDbInterface dbInterface)
        {
            try
            {
                MISDB = dbInterface;

                string dir = Path.GetDirectoryName(dbInterface.GetType().Assembly.Location);

                var dbConfig = GetDatabaseConfigurationFromCustomConfigFile(dir, "databaseconfig.xml", null);

                dbInterface.Init(dbConfig);
                return dbConfig;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static DatabaseConfiguration InitDB(IDbInterface dbInterface, string connectionString)
        {
            try
            {
                MISDB = dbInterface;

                var dbConfig = GetDatabaseConfigurationFromString(connectionString);

                dbInterface.Init(dbConfig);
                return dbConfig;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public static DatabaseConfiguration InitDB(IDbInterface dbInterface, string connectionString, bool integrated)
        {
            try
            {
                MISDB = dbInterface;

                var dbConfig = GetDatabaseConfigurationFromString(connectionString, integrated);

                dbInterface.Init(dbConfig);
                return dbConfig;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    public static class CryptoUtil
    {

        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("??Secure");

        public static string Decrypt(string cryptedString)
        {
            if (String.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException(paramName: "The string which needs to be decrypted can not be null.");
            }
            var cryptoProvider = new DESCryptoServiceProvider();
            var memoryStream = new MemoryStream(Convert.FromBase64String(cryptedString));

            var cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);

            var reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();
        }

        public static string Encrypt(string originalString)
        {
            if (String.IsNullOrEmpty(originalString))
            {
                throw new ArgumentNullException("The string which needs to be encrypted can not be null.");
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();

            MemoryStream memoryStream = new MemoryStream();

            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(cryptoStream);

            writer.Write(originalString);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();

            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }

    }
}
