using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeShare.BusinessModel
{
    public static class Extensions
    {
        public static string ToStr(this object value)
        {
            if (value == DBNull.Value)
                return string.Empty;
            else
                return (Convert.ToString(value));
        }

        public static string ToStr(this string value)
        {
            if (value == null)
                return string.Empty;
            else
                return (Convert.ToString(value).Trim());
        }

        public static Int32 ToInt32(this object value)
        {
            if (value == DBNull.Value)
                return 0;
            else
                return (Convert.ToInt32(value));
        }

        public static Int32 ToInt32(this string value)
        {
            int result = 0;
            if (value != null)
                int.TryParse(value, out result);
            return result;
        }

        public static DateTime ToDateTime(this object value)
        {
            if (value == DBNull.Value)
                return DateTime.MinValue;
            else
                return Convert.ToDateTime(value);
        }

        public static DateTime ToDateTime(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return DateTime.MinValue;
            else
                return Convert.ToDateTime(value);
        }
    }
}
