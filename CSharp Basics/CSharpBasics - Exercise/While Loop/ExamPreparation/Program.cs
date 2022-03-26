using System;

namespace ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int poorGradesLimit = int.Parse(Console.ReadLine());
            string task = Console.ReadLine();

            int poorGrades = 0;
            bool isExcellent = true;
            double sumGrades = 0;
            double gradesCount = 0;
            string lastTask = "";

            while (task != "Enough")
            {
                int grade = int.Parse(Console.ReadLine());
                sumGrades += grade;
                gradesCount++;
                lastTask = task;

                if (grade <= 4)
                {
                    poorGrades++;
                    if (poorGrades == poorGradesLimit)
                    {
                        isExcellent = false;
                        break;
                    }
                }

                task = Console.ReadLine();
            }

            double averageGrade = sumGrades / gradesCount;

            if (isExcellent)
            {
                Console.WriteLine($"Average score: {averageGrade:F2}");
                Console.WriteLine($"Number of problems: {gradesCount}");
                Console.WriteLine($"Last problem: {lastTask}");
            }
            else
            {
                Console.WriteLine($"You need a break, {poorGrades} poor grades.");
            }
        }
    }
}
