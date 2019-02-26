using System;
using System.Reflection;

namespace hannon.TwoFactorAuth
{
    /// <summary>
    /// This class was built to provide consitent messages across exceptions.
    /// </summary>
    public static class ExceptionMessage
    {
        /// <summary>
        /// Builds the exception message for a null reference exception coming from a <see cref="T:System.ArgumentNullException" />.
        /// </summary>
        /// <param name="argumentName">Name of the argument that caused the exception.</param>
        /// <returns>Returns the complete exception message.</returns>
        public static string ArgumentNullExceptionMessage(string argumentName)
        {
            return string.Concat(ExceptionMessage.NonNullReferenceMessage(argumentName), "\r\nParameter name: ", argumentName);
        }

        /// <summary>
        /// Builds the exception message for a failed <see cref="T:System.IComparable" /> and <see cref="T:System.IComparable`1" /> when there is a type miss match.
        /// </summary>
        /// <param name="type">The object type which is expected.</param>
        /// <returns>Returns the exception message.</returns>
        public static string ComparableTypeMissMatchMessage(Type type)
        {
            return string.Concat("Object must be of type ", type.Name, ".");
        }

        /// <summary>
        /// Builds the exception message for a null, empty or whitespace exception message.
        /// </summary>
        /// <param name="argumentName">Name of the argument that caused the exception.</param>
        /// <returns>Returns the exception message.</returns>
        public static string NonNullEmptyOrWhitespaceMessage(string argumentName)
        {
            return string.Concat("string cannot be null, empty, or only whitespace.\r\nParameter name: ", argumentName);
        }

        /// <summary>
        /// Builds the exception message for a null reference exception.
        /// </summary>
        /// <param name="argumentName">Name of the argument that caused the exception.</param>
        /// <returns>Returns the exception message.</returns>
        public static string NonNullOrEmptyStringMessage(string argumentName)
        {
            return string.Concat("string cannot be null or empty string.\r\nParameter name: ", argumentName);
        }

        /// <summary>
        /// Builds the exception message for a null reference exception.
        /// </summary>
        /// <param name="argumentName">Name of the argument that caused the exception.</param>
        /// <returns>Returns the exception message.</returns>
        public static string NonNullReferenceMessage(string argumentName)
        {
            return string.Concat("Reference object \"", argumentName, "\" cannot be null.");
        }
    }
}