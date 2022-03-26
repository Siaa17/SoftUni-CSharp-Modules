using System;
using System.Linq;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Complete")
            {
                string[] commandArgs = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = commandArgs[0];

                switch (command)
                {
                    case "Make":
                        string casing = commandArgs[1];

                        email = casing == "Upper" ? email.ToUpper() : email.ToLower();

                        Console.WriteLine(email);
                        break;
                    case "GetDomain":
                        int count = int.Parse(commandArgs[1]);

                        if (count >= 0 && count < email.Length)
                        {
                            Console.WriteLine(email.Substring(email.Length - count));
                        }
                        else
                        {
                            Console.WriteLine(email);
                        }
                        break;
                    case "GetUsername":
                        if (!email.Contains('@'))
                        {
                            Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                        }
                        else
                        {
                            string[] emailParts = email
                             .Split("@", StringSplitOptions.RemoveEmptyEntries);

                            string username = emailParts[0];

                            // Another solution for this command:

                            //int indexOfAt = email.IndexOf('@');

                            //string username = email.Substring(0, indexOfAt);

                            Console.WriteLine(username);
                        }
                        break;
                    case "Replace":
                        char oldChar = char.Parse(commandArgs[1]);

                        email = email.Replace(oldChar, '-');

                        Console.WriteLine(email);
                        break;
                    case "Encrypt":
                        for (int i = 0; i < email.Length; i++)
                        {
                            int currentSymbol = email[i];

                            Console.Write(currentSymbol + " ");
                        }

                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}
