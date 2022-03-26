using System;

namespace _05.DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            double result = DateModifier.GetDifferenceInDaysBetweenTwoDates(firstDate, secondDate);

            Console.WriteLine(result);
        }
    }
}
