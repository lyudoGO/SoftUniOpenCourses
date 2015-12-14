namespace LongestPathInATree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static Dictionary<int, List<int>> treeNodes = new Dictionary<int,List<int>>();
        private static Dictionary<int, int?> parents = new Dictionary<int, int?>();

        static void Main()
        {
            int numberOfNodes = int.Parse(Console.ReadLine());
            int numberOfEdges = int.Parse(Console.ReadLine());

            ReadTreeNodes(numberOfEdges);

            int root = FindRoot();
            List<int> leafs = FindAllLeafs();
            List<List<int>> pathsToRoot = FindAllPathsToRoot(leafs, root);
            int longestPathBySum = FindSumOfLongestPath(pathsToRoot, root);

            Console.WriteLine(longestPathBySum);
        }

        private static int FindSumOfLongestPath(List<List<int>> pathsToRoot, int root)
        {
            int sum = 0;
            
            for (int i = 0; i < pathsToRoot.Count; i++)
            {
                for (int j = i + 1; j < pathsToRoot.Count; j++)
                {
                    int currentSum = pathsToRoot[i].Sum() + pathsToRoot[j].Sum() - root;
                    if (currentSum > sum)
                    {
                        sum = currentSum;
                    }
                }
            }

            return sum;
        }

        private static List<List<int>> FindAllPathsToRoot(List<int> leafs, int root)
        {
            var pathsToRoot = new List<List<int>>();
            foreach (var leaf in leafs)
            {
                var currentLeaf = leaf;
                var currentPathToRoot = new List<int>();

                while (currentLeaf != root)
                {
                    currentPathToRoot.Add(currentLeaf);
                    currentLeaf = parents[currentLeaf].Value;
                }
                currentPathToRoot.Add(currentLeaf);

                pathsToRoot.Add(currentPathToRoot);
            }

            return pathsToRoot;
        }

        private static List<int> FindAllLeafs()
        {
            var leafs = treeNodes.Where(k => k.Value.Count == 0).Select(n => n.Key).ToList();

            return leafs;
        }

        private static int FindRoot()
        {
            var root = parents.FirstOrDefault(p => p.Value == null);

            return root.Key;
        }

        private static void ReadTreeNodes(int numberOfEdges)
        {
            for (int i = 0; i < numberOfEdges; i++)
            {
                var currentEdge = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int parent = int.Parse(currentEdge[0]);
                int child = int.Parse(currentEdge[1]);

                if (!treeNodes.ContainsKey(parent))
                {
                    treeNodes[parent] = new List<int> { child };
                }
                else
                {
                    treeNodes[parent].Add(child);
                }

                if (!treeNodes.ContainsKey(child))
                {
                    treeNodes[child] = new List<int>();
                }

                parents[child] = parent;

                if (!parents.ContainsKey(parent))
                {
                    parents[parent] = null;
                }
            }
        }
    }
}
