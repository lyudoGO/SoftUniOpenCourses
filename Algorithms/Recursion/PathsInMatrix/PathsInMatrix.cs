namespace PathsInMatrix
{
    using System;

    class PathsInMatrix
    {
        private static char[,] matrix = 
        {
            {'s', ' ', ' ', ' ' },
            {' ', '*', '*', ' ' },
            {' ', '*', '*', ' ' },
            {' ', '*', 'e', ' ' },
            {' ', ' ', ' ', ' ' }
        };
        private static char[] path = new char[matrix.GetLength(0) * matrix.GetLength(1)];
        private static int position = 0;
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

            path[position] = direction;
            position++;

            if (matrix[row, col] == 'e')
            {
                countPaths++;
                PrintPath(path, 1, position - 1);
            }

            if (matrix[row, col] == ' ' || matrix[row, col] == 's')
            {
                matrix[row, col] = 'V';

                FindPathsInMatrix(row, col - 1, 'L'); // check left
                FindPathsInMatrix(row - 1, col, 'U'); // check up
                FindPathsInMatrix(row, col + 1, 'R'); // check right
                FindPathsInMatrix(row + 1, col, 'D'); // check down

                matrix[row, col] = ' ';
            }

            position--;

        }

        private static void PrintPath(char[] path, int startPos, int endPos)
        {
            for (int pos = startPos; pos <= endPos; pos++)
            {
                Console.Write(path[pos]);
            }
            Console.WriteLine();
        }
    }
}
