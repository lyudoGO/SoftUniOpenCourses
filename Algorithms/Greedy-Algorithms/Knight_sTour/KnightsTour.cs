namespace Knight_sTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class KnightsTour
    {
        private static int[] knightMoves = { 1, 2, -1, 2, 2, 1, 1, -2, -1, -2, -2, 1, 2, -1, -2, -1 };

        static void Main()
        {
            Console.Write("Board size: ");
            int size = int.Parse(Console.ReadLine());

            int[,] board = new int[size, size];
            int maxValue = size * size;
            int value = 1;

            var startCell = new Cell(0, 0);
            while (value <= maxValue)
            {
                board[startCell.Row, startCell.Col] = value;
                var posibleCells = FindAllPosibleCells(board, startCell.Row, startCell.Col);

                int minMoves = int.MaxValue;
                
                foreach (var cell in posibleCells)
                {
                    int moves = FindAllPosibleCells(board, cell.Row, cell.Col).Count;
                    if (minMoves > moves)
                    {
                        minMoves = moves;
                        startCell.Row = cell.Row;
                        startCell.Col = cell.Col;
                    }
                }
                value++;
            }

            PrintBoard(board);
        }

        private static void PrintBoard(int[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write("{0, 5}", board[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static List<Cell> FindAllPosibleCells(int[,] board, int row, int col)
        {
            int size = board.GetLength(0);
            var positons = new List<Cell>();
            for (int i = 0; i < knightMoves.Length; i+=2)
            {
                int currentRow = row + knightMoves[i];
                int currentCol = col + knightMoves[i + 1];
                if (IsInsideBoard(size, currentRow, currentCol) && board[currentRow, currentCol] == 0)
                {
                    positons.Add(new Cell(currentRow, currentCol));
                }
            }

            return positons;
        }

        private static bool IsInsideBoard(int size, int row, int col)
        {
            return (row >= 0 && row < size && col >= 0 && col < size);
        }
         
    }
}
