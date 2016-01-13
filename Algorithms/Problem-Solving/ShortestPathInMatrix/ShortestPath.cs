namespace ShortestPathInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ShortestPath
    {
        private static int[] directions = { 1, 0, 0, 1, 0, -1, -1, 0 };
 
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            var nodes = ReadMatrixAndFillNodes(rows, cols);
            var graph = FillGraphFromNodes(nodes, rows, cols);

            DijkstraAlgorithm(graph, graph.ElementAt(0).Key);

            var path = FindPath(graph, graph.ElementAt((rows * cols) - 1).Key);

            Console.WriteLine("Length: {0}", path.Last().Distance);
            Console.Write("Path: {0}", path[0].Distance);
            for (int i = 1; i < path.Count; i++)
            {
                Console.Write(" {0}", path[i].Distance - path[i - 1].Distance);
            }
        }

        private static Dictionary<Node, List<Edge>> FillGraphFromNodes(Node[] nodes, int rows, int cols)
        {
            var graph = new Dictionary<Node, List<Edge>>();
            for (int i = 0; i < nodes.Length; i++)
            {
                var node = nodes[i];
                graph.Add(node, new List<Edge>());
                for (int d = 0; d < directions.Length; d+=2)
                {
                    int currentRow = node.Row + directions[d];
                    int currentCol = node.Col + directions[d + 1];
                    if (IsInsideMatrix(rows, cols, currentRow, currentCol))
                    {
                        var currentNode = nodes.FirstOrDefault(n => n.Row == currentRow && n.Col == currentCol);
                        graph[node].Add(new Edge(currentNode, currentNode.Distance));
                    }                    
                }
            }

            return graph;
        }

        private static Node[] ReadMatrixAndFillNodes( int rows, int cols)
        {
            var nodes = new Node[rows * cols];
            int index = 0;
            for (int row = 0; row < rows; row++)
            {
                int[] line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    var node = new Node(index, row, col);
                    node.Distance = line[col];
                    nodes[index] = node;
                    index++;
                }
            }
            return nodes;
        }

        private static bool IsInsideMatrix(int rows, int cols, int row, int col)
        {
            return (row >= 0 && row < rows) && (col >= 0 && col < cols);
        }

        public static void DijkstraAlgorithm(Dictionary<Node, List<Edge>> graph, Node sourceNode)
        {
            var queue = new PriorityQueue<Node>();
            int startDist = graph.ElementAt(0).Key.Distance;
            foreach (var node in graph)
            {
                node.Key.Distance = int.MaxValue;
            }
            sourceNode.Distance = startDist;
            queue.Enqueue(sourceNode);

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                if (currentNode.Distance == int.MaxValue)
                {
                    break;
                }

                foreach (var childEdge in graph[currentNode])
                {
                    var newDistance = currentNode.Distance + childEdge.Distance;
                    if (newDistance < childEdge.Node.Distance)
                    {
                        childEdge.Node.Distance = newDistance;
                        childEdge.Node.PreviousNode = currentNode;
                        queue.Enqueue(childEdge.Node);
                    }
                }
            }
        }

        static List<Node> FindPath(Dictionary<Node, List<Edge>> graph, Node node)
        {
            var path = new List<Node>();
            while (node != null)
            {
                path.Add(node);
                node = node.PreviousNode;
            }
            path.Reverse();
            return path;
        }
    }
}
