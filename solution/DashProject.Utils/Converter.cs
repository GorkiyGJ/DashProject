using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DashProject.Utils
{
    public class Converter
    {
        public static int ToInt32(object value)
        {
            return ToInt32(value, false);
        }

        public static int ToInt32(object value, int defaultValue)
        {
            return ToInt32Nullable(value) ?? defaultValue;
        }

        public static int ToInt32(object value, bool isZero)
        {
            if (value == null)
                return isZero ? 0 : -1;

            int dt;
            if (int.TryParse(value.ToString(), out dt))
                return dt;
            else
            {
                try
                {
                    return System.Convert.ToInt32(value);
                }
                catch
                {
                    return isZero ? 0 : -1;
                }
            }
        }

        public static int? ToInt32Nullable(object value)
        {
            if (value == null)
                return null;

            int dt;
            if (int.TryParse(value.ToString(), out dt))
                return dt;
            else
            {
                try
                {
                    return System.Convert.ToInt32(value);
                }
                catch
                {
                    return null;
                }
            }
        }
        public static float ToFloat32(object value, bool isZero)
        {
            if (value == null)
                return isZero ? 0 : -1;

            float dt;
            if (float.TryParse(value.ToString(), out dt))
                return dt;
            else
                return isZero ? 0 : -1;
        }

        public static float? ToFloatNullable(object value)
        {
            if (value == null)
                return null;

            float dt;
            if (float.TryParse(value.ToString(), out dt))
                return dt;
            else
                return null;
        }
    }
}
