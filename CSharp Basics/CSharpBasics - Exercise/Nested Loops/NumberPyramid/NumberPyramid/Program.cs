using System;

namespace NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int currNum = 1;
            bool isBigger = false;

            for (int rows = 1; rows <= num; rows++)
            {
                for (int cols = 1; cols <= rows ; cols++)
                {
                    if (currNum > num)
                    {
                        isBigger = true;
                        break;
                    }
                    
                    Console.Write(currNum + " ");
                    currNum++;
                }

                if (isBigger)
                {
                    break;
                }

                Console.WriteLine();
            }
        }
    }
}
