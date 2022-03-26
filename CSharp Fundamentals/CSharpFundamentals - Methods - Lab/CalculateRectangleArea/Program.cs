using System;

namespace CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int area = CalculateRectangleArea(width, height);

            Console.WriteLine(area);
        }

        static int CalculateRectangleArea(int width, int height)
        {
             return width * height;
        }
    }
}
