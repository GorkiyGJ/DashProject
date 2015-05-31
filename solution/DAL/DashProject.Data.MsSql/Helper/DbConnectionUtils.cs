using System;
using Manitou.Data.Provider;

namespace Manitou.Data.MsSql.Helper
{
    public static class DbConnectionUtils
    {
        public static SessionManager GetConnection(string connectionString, SessionManager sm)
        {
            if (sm == null)
                sm = new SessionManager(connectionString);

            return sm;
        }

        public static void Open(SessionManager sm)
        {
            if (!sm.IsTransactionOpen)
                sm.Open();
        }
    }
}
