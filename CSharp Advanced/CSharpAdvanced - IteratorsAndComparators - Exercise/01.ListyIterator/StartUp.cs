using System;
using System.Linq;

namespace _01.ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listy = null;

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = tokens[0];

                if (command == "Create")
                {
                    listy = new ListyIterator<string>(tokens.Skip(1).ToList());
                }
                else if (command == "Move")
                {
                    Console.WriteLine(listy.Move());
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(listy.HasNext());
                }
                else if (command == "Print")
                {
                    try
                    {
                        listy.Print();
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                        throw;
                    }
                }
                else if (command == "PrintAll")
                {
                    listy.PrintAll();
                }
            }
        }
    }
}
