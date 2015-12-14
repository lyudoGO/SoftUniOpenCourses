namespace _01.PlayWithTrees
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

        static void Main(string[] args)
        {
            int nodesCount = int.Parse(Console.ReadLine());
            for (int i = 1; i < nodesCount; i++)
            {
                string[] edge = Console.ReadLine().Split(' ');
                int parentValue = int.Parse(edge[0]);
                Tree<int> parentNode = GetTreeNodeByValue(parentValue);
                int childValue = int.Parse(edge[1]);
                Tree<int> childNode = GetTreeNodeByValue(childValue);

                parentNode.Children.Add(childNode);
                childNode.Parent = parentNode;
            }

            int pathSum = int.Parse(Console.ReadLine());
            int subTreeSum = int.Parse(Console.ReadLine());

            var rootNode = FindRootNode();
            var leafNodes = FindAllLeafNodes()
                                .OrderBy(node => node.Value)
                                .Select(node => node.Value);
            var middleNodes = FindAllMiddleNodes()
                                .OrderBy(node => node.Value)
                                .Select(node => node.Value);
            var longestPathNode = FindLongestPathNode(rootNode)
                                 .Reverse()
                                 .Select(node => node.Value);
            var pathsWithGivenSum = FindPathsWithGivenSum(pathSum);
            var subTreesWithGivenSum = FindSubTreesWithGivenSum(subTreeSum);

            Console.WriteLine("Root node: {0}", rootNode.Value);

            Console.WriteLine("Leaf nodes: {0}", string.Join(", ", leafNodes));

            Console.WriteLine("Middle nodes: {0}", string.Join(", ", middleNodes));

            Console.WriteLine("Longest path: {0} (length = {1})", string.Join(" -> ", longestPathNode), longestPathNode.Count());

            Console.WriteLine("Paths of sum = {0}", pathSum);
            foreach (var path in pathsWithGivenSum)
            {
                Console.WriteLine("{0}", string.Join(" -> ", path.Select(node => node.Value)));
            }

            Console.WriteLine("Subtress of sum = {0}", subTreeSum);
            foreach (var tree in subTreesWithGivenSum)
            {
                Console.WriteLine("{0}", string.Join(" + ", tree.Select(node => node.Value)));
            }
        }

        private static IList<List<Tree<int>>> FindSubTreesWithGivenSum(int subTreeSum)
        {
            IList<List<Tree<int>>> subTrees = new List<List<Tree<int>>>();
            foreach (var node in nodeByValue)
            {
                var subTree = FindSubTree(node.Value);
                if (subTree.Sum(n => n.Value) == subTreeSum)
                {
                    subTrees.Add(subTree);
                }
            }

            return subTrees;
        }

        private static List<Tree<int>> FindSubTree(Tree<int> node)
        {
            List<Tree<int>> subTree = new List<Tree<int>>();
            subTree.Add(node);
            foreach (var currentNode in node.Children)
            {
                subTree.Add(currentNode);
            }

            return subTree;
        }

        private static IList<List<Tree<int>>> FindPathsWithGivenSum(int pathSum)
        {
            IList<List<Tree<int>>> paths = new List<List<Tree<int>>>();
            var leafNodes = FindAllLeafNodes();
            foreach (var leafNode in leafNodes)
            {
                List<Tree<int>> currentPathToRoot = FindPathToRoot(leafNode);
                long currentPathSum = currentPathToRoot.Sum(node => node.Value);
                if (currentPathSum == pathSum)
                {
                    currentPathToRoot.Reverse();
                    paths.Add(currentPathToRoot);
                }
            }

            return paths;
        }

        private static List<Tree<int>> FindPathToRoot(Tree<int> leafNode)
        {
            List<Tree<int>> pathToRoot = new List<Tree<int>>();
            while (leafNode != null)
            {
                pathToRoot.Add(leafNode);
                leafNode = leafNode.Parent;
            }

            return pathToRoot;
        }

        private static IList<Tree<int>> FindLongestPathNode(Tree<int> rootNode)
        {
            IList<Tree<int>> longestPathNode = new List<Tree<int>>();
            foreach (var child in rootNode.Children)
            {
                IList<Tree<int>> currentPathNode = FindLongestPathNode(child);
                if (currentPathNode.Count > longestPathNode.Count)
                {
                    longestPathNode = currentPathNode;
                }
            }
            longestPathNode.Add(rootNode);

            return longestPathNode;
        }

        private static Tree<int> GetTreeNodeByValue(int value)
        {
            if (!nodeByValue.ContainsKey(value))
            {
                nodeByValue[value] = new Tree<int>(value);
            }

            return nodeByValue[value];
        }

        private static Tree<int> FindRootNode()
        {
            var rootNode = nodeByValue.Values.FirstOrDefault(node => node.Parent == null);

            return rootNode;
        }

        private static IEnumerable<Tree<int>> FindAllMiddleNodes()
        {
            var middleNodes = nodeByValue.Values
                                         .Where(node => node.Children.Count > 0 && node.Parent != null);

            return middleNodes;
        }

        private static IEnumerable<Tree<int>> FindAllLeafNodes()
        {
            var leafNodes = nodeByValue.Values
                                       .Where(node => node.Children.Count == 0 && node.Parent != null);

            return leafNodes;
        }
    }

}
