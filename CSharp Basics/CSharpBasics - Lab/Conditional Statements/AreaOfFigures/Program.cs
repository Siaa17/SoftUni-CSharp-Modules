using System;
using System.Drawing;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            string shape = Console.ReadLine();

            double area = 0;

            if (shape == "square")
            {
                double a = double.Parse(Console.ReadLine());
                area = a * a; 
            }
            else if (shape == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                area = a * b;
            }
            else if (shape == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                area = Math.PI * r * r;
            }
            else if (shape == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double ha = double.Parse(Console.ReadLine());
                area = a * ha / 2;
            }

            Console.WriteLine($"{area:F3}");
        }
    }
}
