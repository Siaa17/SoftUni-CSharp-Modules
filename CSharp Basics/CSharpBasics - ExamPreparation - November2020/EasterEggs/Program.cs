using System;

namespace EasterEggs
{
    class Program
    {
        static void Main(string[] args)
        {
            int eggsCount = int.Parse(Console.ReadLine());

            int numOfRedEggs = 0;
            int numOfOrangeEggs = 0;
            int numOfBlueEggs = 0;
            int numOfGreenEggs = 0;
            int maxNumOfEggs = int.MinValue;
            string maxNumOfEggsColor = "";

            for (int eggs = 0; eggs < eggsCount; eggs++)
            {
                string eggColor = Console.ReadLine();

                switch (eggColor)
                {
                    case "red":
                        numOfRedEggs++;
                        if (numOfRedEggs > maxNumOfEggs)
                        {
                            maxNumOfEggs = numOfRedEggs;
                            maxNumOfEggsColor = "red";
                        }
                        break;
                    case "orange":
                        numOfOrangeEggs++;
                        if (numOfOrangeEggs > maxNumOfEggs)
                        {
                            maxNumOfEggs = numOfOrangeEggs;
                            maxNumOfEggsColor = "orange";
                        }
                        break;
                    case "blue":
                        numOfBlueEggs++;
                        if (numOfBlueEggs > maxNumOfEggs)
                        {
                            maxNumOfEggs = numOfBlueEggs;
                            maxNumOfEggsColor = "blue";
                        }
                        break;
                    case "green":
                        numOfGreenEggs++;
                        if (numOfGreenEggs > maxNumOfEggs)
                        {
                            maxNumOfEggs = numOfGreenEggs;
                            maxNumOfEggsColor = "green";
                        }
                        break;   
                }                
            }

            Console.WriteLine($"Red eggs: {numOfRedEggs}");
            Console.WriteLine($"Orange eggs: {numOfOrangeEggs}");
            Console.WriteLine($"Blue eggs: {numOfBlueEggs}");
            Console.WriteLine($"Green eggs: {numOfGreenEggs}");
            Console.WriteLine($"Max eggs: {maxNumOfEggs} -> {maxNumOfEggsColor}");
        }
    }
}
