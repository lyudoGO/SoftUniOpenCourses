namespace DistanceBetweenVertices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Graph
    {
        private List<int>[] graph;
        private int[] edgeTo;
        private bool[] visited;

        public Graph(List<int>[] graph)
        {
            this.graph = graph;
        }

        public int GetDistance(int from, int to)
        {
            this.edgeTo = new int[graph.Length];
            this.visited = new bool[graph.Length];

            BFS(from);
            int distance = PathFromTo(from, to).Count() - 1;

            return distance;
        }

        private void BFS(int startNode)
        {
            var nodes = new Queue<int>();

            this.visited[startNode] = true;
            nodes.Enqueue(startNode);

            while (nodes.Count > 0)
            {
                int currentNode = nodes.Dequeue();

                foreach (var childNode in graph[currentNode])
                {
                    if (!this.visited[childNode])
                    {
                        this.edgeTo[childNode] = currentNode;
                        this.visited[childNode] = true;
                        nodes.Enqueue(childNode);
                    }
                }
            }
        }

        private IEnumerable<int> PathFromTo(int from, int to)
        {
            Stack<int> path = new Stack<int>();
            if (!this.visited[to])
            {
                return path;
            }
            
            for (int i = to; i != from; i = this.edgeTo[i])
            {
                path.Push(i);
            }
                
            path.Push(from);
            return path;
        }
    }
}
