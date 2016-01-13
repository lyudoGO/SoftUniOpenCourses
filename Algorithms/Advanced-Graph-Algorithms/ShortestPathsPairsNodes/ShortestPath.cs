namespace ShortestPathsPairsNodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ShortestPath
    {
        static void Main()
        {
            Console.Write("Nodes: ");
            int nodes = int.Parse(Console.ReadLine());
            Console.Write("Edges: ");
            int edges = int.Parse(Console.ReadLine());
            int[,] grahpMatrix = ReadEdgesAndFillGraph(nodes, edges);

            FloydWarshall(grahpMatrix, nodes);
            PrintFloydWarshall(grahpMatrix, nodes);
        }

        private static void PrintFloydWarshall(int[,] grahpMatrix, int nodes)
        {
            for (int i = 0; i < nodes; i++)
            {
                Console.Write("{0, 2} ", i);
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', nodes * 3));
            for (int row = 0; row < nodes; row++)
            {
                for (int col = 0; col < nodes; col++)
                {
                    Console.Write("{0, 3}", grahpMatrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void FloydWarshall(int[,] grahpMatrix, int nodes)
        {
            for (int i = 0; i < nodes; i++)
            {
                for (int j = 0; j < nodes; j++)
                {
                    for (int k = 0; k < nodes; k++)
                    {
                        if ((grahpMatrix[j, i] * grahpMatrix[i, k] != 0) && (j != k))
                        {
                            if (grahpMatrix[j, i] + grahpMatrix[i, k] < grahpMatrix[j, k] || grahpMatrix[j, k] == 0)
                            {
                                grahpMatrix[j, k] = grahpMatrix[j, i] + grahpMatrix[i, k];
                            }
                        }
                    }
                }
            }
        }

        private static int[,] ReadEdgesAndFillGraph(int nodes, int edges)
        {
            var graphMatrix = new int[nodes, nodes];
            for (int i = 0; i < edges; i++)
            {
                string[] parameters = Console.ReadLine().Split(new char[] { ' ', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
                int startNode = int.Parse(parameters[0]);
                int endNode = int.Parse(parameters[1]);
                int weight = int.Parse(parameters[2]);
                graphMatrix[startNode, endNode] = weight;
                graphMatrix[endNode, startNode] = weight;
            }

            return graphMatrix;
        }
    }
}
