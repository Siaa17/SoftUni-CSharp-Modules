using System;

namespace PipesInPool
{
    class Program
    {
        static void Main(string[] args)
        {
            int volumePool = int.Parse(Console.ReadLine());
            int pipe1 = int.Parse(Console.ReadLine());
            int pipe2 = int.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());

            double pipe1liters = pipe1 * hours;
            double pipe2liters = pipe2 * hours;
            double poolliters = (pipe1liters + pipe2liters);

            double vPoolInPercent = (poolliters / volumePool) * 100;
            double percentWaterPipe1 = (pipe1liters / poolliters) * 100;
            double percentWaterPipe2 = (pipe2liters / poolliters) * 100;

            if (volumePool >= poolliters)
            {
                Console.WriteLine($"The pool is {vPoolInPercent:F2}% full." +
                    $" Pipe 1: {percentWaterPipe1:F2}%. Pipe 2: {percentWaterPipe2:F2}%.");
            }
            else 
            {
                Console.WriteLine($"For {hours:F2} hours the pool overflows with {poolliters - volumePool:F2} liters.");
            }
        }
    }
}
