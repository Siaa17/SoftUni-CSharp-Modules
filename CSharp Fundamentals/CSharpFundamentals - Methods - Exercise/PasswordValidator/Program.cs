using System;

namespace PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPassword = Console.ReadLine();

            bool isValid = true;

            if (!(HasValidLength(inputPassword)))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                isValid = false;
            }
            
            if ((ContainsInvalidChars(inputPassword)))
            {
                Console.WriteLine("Password must consist only of letters and digits");
                isValid = false;
            }

            if (!(ContainsAtLeast2Digits(inputPassword)))
            {
                Console.WriteLine("Password must have at least 2 digits");
                isValid = false;
            }

            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool HasValidLength(string password)
        {
            if (password.Length >= 6 && password.Length <= 10)
            {
                return true;
            }

            return false;
        }

        static bool ContainsInvalidChars(string password)
        {
            foreach (char symbol in password)
            {
                if (!(char.IsLetterOrDigit(symbol)))
                {
                    return true;
                }
            }

            return false;
        }

        static bool ContainsAtLeast2Digits(string password)
        {
            int digitCounter = 0;

            foreach (char symbol in password)
            {
                if (char.IsDigit(symbol))
                {
                    digitCounter++;
                }
            }

            return digitCounter >= 2;
        }  
    }
}
