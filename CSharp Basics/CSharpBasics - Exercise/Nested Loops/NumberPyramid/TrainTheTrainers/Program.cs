using System;

namespace TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int judgeCount = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();

            double totalGradesSum = 0;
            int gradesCounter = 0;

            while (text != "Finish")
            {
                double gradesSum = 0;

                for (int judge = 1; judge <= judgeCount; judge++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    gradesSum += grade;
                    totalGradesSum += grade;
                    gradesCounter++;
                }

                double averageGrade = gradesSum / judgeCount;
                Console.WriteLine($"{text} - {averageGrade:F2}.");

                text = Console.ReadLine();
            }

            double averageGradeForAll = totalGradesSum / gradesCounter;
            Console.WriteLine($"Student's final assessment is {averageGradeForAll:F2}.");
        }
    }
}
