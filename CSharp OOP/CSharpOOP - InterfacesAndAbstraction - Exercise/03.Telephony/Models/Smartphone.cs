using System.Linq;
using _03.Telephony.Interfaces;
using _03.Telephony.Exceptions;

namespace _03.Telephony.Models
{
    public class Smartphone : Phone, IBrowsable
    {
        public string Browse(string url)
        {
            if (url.Any(x => char.IsDigit(x)))
            {
                throw new InvalidURLException();
            }
           
            return $"Browsing: {url}!";
        }

        public override string Call(string phoneNumber)
        {
            base.Call(phoneNumber);

            return $"Calling... {phoneNumber}";
        }
    }
}
