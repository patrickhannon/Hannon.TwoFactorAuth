using System;
using System.Runtime.CompilerServices;

namespace hannon.TwoFactorAuth
{
        /// <summary>
        /// thrown when the service being called has internally encountered an problem. Provides a
        /// property that when checked determines if the caller can or should retry the operation
        /// that caused this exception
        /// </summary>
        public class ProcessingException : Exception
        {
            /// <summary>
            /// if true then the caller can retry the operation if they so choose. If false the caller
            /// should not try to call the same operation again.
            /// </summary>
            public bool CanRetry
            {
                get;
                private set;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="T:Core.ProcessingException" /> class with a specified
            ///    error message.
            /// </summary>
            /// <param name="canRetry">set to <c>true</c> if the user handling this exception can retry the operation that is throwing this exception</param>
            /// <param name="message">The message that describes the error.</param>
            public ProcessingException(bool canRetry, string message)
                : base(message)
            {
                this.CanRetry = canRetry;
            }

            /// <summary>
            /// Initializes a new instance of <see cref="T:Core.ProcessingException" /> class with a specified
            ///    error message and a reference to the inner exception that is the cause of
            ///    this exception.
            /// </summary>
            /// <param name="canRetry">set to <c>true</c> if the user handling this exception can retry the operation that is throwing this exception</param>
            /// <param name="message">The error message that explains the reason for the exception.</param>
            /// <param name="innerException">The exception that is the cause of the current exception, or a null reference
            ///    (Nothing in Visual Basic) if no inner exception is specified.</param>
            public ProcessingException(bool canRetry, string message, Exception innerException)
                : base(message, innerException)
            {
                this.CanRetry = canRetry;
            }
        }
    }
