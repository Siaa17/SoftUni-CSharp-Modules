using System;
using System.Linq;

namespace _01.ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Generate")
            {
                string[] commandArgs = input
                    .Split(">>>", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = commandArgs[0];

                if (command == "Contains")
                {
                    string substring = commandArgs[1];

                    if (activationKey.Contains(substring))
                    {
                        Console.WriteLine($"{activationKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (command == "Flip")
                {
                    string casing = commandArgs[1];
                    int startIndex = int.Parse(commandArgs[2]);
                    int endIndex = int.Parse(commandArgs[3]);

                    string substring = activationKey.Substring(startIndex, endIndex - startIndex);

                    string replacement = casing == "Upper"
                        ? substring.ToUpper()
                        : substring.ToLower();

                    activationKey = activationKey.Replace(substring, replacement);

                    // Another solution to Upper/Lower case:
                    //activationKey = activationKey.Remove(startIndex, endIndex - startIndex);

                    //if (casing == "Upper")
                    //{
                    //    substring = substring.ToUpper();
                    //}
                    //else if (casing == "Lower")
                    //{
                    //    substring = substring.ToLower();
                    //}

                    //activationKey = activationKey.Insert(startIndex, substring);

                    Console.WriteLine(activationKey);
                }
                else if (command == "Slice")
                {
                    int startIndex = int.Parse(commandArgs[1]);
                    int endIndex = int.Parse(commandArgs[2]);

                    activationKey = activationKey.Remove(startIndex, endIndex - startIndex);

                    Console.WriteLine(activationKey);
                }
            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
