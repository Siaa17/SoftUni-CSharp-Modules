using System;

namespace MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double numTransformation = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string output = Console.ReadLine();

            double result = 0;

            if (input == "mm" && output == "m")
            {
                result = numTransformation / 1000;
            }
            else if (input == "m" && output == "mm")
            {
                result = numTransformation * 1000;
            }
            else if (input == "m" && output == "cm")
            {
                result = numTransformation * 100;
            }
            else if (input == "cm" && output == "m")
            {
                result = numTransformation / 100;
            }
            else if (input == "cm" && output == "mm")
            {
                result = numTransformation * 10;
            }
            else if (input == "mm" && output == "cm")
            {
                result = numTransformation / 10;
            }

            Console.WriteLine($"{result:F3}");
        }
    }
}
