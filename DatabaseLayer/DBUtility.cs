using System;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace MIS
{
    public static class DBUtility
    {
        /// <summary>
        /// Returns the value of a column from a datareader given the column name. If the underlying type of the column is nullable
        /// and the data is NULL it returns the default value of the data type.
        /// </summary>
        /// <typeparam name="T">The column's data type </typeparam>
        /// <param name="dr">The datareader instance</param>
        /// <param name="column">The column name</param>
        /// <returns>A value of the data type T</returns>
        public static T SafeGet<T>(SqlDataReader dr, String column)
        {
            try
            {
                Type t = typeof(T);

                t = Nullable.GetUnderlyingType(t) ?? t;

                int ord = dr.GetOrdinal(column);

                if (DBNull.Value.Equals(dr.GetValue(ord)))
                    return default(T);

                object o = dr.GetValue(ord);

                if (TypeCode.Boolean == Type.GetTypeCode(t))
                {
                    int i = Convert.ToInt32(dr.GetValue(ord));
                    o = (i == 0 ? false : true);
                }

                return (T)Convert.ChangeType(o, t);
            }
            catch
            {

                return default(T);
            }

        }

        public static T SafeGet<T>(SqlDataReader dr, int ordinal)
        {
            try
            {
                Type t = typeof(T);

                t = Nullable.GetUnderlyingType(t) ?? t;

                if (DBNull.Value.Equals(dr.GetValue(ordinal)))
                    return default(T);

                object o = dr.GetValue(ordinal);

                if (TypeCode.Boolean == Type.GetTypeCode(t))
                {
                    int i = Convert.ToInt32(dr.GetValue(ordinal));
                    o = (i == 0 ? false : true);
                }

                return (T)Convert.ChangeType(o, t);
            }
            catch
            {

                return default(T);
            }

        }


        /// <summary>
        /// Returns the value of a column from a datatablereader given the column name. If the underlying type of the column is nullable
        /// and the data is NULL it returns the default value of the data type.
        /// </summary>
        /// <typeparam name="T">The column's data type </typeparam>
        /// <param name="dr">The datatablereader instance</param>
        /// <param name="column">The column name</param>
        /// <returns>A value of the data type T</returns>
        public static T SafeGet<T>(DataTableReader dr, String column)
        {
            try
            {
                Type t = typeof(T);
                t = Nullable.GetUnderlyingType(t) ?? t;
                int ord = dr.GetOrdinal(column);

                if (DBNull.Value.Equals(dr.GetValue(ord)))
                    return default(T);

                object o = dr.GetValue(ord);

                if (TypeCode.Boolean == Type.GetTypeCode(t))
                {
                    int i = Convert.ToInt32(dr.GetValue(ord));
                    o = (i == 0 ? false : true);
                }

                return (T)Convert.ChangeType(o, t);

            }
            catch
            {
                return default(T);
            }

        }



        public static string FriendlyDuration(DateTime start, DateTime end)
        {
            string timing = string.Format("{0} - {1}", start.ToShortDateString(), end.ToShortDateString());

            if (start.ToShortDateString() == end.ToShortDateString())
            {
                timing = start.ToShortDateString();
            }
            else if (start.Month == end.Month && start.Year == end.Year)
            {
                timing = string.Format("{0} - {1}", start.Day, end.ToShortDateString());
            }
            else if (start.Month != end.Month && start.Year == end.Year)
            {
                timing = string.Format("{0} - {1}", start.ToString("dd/MM"), end.ToString("dd/MM/yyyy"));
            }

            return timing;
        }
    }
}
