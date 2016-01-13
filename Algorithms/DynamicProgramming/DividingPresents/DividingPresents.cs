namespace DividingPresents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class DividingPresents
    {
        static void Main()
        {
            Console.WriteLine("Please, enter a sequence of value of presents:");
            var presents = Console.ReadLine()
                                  .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(int.Parse)
                                  .ToArray();

            var totalValues = presents.Sum();

            var presentsTaken = FindPresents(presents, totalValues / 2);
 
            var alenValues = presentsTaken.Sum();
            var bobValues = totalValues - alenValues;
            Console.WriteLine("Difference: {0}", bobValues - alenValues);
            Console.WriteLine("Alan: {0} Bob: {1}", alenValues, bobValues);
            Console.WriteLine("Alan talkes: {0}", string.Join(", ", presentsTaken));
            Console.WriteLine("Bob takes the rest.");
        }

        public static int[] FindPresents(int[] presents, int halfValues)
        {
            var presentValues = new int[presents.Length, halfValues + 1];
            var isPresentTaken = new bool[presents.Length, halfValues + 1];

            for (int value = 0; value <= halfValues; value++)
            {
                if (presents[0] <= value)
                {
                    presentValues[0, value] = presents[0];
                    isPresentTaken[0, value] = true;
                }
            }

            for (int i = 1; i < presents.Length; i++)
            {
                for (int value = 0; value <= halfValues; value++)
                {
                    presentValues[i, value] = presentValues[i - 1, value];
                    var remainingValue = value - presents[i];
                    if (remainingValue >= 0 &&
                        presentValues[i - 1, remainingValue] + presents[i] > presentValues[i - 1, value])
                    {
                        presentValues[i, value] = presentValues[i - 1, remainingValue] + presents[i];
                        isPresentTaken[i, value] = true;
                    }
                }
            }

            var presentsTaken = new List<int>();
            int itemIndex = presents.Length - 1;
            while (itemIndex >= 0)
            {
                if (isPresentTaken[itemIndex, halfValues])
                {
                    presentsTaken.Add(presents[itemIndex]);
                    halfValues -= presents[itemIndex];
                }
                itemIndex--;
            }

            return presentsTaken.ToArray();
        }
    }
}
