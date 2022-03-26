using System;
using System.Linq;

namespace _08.Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] inputPersonInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string fullName = inputPersonInfo[0] + " " + inputPersonInfo[1];
            string address = inputPersonInfo[2];
            string town = string.Join(" ", inputPersonInfo.Skip(3));

            string[] inputBeerOfPerson = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string name = inputBeerOfPerson[0];
            int litersOfBeer = int.Parse(inputBeerOfPerson[1]);
            string stateOfSobriety = inputBeerOfPerson[2];
            bool isDrunk = stateOfSobriety == "drunk" ? true : false;

            string[] inputBankInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string personName = inputBankInfo[0];
            double accountBalance = double.Parse(inputBankInfo[1]);
            string bankName = inputBankInfo[2];

            Threeuple<string, string, string> personInfo = new Threeuple<string, string, string>(fullName, address, town);
            Threeuple<string, int, bool> beerOfPerson = new Threeuple<string, int, bool>(name, litersOfBeer, isDrunk);
            Threeuple<string, double, string> bankInfo = new Threeuple<string, double, string>(personName, accountBalance, bankName);

            Console.WriteLine(personInfo);
            Console.WriteLine(beerOfPerson);
            Console.WriteLine(bankInfo);
        }
    }
}
