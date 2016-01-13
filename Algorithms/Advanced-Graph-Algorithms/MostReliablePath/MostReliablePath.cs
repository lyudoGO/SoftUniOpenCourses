namespace MostReliablePath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MostReliablePath
    {
        static void Main()
        {
            Console.Write("Nodes: ");
            int nodes = int.Parse(Console.ReadLine());

            Console.Write("Path: ");
            string[] path = Console.ReadLine().Split('-');
            int sourceNode = int.Parse(path[0]);
            int destinationNode = int.Parse(path[1]);

            Console.Write("Edges: ");
            int edges = int.Parse(Console.ReadLine());

            double[,] graphMatrix = ReadEdgesAndFillMatrix(nodes, edges);

            FindAndPrintReliablePath(graphMatrix, sourceNode, destinationNode);
        }

        private static double[,] ReadEdgesAndFillMatrix(int nodes, int edges)
        {
            double[,] graphMatrix = new double[nodes, nodes];
            for (int i = 0; i < edges; i++)
            {
                string[] parameters = Console.ReadLine().Split(new char[] { ' ', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
                int startNode = int.Parse(parameters[0]);
                int endNode = int.Parse(parameters[1]);
                double weight = double.Parse(parameters[2]);
                double convertedWeight = (weight / 100) == 1 ? 0.9999999999 : (weight / 100);
                graphMatrix[startNode, endNode] = -Math.Log10(convertedWeight);
                graphMatrix[endNode, startNode] = -Math.Log10(convertedWeight); 
            }

            return graphMatrix;
        }

        static List<int> Dijkstra(double[,] graph, int sourceNode, int destinationNode)
        {
            int n = graph.GetLength(0);

            // Initialize the distance[]
            double[] distance = new double[n];
            for (int i = 0; i < n; i++)
            {
                distance[i] = double.MaxValue;
            }
            distance[sourceNode] = 0;

            // Dijkstra's algorithm implemented without priority queue
            var used = new bool[n];
            int?[] previous = new int?[n];
            while (true)
            {
                // Find the nearest unused node from the source
                double minDistance = double.MaxValue;
                int minNode = 0;
                for (int node = 0; node < n; node++)
                {
                    if (!used[node] && distance[node] < minDistance)
                    {
                        minDistance = distance[node];
                        minNode = node;
                    }
                }
                if (minDistance == double.MaxValue)
                {
                    // No min distance node found --> algorithm finished
                    break;
                }

                used[minNode] = true;

                // Improve the distance[0…n-1] through minNode
                for (int i = 0; i < n; i++)
                {
                    if (graph[minNode, i] > 0)
                    {
                        double newDistance = distance[minNode] + graph[minNode, i];
                        if (newDistance < distance[i])
                        {
                            distance[i] = newDistance;
                            previous[i] = minNode;
                        }
                    }
                }
            }

            if (distance[destinationNode] == double.MaxValue)
            {
                // No path found from sourceNode to destinationNode
                return null;
            }

            // Reconstruct the shortest path from sourceNode to destinationNode
            var path = new List<int>();
            int? currentNode = destinationNode;
            while (currentNode != null)
            {
                path.Add(currentNode.Value);
                currentNode = previous[currentNode.Value];
            }
            path.Reverse();
            return path;
        }

        static void FindAndPrintReliablePath(double[,] graph, int sourceNode, int destinationNode)
        {
            var path = Dijkstra(graph, sourceNode, destinationNode);
            if (path == null)
            {
                Console.WriteLine("no path");
            }
            else
            {
                double reliability = 1;
                for (int i = 0; i < path.Count - 1; i++)
                {
                    var temp = Math.Pow(10, -graph[path[i], path[i + 1]]);
                    reliability *= temp;
                }
                var formattedPath = string.Join(" -> ", path);
                Console.WriteLine("Most reliable path reliability: {0}%", Math.Round((reliability * 100), 2));
                Console.WriteLine("{0}", formattedPath);
            }
        }
    }
}
