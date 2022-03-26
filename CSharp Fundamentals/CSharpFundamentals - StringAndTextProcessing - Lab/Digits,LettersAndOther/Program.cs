using System;
using System.Text;

namespace Digits_LettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string randomSymbols = Console.ReadLine();

            StringBuilder digits = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder other = new StringBuilder();

            foreach (char symbol in randomSymbols)
            {
                if (char.IsDigit(symbol))
                {
                    digits.Append(symbol);
                }
                else if (char.IsLetter(symbol))
                {
                    letters.Append(symbol);
                }
                else
                {
                    other.Append(symbol);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, digits, letters, other));
        }
    }
}
