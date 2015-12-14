//Problem 8.* Distance in Labyrinth
//We are given a labyrinth of size N x N. Some of its cells are empty (0) and some are full (x).
//We can move from an empty cell to another empty cell if they share common wall. 
//Given a starting position (*) calculate and fill in the array the minimal distance from this 
//position to any other cell in the array. 
//Use "u" for all unreachable cells. Example:


namespace _08.DistanceInLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DistanceInLabyrinth
    {
        private static string[,] labyrinth = 
        {
            { "0", "0", "0", "x", "0", "x"},
            { "0", "x", "0", "x", "0", "x"},
            { "0", "*", "x", "0", "x", "0"},
            { "0", "x", "0", "0", "0", "0"},
            { "0", "0", "0", "x", "x", "0"},
            { "0", "0", "0", "x", "0", "x"}
        };

        static void Main(string[] args)
        {
            Cell startCell = GetStartCell(labyrinth);

            GetDistanceInLabyrinth(labyrinth, startCell);

            PrintLabyrinth(labyrinth);
        }

        private static void GetDistanceInLabyrinth(string[,] labyrinth, Cell startCell)
        {
            CalculateDistanceBFS(labyrinth, startCell);
            FillUnreachableCells(labyrinth);
        }

        private static void CalculateDistanceBFS(string[,] labyrinth, Cell startCell)
        {
            Queue<Cell> cells = new Queue<Cell>();
            cells.Enqueue(startCell);

            while (cells.Count > 0)
            {
                var currentCell = cells.Dequeue();
                var currentRow = currentCell.Row;
                var currentCol = currentCell.Col;
                var currentValue = currentCell.Value + 1;

                if (currentRow + 1 < labyrinth.GetLength(0) && labyrinth[currentRow + 1, currentCol] == "0")
                {
                    labyrinth[currentRow + 1, currentCol] = currentValue.ToString();
                    cells.Enqueue(new Cell(currentRow + 1, currentCol, currentValue));
                }

                if (currentRow - 1 >= 0 && labyrinth[currentRow - 1, currentCol] == "0")
                {
                    labyrinth[currentRow - 1, currentCol] = currentValue.ToString();
                    cells.Enqueue(new Cell(currentRow - 1, currentCol, currentValue));
                }

                if (currentCol + 1 < labyrinth.GetLength(1) && labyrinth[currentRow, currentCol + 1] == "0")
                {
                    labyrinth[currentRow, currentCol + 1] = currentValue.ToString();
                    cells.Enqueue(new Cell(currentRow, currentCol + 1, currentValue));
                }

                if (currentCol - 1 >= 0 && labyrinth[currentRow, currentCol - 1] == "0")
                {
                    labyrinth[currentRow, currentCol - 1] = currentValue.ToString();
                    cells.Enqueue(new Cell(currentRow, currentCol - 1, currentValue));
                }
            }
        }

        private static void FillUnreachableCells(string[,] labyrinth)
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {

                    if (labyrinth[row, col] == "0")
                    {
                        labyrinth[row, col] = "u";
                    }
                }
            }
        }

        private static Cell GetStartCell(string[,] labyrinth)
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    var currentValue = labyrinth[row, col];
                    if (currentValue == "*")
                    {
                        var startCell = new Cell(row, col, 0);
                        return startCell;
                    }
                }
            }

            throw new ArgumentException("There is no start cell!");
        }

        private static void PrintLabyrinth(string[,] labyrinth)
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    Console.Write(labyrinth[row, col] + "  ");
                }
                Console.WriteLine();
            }
        }
    }
}
