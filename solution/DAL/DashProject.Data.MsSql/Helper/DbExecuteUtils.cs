using System;
using System.Data;
using System.Data.SqlClient;

namespace Manitou.Data.MsSql.Helper
{
    public static class DbExecuteUtils
    {
        public static IDataReader ExecuteReader(SqlCommand sc)
        {
            if (sc.Transaction != null && sc.Transaction.Connection != null && sc.Transaction.Connection.State != ConnectionState.Closed)
                return ExecuteReader(sc, CommandBehavior.Default);
            else
                return ExecuteReader(sc, CommandBehavior.CloseConnection);
        }

        internal static IDataReader ExecuteSingleRowReader(SqlCommand sc)
        {
            return ExecuteReader(sc, CommandBehavior.SingleRow);
        }

        internal static IDataReader ExecuteSingleResultReader(SqlCommand sc)
        {
            return ExecuteReader(sc, CommandBehavior.SingleResult);
        }

        internal static IDataReader ExecuteReader(SqlCommand sc, CommandBehavior cb)
        {
            return sc.ExecuteReader(cb);
        }

        internal static int ExecuteNonQuery(SqlCommand sc)
        {
            return sc.ExecuteNonQuery();
        }

        public static DataTable GetDataTable(SqlCommand sc)
        {
            return GetDataTable(sc, new DataTable());
        }

        public static DataTable GetDataTable(SqlCommand sc, DataTable dt)
        {
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            sda.Fill(dt);

            return dt;
        }

        public static DataSet GetDataSet(SqlCommand sc)
        {
            return GetDataSet(sc, new DataSet());
        }

        public static DataSet GetDataSet(SqlCommand sc, DataSet ds)
        {
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            sda.Fill(ds);

            return ds;
        }
    }
}