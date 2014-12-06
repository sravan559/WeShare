using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeShare.BusinessModel
{
    /// <summary>
    /// Helper Class to perform data type convertions with null value validation
    /// </summary>
    public static class Extensions
    {
        public static string ToStr(this object value)
        {
            if (value == DBNull.Value || value == null)
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
            if (value == DBNull.Value || value == null)
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



        public static decimal ToDecimal(this object value)
        {
            if (value == DBNull.Value || value == null)
                return 0;
            else
                return (Convert.ToDecimal(value));
        }

        public static decimal ToDecimal(this string value)
        {
            decimal result = 0;
            if (value != null)
                decimal.TryParse(value, out result);
            return result;
        }

        public static DateTime ToDateTime(this object value)
        {
            if (value == DBNull.Value || value == null)
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

        public static bool ToBoolean(this object value)
        {
            if (value == DBNull.Value || value == null)
                return false;
            else if (value.ToString().ToLower() == "true" || value.ToString().ToLower() == "yes" || value.ToInt32() == 1)
                return true;
            else
                return false;
        }

        public static bool ToBoolean(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;
            else if (value == "1" || value.ToLower() == "true" || value.ToLower() == "yes")
                return true;
            else
                return false;
        }
    }
}
