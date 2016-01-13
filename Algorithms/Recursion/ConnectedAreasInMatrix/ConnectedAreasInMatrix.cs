namespace ConnectedAreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ConnectedAreasInMatrix
    {
        private static char[,] matrix = 
        {
            {' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ' },
            {' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ' },
            {' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ' },
            {' ', ' ', ' ', ' ', '*', ' ', '*', ' ', ' ' },
         };

        private static SortedSet<Area> areas = new SortedSet<Area>();

        static void Main()
        {
            FindStartCellAndGo();
            PrintResult();
        }

        private static void FindStartCellAndGo()
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[0, col] == ' ')
                {
                    var area = new Area()
                    {
                        Row = 0,
                        Col = col
                    };
                  
                    FindAreaInMatrix(0, col, area);
                    areas.Add(area);
                }
            }
        }

        private static void FindAreaInMatrix(int row, int col, Area area)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] != ' ')
            {
                //areas.Add(area);
                return;
            }

            matrix[row, col] = 'V';
            area.Size++;

            FindAreaInMatrix(row, col + 1, area);
            FindAreaInMatrix(row + 1, col, area);
            FindAreaInMatrix(row, col - 1, area);
            FindAreaInMatrix(row - 1, col, area);
        }

        private static void PrintResult()
        {
            int count = 0;
            Console.WriteLine("Total areas found: {0}", areas.Count);
            foreach (var area in areas)
            {
                count++;
                Console.WriteLine("Area #{3} at ({0}, {1}), size: {2}", area.Row, area.Col, area.Size, count);
            }
        }
    }
}
