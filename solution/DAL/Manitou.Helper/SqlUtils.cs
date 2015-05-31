using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Manitou.Helper
{
    public static class SqlUtils
    {
        public static string GetDateFormat(DateTime? value)
        {
            if (value == null)
                return "";

            return value.Value.ToString("yyyyMMdd");
        }

        public static string GetDateFormatHoursMinutes(DateTime? value)
        {
            if (value == null)
                return "";          
            
            return value.Value.ToString("yyyy.MM.dd HH:mm");
        }

        public static string GetDataSourceFormat(DateTime? value)
        {
            if (value == null)
                return "";

            return value.Value.ToString("dd.MM.yyyy");
        }

        public static T GetParameterValue<T>(object parameter)
        {
            if (parameter == System.DBNull.Value)
            {
                return default(T);
            }
            else
            {
                return (T)(parameter);
            }
        }
    }
}