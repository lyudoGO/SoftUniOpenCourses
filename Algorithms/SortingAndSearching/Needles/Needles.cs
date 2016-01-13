using System;
using System.Linq;

class Needles
{
    static void Main()
    {
        string[] lineOne = Console.ReadLine().Split(' ');
        int numberC = int.Parse(lineOne[0]);
        int numberN = int.Parse(lineOne[1]);

        int[] sequence = Console.ReadLine().Split(' ').Select(n => int.Parse(n)).ToArray();
        string[] lineThree = Console.ReadLine().Split(' ');

        for (int i = 0; i < lineThree.Length; i++)
        {
            int currentNumber = int.Parse(lineThree[i]);
            for (int j = 0; j < sequence.Length; j++)
            {
                if (currentNumber > sequence[j] && j == sequence.Length - 1)
                {
                    Console.Write(j + 1 + " ");
                    break;
                }

                if (currentNumber <= sequence[j])
                {
                    Console.Write(j + " ");
                    break;
                }

                if (sequence[j] == 0)
                {
                    int startIndex = j;
                    while (sequence[j] == 0)
                    {
                        if (j == sequence.Length - 1)
                        {
                            Console.Write(startIndex + " ");
                            j = sequence.Length;
                            break;
                        }

                        j++;
  
                        if (currentNumber <= sequence[j])
                        {
                            Console.Write(startIndex + " ");
                            j = sequence.Length;
                            break;
                        }
                    }
                    j--;
                }
            }
        }
    }
}