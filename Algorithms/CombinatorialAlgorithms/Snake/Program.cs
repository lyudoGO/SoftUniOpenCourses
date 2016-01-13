using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        private static char[,] matrix = 
        {
            {' ', ' ', ' ', ' ', ' ', ' ' },
            {' ', ' ', ' ', ' ', ' ', ' ' },
            {' ', ' ', ' ', ' ', ' ', ' ' },
            {' ', ' ', ' ', ' ', ' ', ' ' },
            {' ', ' ', ' ', ' ', ' ', ' ' },
            {' ', ' ', ' ', ' ', ' ', ' ' },
            {' ', ' ', ' ', ' ', ' ', ' ' }
        };
        private static int lenght = 3;
        private static List<char> path = new List<char>();
        private static int countPaths = 0;


        static void Main()
        {
            FindPathsInMatrix(0, 0, 'S');
            Console.WriteLine("Total paths found: {0}", countPaths);
        }

        private static void FindPathsInMatrix(int row, int col, char direction)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] == 'V' || lenght < 0)
            {
                countPaths++;
                PrintPath();
                return;
            }

            if (lenght > 0 )
            {
                lenght--;
                matrix[row, col] = 'V';
                path.Add(direction);

                FindPathsInMatrix(row, col + 1, 'R'); // check right
                FindPathsInMatrix(row + 1, col, 'D'); // check down
                FindPathsInMatrix(row, col - 1, 'L'); // check left
                FindPathsInMatrix(row - 1, col, 'U'); // check up

                lenght++;
                matrix[row, col] = ' ';
                path.RemoveAt(path.Count - 1);
            }
        }

        private static void PrintPath()
        {
            for (int i = 0; i < path.Count; i++)
            {
                if (path[1] != 'R' || path.Count < lenght)
                {
                    return;
                }
                Console.Write(path[i]);
            }
            Console.WriteLine();
        }
    }
}
