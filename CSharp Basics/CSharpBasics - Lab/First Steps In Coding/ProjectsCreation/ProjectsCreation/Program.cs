using System;

namespace ProjectsCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameArchitect = Console.ReadLine();
            int projectsCount = int.Parse(Console.ReadLine());

            Console.WriteLine($"The architect {nameArchitect} will need {projectsCount * 3} hours to complete {projectsCount} project/s.");

        }
    }
}
