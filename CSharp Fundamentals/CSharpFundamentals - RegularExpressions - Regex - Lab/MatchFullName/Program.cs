using System;
using System.Text.RegularExpressions;

namespace MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string listOfNames = Console.ReadLine();

            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+";

            Regex regex = new Regex(pattern);

            MatchCollection matchedNames = regex.Matches(listOfNames);

            foreach (Match name in matchedNames)
            {
                Console.Write($"{name.Value} ");
            }

            Console.WriteLine();

            //Solution without foreach loop:
            //string listOfNames = Console.ReadLine();

            //string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+";

            //MatchCollection matchedNames = Regex.Matches(listOfNames, pattern);

            //Console.WriteLine(string.Join(" ", matchedNames));
        }
    }
}
