using System;
using System.Data;
using System.Data.SqlClient;
using Manitou.Data.Provider;

namespace Manitou.Data.MsSql.Helper
{
    public static class DbCommandUtils
    {
        private static SqlCommand getCommand(SessionManager sm, CommandType type)
        {
            SqlCommand sc = new SqlCommand();

            sc.Connection = sm.ConnectionObject as SqlConnection;
            if (sm.IsTransactionOpen)
                sc.Transaction = sm.TransactionObject as SqlTransaction;               

            sc.CommandType = type;

            return sc;
        }

        public static SqlCommand GetCommand()
        {
            return getCommand(null, CommandType.StoredProcedure);
        }

        public static SqlCommand GetCommand(SessionManager sm)
        {
            return getCommand(sm, CommandType.StoredProcedure);
        }

        public static SqlCommand GetCommand(string storedProcedure)
        {
            return GetCommand(null, CommandType.StoredProcedure, storedProcedure);
        }

        public static SqlCommand GetCommand(SessionManager sm, string storedProcedure)
        {
            return GetCommand(sm, CommandType.StoredProcedure, storedProcedure);
        }

        public static SqlCommand GetCommand(SessionManager sm, CommandType type, string value)
        {
            SqlCommand sc = getCommand(sm, type);
            sc.CommandText = value;

            return sc;
        }
    }
}