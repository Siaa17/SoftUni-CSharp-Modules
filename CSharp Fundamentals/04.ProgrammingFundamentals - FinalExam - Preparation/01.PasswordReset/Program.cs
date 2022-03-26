using System;
using System.Linq;

namespace _01.PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string line = string.Empty;

            while ((line = Console.ReadLine()) != "Done")
            {
                string[] lineParts = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = lineParts[0];

                if (command == "TakeOdd")
                {
                    string newPassword = string.Empty;

                    for (int i = 1; i < password.Length; i += 2)
                    {
                        newPassword += password[i];
                    }

                    password = newPassword;

                    Console.WriteLine(password);
                }
                else if (command == "Cut")
                {
                    int index = int.Parse(lineParts[1]);
                    int length = int.Parse(lineParts[2]);

                    password = password.Remove(index, length);

                    Console.WriteLine(password);
                }
                else if (command == "Substitute")
                {
                    string substring = lineParts[1];
                    string substitute = lineParts[2];

                    if (password.Contains(substring))
                    {
                        password = password.Replace(substring, substitute);

                        Console.WriteLine(password);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
