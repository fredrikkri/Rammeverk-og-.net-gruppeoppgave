using System;
namespace brusOgPotetgull.airportLiberary.CustomExceptions
{
    /// <summary>
    /// Initializes an exception that is used when a negative number appears.
    /// </summary>
    public class NegativeNumberException : ArgumentOutOfRangeException
    {
        /// <summary>
        /// Creates an NegativeNumberException
        /// </summary>
        public NegativeNumberException()
            : base()
        {

        }
        /// <summary>
        /// Creates an NegativeNumberException with a specified error message.
        /// </summary>
        /// <param name="message">This error message is explaining the reason for the exception.</param>
        public NegativeNumberException(string message)
            : base(message)
        {

        }
        /// <summary>
        /// Creates an NegativeNumberException with a specified error message.
        /// It has also a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">This error message is explaining the reason for the exception.</param>
        /// <param name="inner">The exception that is the reason for the current exception.</param>
        public NegativeNumberException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
