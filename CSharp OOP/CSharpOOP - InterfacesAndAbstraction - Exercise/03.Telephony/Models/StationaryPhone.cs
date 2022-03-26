namespace _03.Telephony.Models
{
    public class StationaryPhone : Phone
    {
        public override string Call(string phoneNumber)
        {
            base.Call(phoneNumber);

            return $"Dialing... {phoneNumber}";
        }
    }
}
