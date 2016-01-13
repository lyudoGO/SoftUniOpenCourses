namespace AreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MatrixAreas
    {
        private static char[,] matrix;
        private static bool[,] visited;
        private static Dictionary<char, int> areas = new Dictionary<char, int>();

        static void Main()
        {
            Console.Write("Please, enter rows: ");
            int rows = int.Parse(Console.ReadLine());

            Console.WriteLine("Please, enter matrix of letters: ");
            FillMatrixWithLetters(rows);

            StartCountAreasInMatrix();

            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine("Areas: {0}", areas.Values.Sum());
            foreach (var pair in areas)
            {
                Console.WriteLine("Letter '{0}' -> {1}", pair.Key, pair.Value);
            }
        }

        private static void FillMatrixWithLetters(int rows)
        {
            string inputLine = Console.ReadLine();

            matrix = new char[rows, inputLine.Length];
            visited = new bool[rows, inputLine.Length];

            int row = 0;
            while (row < rows)
            {
                for (int col = 0; col < inputLine.Length; col++)
                {
                    matrix[row, col] = inputLine[col];
                }
                row++;
                inputLine = Console.ReadLine();
            }
        }

        private static void StartCountAreasInMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (!visited[row, col])
                    {
                        TraversalAndMarkVisitedDFS(row, col);
                        char startCell = matrix[row, col];
                        if (!areas.ContainsKey(startCell))
                        {
                            areas.Add(startCell, 0);
                        }
                        areas[startCell]++;
                    }
                }
            }
        }

        private static void TraversalAndMarkVisitedDFS(int startRow, int startCol)
        {
            int[] rowNeigbhors = new int[] { -1, 0, 0, 1 };
            int[] colNeigbhors = new int[] { 0, -1, 1, 0 };

            char startCell = matrix[startRow, startCol];
            visited[startRow, startCol] = true;

            for (int i = 0; i < 4; i++)
            {
                if (IsValidPosition(startRow + rowNeigbhors[i], startCol + colNeigbhors[i], startCell))
                {  
                    TraversalAndMarkVisitedDFS(startRow + rowNeigbhors[i], startCol + colNeigbhors[i]);
                }
            }
       }

        private static bool IsValidPosition(int currentRow, int currentColumn, char currentCell)
        {
            if (currentRow >= 0 && currentRow < matrix.GetLength(0) && currentColumn >= 0 &&
                currentColumn < matrix.GetLength(1) && 
                matrix[currentRow, currentColumn] == currentCell &&
                !visited[currentRow, currentColumn])
            {
                return true;
            }

            return false;
        }
    }
}