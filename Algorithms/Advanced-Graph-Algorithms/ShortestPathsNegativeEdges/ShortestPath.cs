namespace ShortestPathsNegativeEdges
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class ShortestPath
    {
        private static int?[] predessecor;

        static void Main()
        {
            Console.Write("Nodes: ");
            int nodes = int.Parse(Console.ReadLine());

            Console.Write("Path: ");
            string[] path = Console.ReadLine().Split(new char[] { ' ', '-' }, StringSplitOptions.RemoveEmptyEntries);
            int sourceNode = int.Parse(path[0]);
            int destinationNode = int.Parse(path[1]);

            Console.Write("Edges: ");
            int edgesCount = int.Parse(Console.ReadLine());

            List<Edge> edges = ReadEdges(edgesCount);
            int[] distance = new int[nodes];

            if (BellmanFord(sourceNode, distance, edges))
            {
                Console.WriteLine("Negative cycle detected: ");
                Console.WriteLine("Path: {0}", string.Join(" -> ", GetPath(destinationNode)));
            }
            else
            {
                PrintBellmanFord(sourceNode, destinationNode, distance);
            }
            
        }

        private static void PrintBellmanFord(int start, int end, int[] distance)
        {
            Console.WriteLine("Distance [{0} -> {1}]: {2}", start, end, distance[end]);
            Console.WriteLine("Path: {0}", string.Join(" -> ", GetPath(end)));
        }

        private static bool BellmanFord(int node, int[] distance, List<Edge> edges)
        {
            predessecor = new int?[distance.Length];
            for (int i = 0; i < distance.Length; i++)
            {
                distance[i] = int.MaxValue;
            }
            distance[node] = 0;

            for (int i = 1; i <= distance.Length - 1; i++)
            {
                foreach (var edge in edges)
	            {
		            int startNode = edge.StartNode;
                    int endNode = edge.EndNode;
                    int weight = edge.Weight;
                    if (distance[startNode] != int.MaxValue && distance[startNode] + weight < distance[endNode])
	                {
		                distance[endNode] = distance[startNode] + weight;
                        predessecor[endNode] = startNode; 
	                }
	            }
            }

            bool isCycle = false;
            foreach (var edge in edges)
            {
                if (distance[edge.StartNode] != int.MaxValue && distance[edge.StartNode] + edge.Weight < distance[edge.EndNode])
                {
                    isCycle = true; 
                }
            }

            
            return isCycle;
        }

        private static List<Edge> ReadEdges(int edgesCount)
        {
            var edges = new List<Edge>();
            for (int i = 0; i < edgesCount; i++)
            {
                string[] parameters = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                int startNode = int.Parse(parameters[0]);
                int endNode = int.Parse(parameters[1]);
                int weight = int.Parse(parameters[2]);
                edges.Add(new Edge(startNode, endNode, weight));
            }

            return edges;
        }

        private static List<int> GetPath(int end)
        {
            var path = new List<int>();
            int? currentNode = end;
            while (currentNode != null)
            {
                path.Add(currentNode.Value);
                currentNode = predessecor[currentNode.Value];
                if (currentNode == end)
                {
                    break;
                }
            }
            path.Reverse();
            return path;
        }
    }
}
