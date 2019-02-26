using System;

namespace hannon.TwoFactorAuth
{
    /// <summary>
    /// Provide methods missing in .net 3.5 compared to 4.0
    /// </summary>
    public static class Extension40
    {
        /// <summary>
        /// Replacement for method in 4.0
        /// </summary>
        /// <param name="value">string need to be checked</param>
        /// <returns>true if empty or null or space, else false</returns>
        public static bool IsNullOrWhiteSpace(string value)
        {
            return string.IsNullOrEmpty(value.Trim());
        }

        /// <summary>
        /// Replacement for method in 4.0
        /// </summary>
        /// <param name="value">value to be checked</param>
        /// <param name="result">out parameter to be set</param>
        /// <returns>true if valid guid, else false</returns>
        public static bool TryParseGuid(string value, out Guid result)
        {
            bool flag;
            try
            {
                result = new Guid(value);
                return true;
            }
            catch (Exception)
            {
                result = Guid.Empty;
                flag = false;
            }
            return flag;
        }
    }
}