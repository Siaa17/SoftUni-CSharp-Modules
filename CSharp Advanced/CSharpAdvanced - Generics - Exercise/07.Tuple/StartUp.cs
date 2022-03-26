using System;
using System.Linq;

namespace _07.Tuple
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

            string[] inputBeerOfPerson = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string name = inputBeerOfPerson[0];
            int litersOfBeer = int.Parse(inputBeerOfPerson[1]);

            string[] inputNumbersInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int intNumber = int.Parse(inputNumbersInfo[0]);
            double doubleNumber = double.Parse(inputNumbersInfo[1]);

            Tuple<string, string> personInfo = new Tuple<string, string>(fullName, address);
            Tuple<string, int> beerOfPerson = new Tuple<string, int>(name, litersOfBeer);
            Tuple<int, double> numbersInfo = new Tuple<int, double>(intNumber, doubleNumber);

            Console.WriteLine(personInfo);
            Console.WriteLine(beerOfPerson);
            Console.WriteLine(numbersInfo);
        }
    }
}
