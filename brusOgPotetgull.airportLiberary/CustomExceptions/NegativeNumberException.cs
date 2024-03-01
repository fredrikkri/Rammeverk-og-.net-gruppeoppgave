using System;
namespace brusOgPotetgull.airportLiberary.CustomExceptions
{
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException()
            : base()
        {

        }
        public NegativeNumberException(string message)
            : base(message)
        {

        }
        public NegativeNumberException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
