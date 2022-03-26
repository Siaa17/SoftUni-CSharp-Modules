using System;

namespace _03.Telephony.Exceptions
{
    public class InvalidURLException : ApplicationException
    {
        private const string InvalidURLExceptionMessage = "Invalid URL!";

        public InvalidURLException() 
            : base(InvalidURLExceptionMessage)
        {
        }
    }
}
