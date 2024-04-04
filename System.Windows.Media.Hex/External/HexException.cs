#define NETFRAMEWORK

using System;

namespace System.Windows.Media.Hex
{
    /// <summary>
    /// Represents an exception that is thrown when an invalid hexadecimal color format is encountered.
    /// </summary>
    public class InvalidHexColorFormatException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidHexColorFormatException"/> class without a specific error message.
        /// </summary>
        public InvalidHexColorFormatException() : base($"{InvalidFormatMessage} {FormatCommentMessage}")
        {
            HResult = HexColorInvalidFormatHResult;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidHexColorFormatException"/> class with a specific error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public InvalidHexColorFormatException(string message) : base($"{InvalidFormatMessage} {message}")
        {
            HResult = HexColorInvalidFormatHResult;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidHexColorFormatException"/> class with a specific error message
        /// and a reference to the inner exception that caused this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a <see langword="null"/> reference if no inner exception is specified.</param>
        public InvalidHexColorFormatException(string message, Exception innerException) : base(message, innerException)
        {
            HResult = HexColorInvalidFormatHResult;
        }

        private static readonly string InvalidFormatMessage = "Invalid hex color format.";
        private static readonly string FormatCommentMessage = "It should be 6 or 8-digit hexadecimal number or its 3-digit shortened form.";
        private const int HexColorInvalidFormatHResult = -2147024808;
    }

    /// <summary>
    /// Exception thrown when a hexadecimal color code is found to be null or empty.
    /// </summary>
    public class NullOrEmptyHexColorException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullOrEmptyHexColorException"/> class.
        /// </summary>
        public NullOrEmptyHexColorException() : base($"{NullOrEmptyMessage}")
        {
            HResult = HexColorNullOrEmptyHResult;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NullOrEmptyHexColorException"/> class with the specified parameter name.
        /// </summary>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        public NullOrEmptyHexColorException(string paramName) : base($"{NullOrEmptyMessage}", paramName)
        {
            HResult = HexColorNullOrEmptyHResult;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NullOrEmptyHexColorException"/> class with the specified message and parameter name.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="paramName">The name of the parameter that caused the exception.</param>
        public NullOrEmptyHexColorException(string message, string paramName) : base($"{NullOrEmptyMessage} {message}", paramName)
        {
            HResult = HexColorNullOrEmptyHResult;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NullOrEmptyHexColorException"/> class with a specified error message and a reference to the inner exception that caused this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a <see langword="null"/> reference if no inner exception is specified.</param>
        public NullOrEmptyHexColorException(string message, Exception innerException) : base(message, innerException)
        {
            HResult = HexColorNullOrEmptyHResult;
        }

        private static readonly string NullOrEmptyMessage = "Hex color code cannot be null or empty.";
        private const int HexColorNullOrEmptyHResult = -2147024809;
    }
}
