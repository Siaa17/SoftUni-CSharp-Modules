using System.Linq;
using _03.Telephony.Interfaces;
using _03.Telephony.Exceptions;

namespace _03.Telephony
{
    public abstract class Phone : ICallable
    {
        public virtual string Call(string phoneNumber)
        {
            if (!phoneNumber.All(x => char.IsDigit(x)))
            {
                throw new InvalidPhoneNumberException();
            }

            return "";
        }
    }
}
