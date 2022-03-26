using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //List<string> listOfStrings = new List<string>();

            //int countOfElements = int.Parse(Console.ReadLine());

            //for (int i = 0; i < countOfElements; i++)
            //{
            //    string element = Console.ReadLine();

            //    listOfStrings.Add(element);
            //}

            //Box<string> box = new Box<string>(listOfStrings);

            //string elementToComparison = Console.ReadLine();

            //int result = box.CountOfElementsGraterThan(elementToComparison);

            //Console.WriteLine(result);

            List <double> listOfDoubles = new List<double>();

            int countOfElements = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfElements; i++)
            {
                double number = double.Parse(Console.ReadLine());

                listOfDoubles.Add(number);
            }

            Box<double> box = new Box<double>(listOfDoubles);

            double elementToComparison = double.Parse(Console.ReadLine());

            int result = box.CountOfElementsGraterThan(elementToComparison);

            Console.WriteLine(result);
        }
    }
}
