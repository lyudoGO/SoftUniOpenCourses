namespace CyclesInGraph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CraphCycles
    {
        private static Dictionary<char, List<char>> graph = new Dictionary<char, List<char>>();

        static void Main()
        {
            ReadGraphFromConsole();
            TopologicalSorting();
        }

        private static void TopologicalSorting()
        {
            // Calculate the predecessorsCount
            var predecessorsCount = new Dictionary<char, int>();
            foreach (var node in graph.Keys)
            {
                if (!predecessorsCount.ContainsKey(node))
                {
                    predecessorsCount.Add(node, 0);
                }
                foreach (var childNode in graph[node])
                {
                    if (!predecessorsCount.ContainsKey(childNode))
                    {
                        predecessorsCount.Add(childNode, 0);
                    }
                    predecessorsCount[childNode]++;
                }
            }

            // Topological sorting: source removal algorithm
            bool nodeRemoved = true;
            while (nodeRemoved)
            {
                nodeRemoved = false;
                foreach (var node in predecessorsCount.Keys)
                {
                    if (predecessorsCount[node] <= 1)// && !isRemoved[node - 'A'])
                    {
                        foreach (var childNode in graph[node])
                        {
                            if (predecessorsCount.ContainsKey(childNode))
                            {
                                predecessorsCount[childNode]--;
                            }
                                
                        }
                        predecessorsCount.Remove(node);
                        nodeRemoved = true;
                        break;
                    }
                }
            }

            if (predecessorsCount.Count == 0)
            {
                Console.WriteLine("Acyclic: Yes");
            }
            else
            {
                Console.WriteLine("Acyclic: No");
            }
        }

        private static void ReadGraphFromConsole()
        {
            Console.WriteLine("Please, enter a graph edges and press Enter: ");
            string inputLine = Console.ReadLine();

            while (inputLine != string.Empty)
            {
                string[] parameters = inputLine.Split(new char[] { ' ', '-', ',' }, StringSplitOptions.RemoveEmptyEntries);
                char node = char.Parse(parameters[0]);
                char childNode = char.Parse(parameters[1]);

                if (!graph.ContainsKey(node))
                {
                    graph[node] = new List<char>();
                }
                graph[node].Add(childNode);

                if (!graph.ContainsKey(childNode))
                {
                    graph[childNode] = new List<char>();
                }
                graph[childNode].Add(node);

                inputLine = Console.ReadLine();
            }
        }
    }
}