using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace MIS
{
    /// <summary>
    /// Database interface that opens connections when needed and closes them
    /// immediately after use.  This method is preferred over the KeepConnectionOpen
    /// when there will many simultaneous database users connected at once.
    /// </summary>
    public class OpenConnectionAsNeeded : IDbInterface, IDisposable
    {

        private string connectionString;

        public void Dispose()
        {
            if (connectionString != null)
            {
                connectionString = null;
            }
        }


        public void Init(DatabaseConfiguration config)
        {

            connectionString = config.ToConnectionString();
        }



        /// <summary>
        /// Run a parameter less stored procedure
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <returns>A data reader</returns>
        public SqlDataReader ExecuteReader(string storedProcedure)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = storedProcedure;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 500;

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;
            }
            catch
            {
                if (connection != null)
                    connection.Close();
                throw;
            }
        }

        public SqlDataReader ExecuteReader<T>(string storedProcedure, string parameterName, T parameterValue)
        {

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                //connection.Open();

                cmd.CommandText = storedProcedure;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 500;
                cmd.Parameters.AddWithValue("@" + parameterName, parameterValue);

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;
            }
            catch
            {
                if (connection != null)
                    connection.Close();
                throw;
            }

        }

        public void ExecuteNonQuery<T>(string storedProcedure, string parameterName, T parameterValue)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = storedProcedure;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 500;
                cmd.Parameters.AddWithValue("@" + parameterName, parameterValue);

                cmd.ExecuteNonQuery();
            }
        }

        public SqlDataReader ExecuteReader(string storedProcedure, Dictionary<string, object> parameters)
        {

            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = storedProcedure;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 500;
                foreach (KeyValuePair<string, object> param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value == null ? DBNull.Value : param.Value);
                }

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;
            }
            catch
            {
                if (connection != null)
                    connection.Close();
                throw;
            }

        }

        public void ExecuteNonQuery(string storedProcedure, Dictionary<string, object> parameters)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
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

        }

        public void ExecuteNonQuery(string storedProcedure)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = storedProcedure;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 500;

                cmd.ExecuteNonQuery();
            }

        }

        public object ExecuteScalar(string storedProcedure)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = storedProcedure;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 500;

                return cmd.ExecuteScalar();
            }

        }

        public object ExecuteScalar(string storedProcedure, Dictionary<string, object> parameters)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
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

        }

        public object ExecuteScalar<T>(string storedProcedure, string parameterName, T parameterValue)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand cmd = connection.CreateCommand();

                cmd.CommandText = storedProcedure;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 500;
                cmd.Parameters.AddWithValue("@" + parameterName, parameterValue);

                return cmd.ExecuteScalar();
            }

        }

        public T ExecuteScalar<T, T1>(string storedProcedure, string parameterName, T1 parameterValue)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
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
        }


        //private void conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        //{


        //}

        public DataTable ExecuteDataTable(string storedProcedureName, Dictionary<string, object> parameters)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
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
        }

        public DataTable ExecuteDataTable(string storedProcedureName)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
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
        }
        public List<string> ExecuteSql(string sql)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {

                    cmd.CommandText = sql;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 500;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

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
                }
            }
        }

        public List<Dictionary<string, object>> ExecuteSqlVector(string sql)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {

                    cmd.CommandText = sql;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandTimeout = 500;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

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
        }

        public List<Dictionary<string, object>> ExecuteStoredProcedureVector(string storedProcedure, Dictionary<string, object> parameters)
        {

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {

                    cmd.CommandText = storedProcedure;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 500;

                    foreach (KeyValuePair<string, object> param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value == null ? DBNull.Value : param.Value);
                    }

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

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
        }



    }
}

