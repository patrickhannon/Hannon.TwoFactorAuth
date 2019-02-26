using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hannon.TwoFactorAuth
{
    public static class Extensions
    {
        public static DateTime ToDate(this string dateTimeStr, string[] dateFmt)
        {
            // example: var dt="2011-03-21 13:26".toDate("yyMM-dd-yy HH:mm");
            const DateTimeStyles style = DateTimeStyles.AllowWhiteSpaces;
            DateTime result = DateTime.Now;
            DateTime dt;
            if (DateTime.TryParseExact(dateTimeStr, dateFmt,
                CultureInfo.InvariantCulture, style, out dt)) result = dt;
            return result;
        }
        public static DateTime ToDate(this string dateTimeStr, string dateFmt)
        {
            // call overloaded function with string array param     
            return ToDate(dateTimeStr, new string[] { dateFmt });
        }
        public static string GetLast(this string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;
            return source.Substring(source.Length - tail_length);
        }
        /// <summary>
        /// Checks to see if there is a digit in the string, returns true if one is found
        /// </summary>
        /// <param name="value">string to compare</param>
        /// <returns>true/false</returns>
        public static bool NoNumerical(this string value)
        {
            bool noNumerical = true;
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
            {
                return true;
            }
            foreach (char c in value)
            {
                if (char.IsDigit(c))
                {
                    noNumerical = false;
                    break;
                }
            }
            return noNumerical;
        }

        public static bool Contains(this String str, String substring,
                               StringComparison comp)
        {
            if (substring == null)
                throw new ArgumentNullException("substring",
                                                "substring cannot be null.");
            else if (!Enum.IsDefined(typeof(StringComparison), comp))
                throw new ArgumentException("comp is not a member of StringComparison",
                                            "comp");

            return str.IndexOf(substring, comp) >= 0;
        }

        public static Guid ToGuid(this string aString)
        {
            Guid newGuid;

            if (string.IsNullOrWhiteSpace(aString))
            {
                return Guid.Empty;
            }

            if (Guid.TryParse(aString, out newGuid))
            {
                return newGuid;
            }
            return Guid.Empty;
        }
    }
}
