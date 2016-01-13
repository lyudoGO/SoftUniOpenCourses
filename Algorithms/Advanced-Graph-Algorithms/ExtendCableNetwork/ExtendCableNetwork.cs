namespace ExtendCableNetwork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ExtendCableNetwork
    {
        private static List<Edge> spanningTreeEdges;
        private static HashSet<int> spanningTreeNodes;
        private static Dictionary<int, List<Edge>> graph;
        private static int totalBudget = 0;

        static void Main()
        {
            Console.Write("Budget: ");
            int budget = int.Parse(Console.ReadLine());

            Console.Write("Nodes: ");
            int countNodes = int.Parse(Console.ReadLine());

            Console.Write("Egdes: ");
            int countEdges = int.Parse(Console.ReadLine());
            ReadEdgesAndFillTree(countNodes, countEdges);

            // Start Prim's algorithm from each node not still in the spanning tree
            foreach (var startNode in graph.Keys)
            {
                if (!spanningTreeNodes.Contains(startNode))
                {
                    Prim(startNode, budget);
                }
            }

            PrintEdges(totalBudget);
        }

        private static void ReadEdgesAndFillTree(int countNodes, int countEdges)
        {
            spanningTreeEdges = new List<Edge>();
            spanningTreeNodes = new HashSet<int>();
            graph = new Dictionary<int, List<Edge>>();
            int count = 0;
            while (count < countEdges)
            {
                string line = Console.ReadLine();
                string[] parameters = line.Split(new char[] { ' ', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
                int startNode = int.Parse(parameters[0]);
                int endNode = int.Parse(parameters[1]);
                int cost = int.Parse(parameters[2]);
                var edge = new Edge(startNode, endNode, cost);
                if (parameters.Length == 4)
                {
                    //spanningTreeNodes.Add(startNode);
                    //spanningTreeNodes.Add(endNode);
                    edge.IsConnected = true;
                }

                if (!graph.ContainsKey(startNode))
                {
                    graph.Add(startNode, new List<Edge>());
                }
                graph[startNode].Add(edge);
                if (!graph.ContainsKey(endNode))
                {
                    graph.Add(endNode, new List<Edge>());
                }
                graph[endNode].Add(edge);

                count++;
            }

        }

        private static void Prim(int startNode, int budget)
        {
            var priorityQueue = new BinaryHeap<Edge>();
            foreach (var childEdge in graph[startNode])
            {
                if (!childEdge.IsConnected)
                {
                    priorityQueue.Enqueue(childEdge);
                }
            }

            spanningTreeNodes.Add(startNode);

            while (priorityQueue.Count > 0)
            {
                var smallestEdge = priorityQueue.ExtractMin();

                if (spanningTreeNodes.Contains(smallestEdge.StartNode) ^ spanningTreeNodes.Contains(smallestEdge.EndNode))
                {
                    if (totalBudget + smallestEdge.Cost <= budget)
                    {
                        totalBudget += smallestEdge.Cost;
                        smallestEdge.IsConnected = true;
                        spanningTreeEdges.Add(smallestEdge);
                    }
                    // Attach the smallest edge to the minimum spanning tree (MST)
                    var nonTreeNode = spanningTreeNodes.Contains(smallestEdge.StartNode) ? smallestEdge.EndNode : smallestEdge.StartNode;
                    spanningTreeNodes.Add(nonTreeNode);
                    foreach (var childEdge in graph[nonTreeNode])
                    {
                          if (!childEdge.IsConnected)
                          {
                            priorityQueue.Enqueue(childEdge);
                          }
                    }
                }
            }
        }

        private static void PrintEdges(int currentBudget)
        {
            Console.WriteLine();
            foreach (var edge in spanningTreeEdges)
            {
                Console.WriteLine(edge);
            }
            Console.WriteLine("Budget used: {0}", currentBudget);
        }
    }
}
