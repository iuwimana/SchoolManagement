using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace WebApp
{
    /// <summary>
    /// Database interface strategy implementation that keeps a single
    /// global connection open all the time and uses it for all data access
    /// </summary>
    public sealed class KeepConnectionOpen : IDbInterface, IDisposable
    {
        private string connectionString;
        private SqlConnection connection;

        //public event OnMessage MessageReceived;

        public void Dispose()
        {
            if (connection != null)
            {
                connection.Dispose();
                connection = null;
            }
        }
        /// <summary>
        /// Initializes the data access component using the given database configuration
        /// </summary>
        /// <param name="config">The configuration information</param>
        public void Init(DatabaseConfiguration config)
        {
            try
            {
                connectionString = config.ToConnectionString();

                connection = new SqlConnection(connectionString);
                //connection.InfoMessage += new SqlInfoMessageEventHandler(ConnectionInfoMessage);

                connection.Open();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //void ConnectionInfoMessage(object sender, SqlInfoMessageEventArgs e)
        //{
        //    if (MessageReceived != null)
        //        MessageReceived(e.Message);
        //}

        /// <summary>
        /// Run a parameterless stored procedure
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <returns>A datareader</returns>
        public SqlDataReader ExecuteReader(string storedProcedure)
        {

            try
            {
                CheckConnection();

                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = storedProcedure;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 500;

                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void CheckConnection()
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();
        }

        /// <summary>
        /// Runs a stored procedure with a single parameter of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProcedure">Name of the stored procedure</param>
        /// <param name="parameterName">Name of the parameter</param>
        /// <param name="parameterValue">Value of the parameter</param>
        /// <returns>A datareader</returns>
        public SqlDataReader ExecuteReader<T>(string storedProcedure, string parameterName, T parameterValue)
        {

            try
            {
                CheckConnection();

                SqlCommand cmd = connection.CreateCommand();
                //connection.Open();

                cmd.CommandText = storedProcedure;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 500;
                cmd.Parameters.AddWithValue("@" + parameterName, parameterValue);

                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Runs a stored procedure with a single parameter of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProcedure">Name of the stored procedure</param>
        /// <param name="parameterName">Name of the parameter</param>
        /// <param name="parameterValue">Value of the parameter</param>
        public void ExecuteNonQuery<T>(string storedProcedure, string parameterName, T parameterValue)
        {
            try
            {
                CheckConnection();
                SqlCommand cmd = connection.CreateCommand();
                //cn.Open();

                cmd.CommandText = storedProcedure;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 500;
                cmd.Parameters.AddWithValue("@" + parameterName, parameterValue);

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public SqlDataReader ExecuteReader(string storedProcedure, Dictionary<string, object> parameters)
        {

            try
            {
                CheckConnection();

                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = storedProcedure;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 500;

                foreach (KeyValuePair<string, object> param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value == null ? DBNull.Value : param.Value);
                }

                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void ExecuteNonQuery(string storedProcedure, Dictionary<string, object> parameters)
        {

            try
            {
                CheckConnection();

                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = storedProcedure;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 500;

                foreach (KeyValuePair<string, object> param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value == null ? DBNull.Value : param.Value);
                }

                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ExecuteNonQuery(string storedProcedure)
        {

            try
            {
                CheckConnection();

                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = storedProcedure;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 500;

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public object ExecuteScalar(string storedProcedure)
        {

            CheckConnection();

            SqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = storedProcedure;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 500;

            return cmd.ExecuteScalar();

        }

        public object ExecuteScalar(string storedProcedure, Dictionary<string, object> parameters)
        {

            CheckConnection();

            SqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = storedProcedure;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 500;

            foreach (KeyValuePair<string, object> param in parameters)
            {
                cmd.Parameters.AddWithValue(param.Key, param.Value == null ? DBNull.Value : param.Value);
            }

            return cmd.ExecuteScalar();

        }

        public object ExecuteScalar<T>(string storedProcedure, string parameterName, T parameterValue)
        {

            CheckConnection();

            SqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = storedProcedure;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 500;
            cmd.Parameters.AddWithValue("@" + parameterName, parameterValue);

            return cmd.ExecuteScalar();

        }

        public T ExecuteScalar<T, T1>(string storedProcedure, string parameterName, T1 parameterValue)
        {
            CheckConnection();

            SqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = storedProcedure;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 500;
            cmd.Parameters.AddWithValue("@" + parameterName, parameterValue);

            object ret = cmd.ExecuteScalar();

            if (ret == null)
                return default(T);

            return (T)ret;
        }


        private string database = "MISDB";
        private string server = Environment.MachineName;

        public string Server
        {
            get { return server; }
        }

        public string Database
        {
            get { return database; }
        }



        //private void conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        //{
        //    if (MessageReceived != null)
        //        MessageReceived(e.Message);

        //}

        public DataTable ExecuteDataTable(string storedProcedureName, Dictionary<string, object> parameters)
        {

            CheckConnection();

            DataTable dt = new DataTable();

            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProcedureName;

                if (parameters != null)
                {
                    foreach (KeyValuePair<string, object> param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value == null ? DBNull.Value : param.Value);
                    }
                }

                //Fill the dataset 
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;

        }

        public DataTable ExecuteDataTable(string storedProcedureName)
        {

            CheckConnection();

            DataTable dt = new DataTable();

            using (SqlCommand cmd = connection.CreateCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = storedProcedureName;

                //Fill the dataset 
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;

        }


        public List<string> ExecuteSql(string sql)
        {

            CheckConnection();

            SqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandTimeout = 500;

            SqlDataReader dr = cmd.ExecuteReader();

            List<string> results = new List<string>();
            while (dr.Read())
            {
                string id = Convert.ToString(dr.GetValue(0));
                if (!results.Contains(id))
                {
                    results.Add(id);
                }
            }

            return results;

        }

        public List<Dictionary<string, object>> ExecuteSqlVector(string sql)
        {

            CheckConnection();

            SqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandTimeout = 500;

            SqlDataReader dr = cmd.ExecuteReader();

            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();
            while (dr.Read())
            {
                Dictionary<string, object> result = new Dictionary<string, object>();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    result.Add(dr.GetName(i), dr.GetValue(i));
                }

                results.Add(result);
            }

            return results;

        }

        public List<Dictionary<string, object>> ExecuteStoredProcedureVector(string storedProcedure, Dictionary<string, object> parameters)
        {

            CheckConnection();

            SqlCommand cmd = connection.CreateCommand();

            cmd.CommandText = storedProcedure;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 500;

            foreach (KeyValuePair<string, object> param in parameters)
            {
                cmd.Parameters.AddWithValue(param.Key, param.Value == null ? DBNull.Value : param.Value);
            }

            SqlDataReader dr = cmd.ExecuteReader();

            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();
            while (dr.Read())
            {
                Dictionary<string, object> result = new Dictionary<string, object>();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    result.Add(dr.GetName(i), dr.GetValue(i));
                }

                results.Add(result);
            }

            return results;

        }



    }

}

