namespace Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Salary
    {
        private static int[,] matrix;
        private static bool[] visited;
        private static int[] salaries;

        static void Main()
        {
            Console.Write("Please, enter a integer N: ");
            int numN = int.Parse(Console.ReadLine());
            matrix = new int[numN, numN];
            visited = new bool[numN];
            salaries = new int[numN];

            Console.WriteLine("Please, enter a strings with symbols Y and N :");
            FillMatrix(numN);

            CalculateSalaries(numN);

            int maxSalary = salaries.Sum();
            Console.WriteLine(maxSalary);
        }

        private static void CalculateSalaries(int numN)
        {
            for (int i = 0; i < numN; i++)
            {
                DFS(i);
            }
        }

        private static void DFS(int node)
        {
            if (!visited[node])
            {
                int salary = 0;
                bool hasChild = false;
                visited[node] = true;

                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                   
                    if (matrix[node, i] == 1)
                    {
                        hasChild = true;
                        DFS(i);
                        salary += salaries[i];
                    }
                }

                if (!hasChild)
                {
                    salaries[node] = 1;
                    return;
                }
                salaries[node] = salary;
            }
        }

        private static void FillMatrix(int numN)
        {
            for (int row = 0; row < numN; row++)
            {
                string inputLine = Console.ReadLine();

                for (int col = 0; col < inputLine.Length; col++)
                {
                    if (inputLine[col] == 'Y')
                    {
                        matrix[row, col] = 1;
                    }
                    if (inputLine[col] == 'N')
                    {
                        matrix[row, col] = 0;
                    }
                }
            }
        }
    }
}
