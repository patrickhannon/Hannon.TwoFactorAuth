using System;
using System.Collections;

namespace hannon.TwoFactorAuth
{
    /// <summary>
    /// Contains methods to help verify arguments to methods.
    /// </summary>
    public static class ArgumentValidator
    {
        /// <summary>
        /// Thrown when the passed <paramref name="condition" /> is <c>true</c>.
        /// </summary>
        /// <param name="condition">Value indicating if an expection should be thrown.</param>
        /// <param name="reason">The reason to give when <paramref name="condition" /> is <c>true</c>.</param>
        /// <exception cref="T:System.InvalidOperationException">
        /// thrown when [reason].
        /// </exception>
        public static void ThrowOnCondition(bool condition, string reason)
        {
            if (condition)
            {
                throw new InvalidOperationException(reason);
            }
        }

        /// <summary>
        /// Thrown when the passed <paramref name="value" /> is <c>null</c>.
        /// </summary>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// thrown when [paramValue] is <c>null</c>.
        /// </exception>
        public static void ThrowOnNull(string paramName, object value)
        {
            if (object.ReferenceEquals(value, null))
            {
                throw new ArgumentNullException(paramName, ExceptionMessage.NonNullReferenceMessage(paramName));
            }
        }

        /// <summary>
        /// Thrown when the passed <paramref name="value" /> or one of its elements are <c>null</c>.
        /// </summary>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// thrown when [paramValue] is <c>null</c> one of its elements are <c>null</c>.
        /// </exception>
        public static void ThrowOnNullElement(string paramName, IEnumerable value)
        {
            ArgumentValidator.ThrowOnNull(paramName, value);
            foreach (object item in value)
            {
                ArgumentValidator.ThrowOnNull(string.Concat(paramName, ".Element"), item);
            }
        }

        /// <summary>
        /// Thrown when the passed <paramref name="value" /> is <c>null</c>, empty or only whitespace.
        /// </summary>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// thrown when [paramValue] is <c>null</c>.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// Thrown when [paramValue] is empty or only whitespace.
        /// </exception>
        public static void ThrowOnNullEmptyOrWhitespace(string paramName, string value)
        {
            ArgumentValidator.ThrowOnNull(paramName, value);
            if (Extension40.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessage.NonNullEmptyOrWhitespaceMessage(paramName));
            }
        }

        /// <summary>
        /// Thrown when the passed <paramref name="value" /> is <c>null</c> or empty.
        /// </summary>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// thrown when [paramValue] is <c>null</c>.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// thrown when [paramValue] is empty.
        /// </exception>
        public static void ThrowOnNullOrEmpty(string paramName, string value)
        {
            ArgumentValidator.ThrowOnNull(paramName, value);
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(ExceptionMessage.NonNullOrEmptyStringMessage(paramName));
            }
        }

        /// <summary>
        /// Thrown when the passed <paramref name="value" /> is out of range.
        /// </summary>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="value">The value.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// thrown when [paramValue] is less than [min] or greater than [max].
        /// </exception>
        public static void ThrowOnOutOfRange(string paramName, int value, int min, int max)
        {
            if (value < min || value > max)
            {
                throw new ArgumentOutOfRangeException(paramName);
            }
        }

        /// <summary>
        /// Thrown when the passed <paramref name="value" /> is out of range.
        /// </summary>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="value">The value.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// thrown when [paramValue] is less than [min] or greater than [max].
        /// </exception>
        public static void ThrowOnOutOfRange(string paramName, double value, double min, double max)
        {
            if (value < min || value > max)
            {
                throw new ArgumentOutOfRangeException(paramName);
            }
        }

        /// <summary>
        /// Thrown when the passed <paramref name="value" /> is out of range.
        /// </summary>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="value">The value.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// thrown when [paramValue] is less than [min] or greater than [max].
        /// </exception>
        public static void ThrowOnOutOfRange(string paramName, Decimal value, Decimal min, Decimal max)
        {
            if (value < min || value > max)
            {
                throw new ArgumentOutOfRangeException(paramName);
            }
        }

        /// <summary>
        /// Thrown when the passed <paramref name="value" /> length is out of range.
        /// </summary>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="value">The value.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// thrown when [paramValue] is <c>null</c>.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// thrown when [paramValue] is greater than [maxLength].
        /// </exception>
        public static void ThrowOnOutOfRange(string paramName, string value, int maxLength)
        {
            ArgumentValidator.ThrowOnNull(paramName, value);
            if (value.Length > maxLength)
            {
                throw new ArgumentOutOfRangeException(paramName);
            }
        }

        /// <summary>
        /// Thrown when the passed <paramref name="value" /> is out of range.
        /// </summary>
        /// <param name="paramName">Name of the param.</param>
        /// <param name="value">The value.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <param name="reason">The reason.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// thrown when [paramValue] is [reason].
        /// </exception>
        public static void ThrowOnOutOfRange(string paramName, int value, int min, int max, string reason)
        {
            if (value < min || value > max)
            {
                throw new ArgumentOutOfRangeException(paramName, reason);
            }
        }
    }
}