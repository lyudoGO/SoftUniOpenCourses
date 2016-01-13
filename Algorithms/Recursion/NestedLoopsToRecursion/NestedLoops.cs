namespace NestedLoopsToRecursion
{
    using System;
    using System.Collections.Generic;

    class NestedLoops
    {
        private static int numberOfLoops;
        private static int[] loops;

        static void Main()
        {
            Console.Write("Please, enter a positive integer number: ");
            numberOfLoops = int.Parse(Console.ReadLine());
            loops = new int[numberOfLoops];

            CallLoops(0);
        }

        private static void CallLoops(int currentLoop)
        {
            if (currentLoop == numberOfLoops)
            {
                PrintLoop();
                return;
            }

            for (int counter = 1; counter <= numberOfLoops; counter++)
            {
                loops[currentLoop] = counter;
                CallLoops(currentLoop + 1);
                
            }
        }

        private static void PrintLoop()
        {
            Console.WriteLine(string.Join(" ", loops));
        }
    }
}
