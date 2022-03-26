using System;

namespace GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();

            switch (dataType)
            {
                case "int":
                    int number1 = int.Parse(Console.ReadLine());
                    int number2 = int.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(number1, number2)); 
                    break;
                case "char":
                    char firstChar = char.Parse(Console.ReadLine());
                    char secondChar = char.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(firstChar, secondChar)); 
                    break;
                case "string":
                    string firstString = Console.ReadLine();
                    string secondString = Console.ReadLine();
                    Console.WriteLine(GetMax(firstString, secondString)); 
                    break;
            }
        }

        static int GetMax(int num1, int num2)
        {
            if (num1 > num2)
            {
                return num1; 
            }
            else
            {
                return num2;    
            }
        }

        static char GetMax(char char1, char char2)
        {
            if (char1 > char2)
            {
                return char1;
            }
            else
            {
                return char2;
            }
        }

        static string GetMax(string string1, string string2)
        {
            if (String.Compare(string1, string2) > 0)
            {
                return string1;
            }
            else
            {
                return string2;
            }
        }
    }
}
