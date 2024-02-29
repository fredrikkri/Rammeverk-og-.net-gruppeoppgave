using System;
namespace brusOgPotetgull.airportLiberary.CustomExceptions
{
	public class DuplicateOfContentException : Exception
	{
		public DuplicateOfContentException()
			: base()
		{

		}
        public DuplicateOfContentException(string message)
            : base(message)
        {

        }
        public DuplicateOfContentException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}

