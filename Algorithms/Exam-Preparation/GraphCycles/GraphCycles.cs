namespace GraphCycles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class GraphCycles
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            SortedDictionary<int, SortedSet<int>> graph = ReadGraphFromConsole(n);
            FindThreeCycles(graph);
        }

        private static void FindThreeCycles(SortedDictionary<int, SortedSet<int>> graph)
        {
     		bool cyclesFound = false;

		    foreach (var nodeOne in graph.Keys)
		    {
			    foreach (var nodeTwo in graph[nodeOne].Where(n => n > nodeOne))
			    {
				    foreach (var nodeThree in graph[nodeTwo].Where(n => n > nodeOne))
				    {
					    if (graph[nodeThree].Contains(nodeOne) && nodeTwo != nodeThree)
					    {
						    Console.WriteLine("{{{0} -> {1} -> {2}}}", nodeOne, nodeTwo, nodeThree);
						    cyclesFound = true;
					    }
				    }
			    }
		    }

		    if (!cyclesFound)
		    {
			    Console.WriteLine("No cycles found");
		    }
        }

        private static SortedDictionary<int, SortedSet<int>> ReadGraphFromConsole(int n)
        {
            SortedDictionary<int, SortedSet<int>> graph = new SortedDictionary<int, SortedSet<int>>();
            for (int i = 0; i < n; i++)
            {
                string[] parameters = Console.ReadLine().Split(new char[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                int node = int.Parse(parameters[0]);
                graph[node] = new SortedSet<int>();
                for (int v = 1; v < parameters.Length; v++)
                {
                    graph[node].Add(int.Parse(parameters[v]));
                }
            }

            return graph;
        }
    }
}
