namespace RideTheHorse
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static int[,] matrix;

        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());
            int startRow = int.Parse(Console.ReadLine());
            int startColumn = int.Parse(Console.ReadLine());

            InitializeMatrix(rows, columns);
            RideTheHorseBFS(startRow, startColumn);
            PrintMatrix();
        }

        private static void RideTheHorseBFS(int startRow, int startColumn)
        {
            var startCell = new Cell(startRow, startColumn, 1);
            Queue<Cell> queue = new Queue<Cell>();
            queue.Enqueue(startCell);

            while (queue.Count > 0)
	        {
                var currentCell = queue.Dequeue();
                int currentRow = currentCell.Row;
                int currentColumn = currentCell.Column;

                matrix[currentRow, currentColumn] = currentCell.Value;

                if (IsValidPosition(currentRow - 2, currentColumn - 1))
                {
                    queue.Enqueue(new Cell(currentRow - 2, currentColumn - 1, currentCell.Value + 1));
                }
                if (IsValidPosition(currentRow + 2, currentColumn - 1))
                {
                    queue.Enqueue(new Cell(currentRow + 2, currentColumn - 1, currentCell.Value + 1));
                }
                if (IsValidPosition(currentRow - 2, currentColumn + 1))
                {
                    queue.Enqueue(new Cell(currentRow - 2, currentColumn + 1, currentCell.Value + 1));
                }
                if (IsValidPosition(currentRow + 2, currentColumn + 1))
                {
                    queue.Enqueue(new Cell(currentRow + 2, currentColumn + 1, currentCell.Value + 1));
                }
                if (IsValidPosition(currentRow - 1, currentColumn - 2))
                {
                    queue.Enqueue(new Cell(currentRow - 1, currentColumn - 2, currentCell.Value + 1));
                }
                if (IsValidPosition(currentRow - 1, currentColumn + 2))
                {
                    queue.Enqueue(new Cell(currentRow - 1, currentColumn + 2, currentCell.Value + 1));
                }
                if (IsValidPosition(currentRow + 1, currentColumn - 2))
                {
                    queue.Enqueue(new Cell(currentRow + 1, currentColumn - 2, currentCell.Value + 1));
                }
                if (IsValidPosition(currentRow + 1, currentColumn + 2))
                {
                    queue.Enqueue(new Cell(currentRow + 1, currentColumn + 2, currentCell.Value + 1));
                }
	        }
        }

        private static bool IsValidPosition(int currentRow, int currentColumn)
        {
            if (currentRow >= 0 && currentRow < matrix.GetLength(0) && currentColumn >= 0 && 
                currentColumn < matrix.GetLength(1) && matrix[currentRow, currentColumn] == 0)
            {
                return true;
            }

            return false;
        }
        private static void InitializeMatrix(int rows, int columns)
        {
            matrix = new int[rows, columns];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = 0;
                }
            }
        }

        private static void PrintMatrix()
        {
            int col = matrix.GetLength(1) / 2;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine(matrix[row, col]);
            }
        }
    }
}
