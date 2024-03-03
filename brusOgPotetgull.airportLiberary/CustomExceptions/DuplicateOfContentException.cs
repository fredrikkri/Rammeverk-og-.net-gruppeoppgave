using System;
namespace brusOgPotetgull.airportLiberary.CustomExceptions
{
    /// <summary>
    /// Initializes an exception that is used when dulpication of content happens.
    /// </summary>
	public class DuplicateOfContentException : Exception
	{
        /// <summary>
        /// Creates an DuplicateOfCotentException.
        /// </summary>
		public DuplicateOfContentException()
			: base()
		{

		}
        /// <summary>
        /// Creates an DuplicateOfCotentException with a specified error message.
        /// </summary>
        /// <param name="message">This error message is explaining the reason for the exception.</param>
        public DuplicateOfContentException(string message)
            : base(message)
        {

        }
        /// <summary>
        /// Creates an DuplicateOfCotentException with a specified error message.
        /// It has also a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">This error message is explaining the reason for the exception.</param>
        /// <param name="inner">The exception that is the reason for the current exception.</param>
        public DuplicateOfContentException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}

