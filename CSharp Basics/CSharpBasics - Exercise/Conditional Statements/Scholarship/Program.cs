using System;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double averageGrade = double.Parse(Console.ReadLine());
            double minSalary = double.Parse(Console.ReadLine());

            double socialScholarship = Math.Floor(0.35 * minSalary);
            double excellentScholarship = Math.Floor(averageGrade * 25);

            if (averageGrade >= 5.5 && income <= minSalary)
            {
                if (excellentScholarship >= socialScholarship)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {excellentScholarship} BGN");
                }
                else
                {
                    Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
                }
            }
            else if (averageGrade >= 5.5 && income > minSalary)
            {
                Console.WriteLine($"You get a scholarship for excellent results {excellentScholarship} BGN");
            }
            else if (averageGrade > 4.5 && income < minSalary)
            {
                Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
            }
            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            }
        }
    }

