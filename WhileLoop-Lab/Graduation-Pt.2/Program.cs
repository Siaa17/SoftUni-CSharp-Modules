using System;

namespace Graduation_Pt._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();

            int grade = 1;
            int failedCounter = 0;
            double totalRating = 0;
            bool isGraduated = true;

            while (grade <= 12)
            {
                double rating = double.Parse(Console.ReadLine());

                if (rating >= 4)
                {
                    totalRating += rating;
                    grade++;
                }
                else
                {
                    failedCounter++;

                    if (failedCounter == 2)
                    {
                        isGraduated = false;
                        break;
                    }
                }
            }

            if (isGraduated)
            {
                double average = totalRating / 12;
                Console.WriteLine($"{studentName} graduated. Average grade: {average:F2}");
            }
            else
            {
                Console.WriteLine($"{studentName} has been excluded at {grade} grade");
            }
        }
    }
}
