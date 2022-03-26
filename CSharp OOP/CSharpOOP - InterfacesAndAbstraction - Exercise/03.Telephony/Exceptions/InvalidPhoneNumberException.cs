using System;

namespace _03.Telephony.Exceptions
{
    public class InvalidPhoneNumberException : ApplicationException
    {
        private const string InvalidNumberExceptionMessage = "Invalid number!";

        public InvalidPhoneNumberException() 
            : base(InvalidNumberExceptionMessage)
        {
        }
    }
}
