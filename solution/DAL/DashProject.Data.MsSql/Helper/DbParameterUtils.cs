using System;
using System.Data;
using System.Data.SqlClient;

namespace Manitou.Data.MsSql.Helper
{
    public static class DbParameterUtils
    {
        public static void AddOutParametr(SqlCommand sc, object value, string nameColumn, SqlDbType type)
        {
            AddParametr(sc, value, nameColumn, type, ParameterDirection.Output);
        }

        public static void AddParametr(SqlCommand sc, object value, string nameColumn, SqlDbType type)
        {
            AddParametr(sc, value, nameColumn, type, ParameterDirection.Input);
        }

        public static void AddParametr(SqlCommand sc, object value, string nameColumn, SqlDbType type, ParameterDirection typeDirection)
        {
            SqlParameter scp = new SqlParameter(SetNameSqlParam(nameColumn), type);
            scp.Value = AddCorrectValue(value);
            scp.Direction = typeDirection;

            sc.Parameters.Add(scp);
        }

        public static void AddOutParametr(SqlCommand sc, object value, string nameColumn, SqlDbType type, int maxSqlType)
        {
            AddParametr(sc, value, nameColumn, type, maxSqlType, ParameterDirection.Output);
        }

        public static void AddParametr(SqlCommand sc, object value, string nameColumn, SqlDbType type, int maxSqlType)
        {
            AddParametr(sc, value, nameColumn, type, maxSqlType, ParameterDirection.Input);
        }

        public static void AddParametr(SqlCommand sc, object value, string nameColumn, SqlDbType type, int maxSqlType, ParameterDirection typeDirection)
        {
            SqlParameter scp = new SqlParameter(SetNameSqlParam(nameColumn), type, maxSqlType);
            scp.Value = AddCorrectValue(value);
            scp.Direction = typeDirection;

            sc.Parameters.Add(scp);
        }

        #region Helper
        private static string SetNameSqlParam(string nameColumn)
        {
            if (nameColumn[0] != '@')
                return "@" + nameColumn;
            else
                return nameColumn;
        }

        public static object AddCorrectValue(object value)
        {
            if (value != DBNull.Value && value != null && value.ToString().Length > 0)
                return value;
            else
                return DBNull.Value;
        }

        public static object AddCorrectValueExt(object value)
        {
            if (value != DBNull.Value && value != null && value.ToString().Length > 0 && Manitou.Helper.Converter.ToString(value) != "-1")
                return value;
            else
                return DBNull.Value;
        }
        #endregion
    }
}