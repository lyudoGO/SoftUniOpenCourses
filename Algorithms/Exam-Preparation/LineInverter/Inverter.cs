namespace LineInverter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Inverter
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            bool[,] matrix = ReadMatrixFromConsole(n);

            for (int iteration = 0; iteration < 2 * n + 1; iteration++)
            {
                int[] whiteCellsInRow = new int[n];
                int[] whiteCellsInColumn = new int[n];
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (matrix[row, col])
                        {
                            whiteCellsInColumn[col]++;
                            whiteCellsInRow[row]++;
                        }
                    }
                }

                int maxRowWhiteCells = whiteCellsInRow.Max();
                int maxColWhiteCells = whiteCellsInColumn.Max();
                if (maxColWhiteCells == 0 && maxRowWhiteCells == 0)
                {
                    Console.WriteLine(iteration);
                    return;
                }

                if (maxRowWhiteCells >= maxColWhiteCells)
                {
                    int rowIndex = Array.IndexOf(whiteCellsInRow, maxRowWhiteCells);
                    InvertRow(rowIndex, matrix);
                }
                else
                {
                    int colIndex = Array.IndexOf(whiteCellsInColumn, maxColWhiteCells);
                    InvertColumn(colIndex, matrix);
                }
            }

            Console.WriteLine(-1);
        }

        private static bool[,] ReadMatrixFromConsole(int n)
        {
            var matrix = new bool[n, n];
            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    if (input[col] == 'W')
                    {
                        matrix[row, col] = true;
                    }
                }
            }

            return matrix;
        }

        static void InvertRow(int row, bool[,] matrix)
        {
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                matrix[row, col] = !matrix[row, col];
            }
        }

        static void InvertColumn(int col, bool[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row, col] = !matrix[row, col];
            }
        }
    }
}
