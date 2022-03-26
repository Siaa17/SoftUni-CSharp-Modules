using System;
using System.Collections.Generic;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            if (expression.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            Stack<char> openingBrackets = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                char ch = expression[i];

                if (ch == '(' || ch == '[' || ch == '{')
                {
                    openingBrackets.Push(ch);
                }
                else if (openingBrackets.Count == 0)
                {
                    Console.WriteLine("NO");
                    return;
                }
                else
                {
                    char lastOpeningBracket = openingBrackets.Pop();

                    if (lastOpeningBracket == '(' && ch != ')')
                    {
                        Console.WriteLine("NO");
                        return;
                    }

                    if (lastOpeningBracket == '[' && ch != ']')
                    {
                        Console.WriteLine("NO");
                        return;
                    }

                    if (lastOpeningBracket == '{' && ch != '}')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }

            if (openingBrackets.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
