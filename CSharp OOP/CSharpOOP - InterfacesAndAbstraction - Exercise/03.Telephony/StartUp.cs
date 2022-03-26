using System;
using System.Linq;
using _03.Telephony.Models;
using _03.Telephony.Exceptions;

namespace _03.Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] urls = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Smartphone smartPhone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (string phoneNumber in phoneNumbers)
            {
                try
                {
                    string result = phoneNumber.Length == 7
                        ? stationaryPhone.Call(phoneNumber)
                        : smartPhone.Call(phoneNumber);

                    Console.WriteLine(result);
                }
                catch (InvalidPhoneNumberException ie)
                {
                    Console.WriteLine(ie.Message);
                }
            }

            foreach (string url in urls)
            {               
                try
                {
                    string result = smartPhone.Browse(url);

                    Console.WriteLine(result);
                }
                catch (InvalidURLException ie)
                {
                    Console.WriteLine(ie.Message);
                }
            }
        }
    }
}
