namespace BrakeCycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BreakCycles;

    class BreakCycle
    {
        private static Dictionary<char, List<char>> graph = new Dictionary<char, List<char>>();
        private static List<Edge> graphEdges = new List<Edge>();
        private static HashSet<char> visited;

        static void Main()
        {
            Console.WriteLine("Please, enter agjacency of list and press Enter: ");
            ReadGraph();
            BreakCycles();
            PrintRemovedEdges();
        }

        private static void BreakCycles()
        {
            foreach (var edge in graphEdges)
            {
                if (!graph[edge.EdgeFrom].Contains(edge.EdgeTo) || !graph[edge.EdgeTo].Contains(edge.EdgeFrom))
                {
                    continue;
                }
                visited = new HashSet<char>();
                graph[edge.EdgeFrom].Remove(edge.EdgeTo);
                graph[edge.EdgeTo].Remove(edge.EdgeFrom);

                BFS(edge.EdgeFrom);

                if (visited.Contains(edge.EdgeTo))
                {
                    edge.IsRemoved = true;
                }
                else
                {
                    graph[edge.EdgeFrom].Add(edge.EdgeTo);
                    graph[edge.EdgeTo].Add(edge.EdgeFrom);
                }
            }
        }

        private static void ReadGraph()
        {
            string line = Console.ReadLine();
            while (line != string.Empty)
            {
                string[] parameters = line.Split(new char[] { ' ', '-', '>', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);
                char node = char.Parse(parameters[0]);

                if (!graph.ContainsKey(node))
                {
                    graph.Add(node, new List<char>());
                }

                for (int i = 1; i < parameters.Length; i++)
                {
                    char childNode = char.Parse(parameters[i]);
                    graph[node].Add(childNode);
                    Edge currentEdge = new Edge(node, childNode);
                    graphEdges.Add(currentEdge);
                }

                line = Console.ReadLine();
            }

            graphEdges.Sort();
        }

        private static void BFS(char node)
        {
            var nodes = new Queue<char>();

            if (!visited.Contains(node))
            {
                visited.Add(node);
            }

            nodes.Enqueue(node);

            while (nodes.Count > 0)
            {
                char currentNode = nodes.Dequeue();

                foreach (var childNode in graph[currentNode])
                {
                    if (!visited.Contains(childNode))
                    {
                        visited.Add(childNode);
                        nodes.Enqueue(childNode);
                    }
                }
            }
        }

        private static void PrintRemovedEdges()
        {
            Console.WriteLine("Edges to remove: {0}", graphEdges.Count(e => e.IsRemoved == true));
            foreach (var edge in graphEdges)
            {
                if (edge.IsRemoved)
                {
                    Console.WriteLine(edge.ToString());
                }
            }
        }
    }
}
