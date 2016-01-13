namespace CombinationsWithRepetition
{
    using System;
    using System.Linq;

    class CombinationsWithRepetition
    {
        private static int numberN;
        private static int numberK;
        private static int[] loops;

        static void Main()
        {
            Console.Write("Please, enter a number N for set of elements: ");
            numberN = int.Parse(Console.ReadLine());

            Console.Write("Please, enter number K <= N for elements: ");
            numberK = int.Parse(Console.ReadLine());

            loops = new int[numberK];

            CallLoops(0, 1);
        }

        private static void CallLoops(int currentLoop, int start)
        {
            if (currentLoop >= numberK)
            {
                PrintLoop();
                return;
            }

            for (int counter = start; counter <= numberN; counter++)
            {
                loops[currentLoop] = counter;
                CallLoops(currentLoop + 1, counter);
            }
        }

        private static void PrintLoop()
        {
            Console.WriteLine(string.Join(" ", loops));
        }
    }
}
