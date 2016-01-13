namespace ModifiedKruskalAlgorithm
{
    using System;
    using System.Collections.Generic;

    using System.Linq;

    class KruskalAlgorithm
    {
        static void Main()
        {
            Console.Write("Nodes: ");
            int nodes = int.Parse(Console.ReadLine());
            Console.Write("Edges: ");
            int edges = int.Parse(Console.ReadLine());

            var tree = new Dictionary<int, List<int>>();
            List<Edge> graphEdges = ReadEdges(edges);

            var minimumSpanningForest = Kruskal(nodes, graphEdges, tree);

            Console.WriteLine("Minimum spanning forest weight: " + minimumSpanningForest.Sum(e => e.Weight));
            foreach (var edge in minimumSpanningForest)
            {
                Console.WriteLine(edge);
            }
        }

        private static List<Edge> ReadEdges(int edges)
        {
            var graphEdges = new List<Edge>();
            for (int i = 0; i < edges; i++)
            {
                string line = Console.ReadLine();
                string[] parameters = line.Split(new char[] { ' ', ',', '-' }, StringSplitOptions.RemoveEmptyEntries);
                int startNode = int.Parse(parameters[0]);
                int endNode = int.Parse(parameters[1]);
                int weight = int.Parse(parameters[2]);

                var edge = new Edge(startNode, endNode, weight);
                graphEdges.Add(edge);
            }

            return graphEdges;
        }

        static List<Edge> Kruskal(int nodes, List<Edge> edges, Dictionary<int, List<int>> tree)
        {
            edges.Sort();
    
            // Initialize parents
            var parent = new int[nodes];
            for (int i = 0; i < nodes; i++)
            {
                parent[i] = i;
                tree.Add(i, new List<int>());
            }

            // Kruskal's algorithm
            var spanningTree = new List<Edge>();
            foreach (var edge in edges)
            {
                int rootStartNode = parent[edge.StartNode];// FindRoot(edge.StartNode, parent);
                int rootEndNode = parent[edge.EndNode];//FindRoot(edge.EndNode, parent);
                if (rootStartNode != rootEndNode)
                {
                    spanningTree.Add(edge);
                    // Union (merge) the trees
                    if (tree[rootEndNode].Count > tree[rootStartNode].Count)
                    {
                        Merge(rootEndNode, rootStartNode, parent, tree);
                    }
                    else
                    {
                        Merge(rootStartNode, rootEndNode, parent, tree);
                    }
                    //parent[rootStartNode] = rootEndNode;
                }
            }

            return spanningTree;
        }

        private static void Merge(int startNode, int endNode, int[] parent, Dictionary<int, List<int>> tree)
        {
            tree[startNode].Add(endNode);
            parent[endNode] = startNode;
            foreach (var child in tree[endNode])
            {
                tree[startNode].Add(child);
                parent[child] = startNode;
            }

            tree[endNode] = new List<int>();
        }

        //static int FindRoot(int node, int[] parent)
        //{
        //    // Find the root parent for the node
        //    int root = node;
        //    while (parent[root] != root)
        //    {
        //        root = parent[root];
        //    }

        //    // Optimize (compress) the path from node to root
        //    while (node != root)
        //    {
        //        var oldParent = parent[node];
        //        parent[node] = root;
        //        node = oldParent;
        //    }

        //    return root;
        //}
    }
}
