using System.Collections.Generic;
using System.Data.SqlClient;

namespace MIS
{
    //public delegate void OnMessage(string message);


    /// <summary>
    /// Interface for database access.
    /// Abstract strategy for accessing a database.  Different concrete implementations
    /// can implement with different ways of accessing database.
    /// </summary>
    public interface IDbInterface
    {
        void Init(DatabaseConfiguration configuration);

        System.Data.DataTable ExecuteDataTable(string storedProcedureName, Dictionary<string, object> parameters);
        System.Data.DataTable ExecuteDataTable(string storedProcedureName);
        void ExecuteNonQuery(string storedProcedure);
        void ExecuteNonQuery(string storedProcedure, Dictionary<string, object> parameters);
        void ExecuteNonQuery<T>(string storedProcedure, string parameterName, T parameterValue);
        SqlDataReader ExecuteReader(string storedProcedure);
        SqlDataReader ExecuteReader(string storedProcedure, Dictionary<string, object> parameters);
        SqlDataReader ExecuteReader<T>(string storedProcedure, string parameterName, T parameterValue);
        object ExecuteScalar(string storedProcedure);
        object ExecuteScalar(string storedProcedure, Dictionary<string, object> parameters);
        object ExecuteScalar<T>(string storedProcedure, string parameterName, T parameterValue);
        T ExecuteScalar<T, T1>(string storedProcedure, string parameterName, T1 parameterValue);
        List<string> ExecuteSql(string sql);
        List<Dictionary<string, object>> ExecuteSqlVector(string sql);
        List<Dictionary<string, object>> ExecuteStoredProcedureVector(string storedProcedure, Dictionary<string, object> parameters);
        //event OnMessage MessageReceived;


    }
}
