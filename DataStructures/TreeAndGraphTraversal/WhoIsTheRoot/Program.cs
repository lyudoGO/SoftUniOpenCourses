namespace WhoIsTheRoot
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        private static List<int>[] tree = new List<int>[] {};
        private static bool[] hasParent;

        static void Main()
        {
            tree = ReadTree();
            FindRootNode();
        }

        private static void FindRootNode()
        {
            int hasParents = 0;
            int hasNoParents = 0;
            for (int i = 0; i < hasParent.Length; i++)
            {
                if (hasParent[i] == true)
                {
                    hasParents++;
                }
                else
                {
                    hasNoParents++;
                }
            }

            if (hasParents == hasParent.Count() && hasNoParents == 0)
            {
                Console.WriteLine("No root");
            }
            else if (hasParents < hasParent.Count() && hasNoParents > 1)
            {
                Console.WriteLine("Multiple root nodes!");
            }
            else if (hasNoParents == 1)
            {
                int root = Array.FindIndex(hasParent, e => e == false);

                Console.WriteLine(root);
            }
        }

        private static List<int>[] ReadTree()
        {
            int numberOfNodes = int.Parse(Console.ReadLine());
            int numberOfEdges = int.Parse(Console.ReadLine());
            var tree = new List<int>[numberOfEdges];
            hasParent = new bool[numberOfNodes];

            for (int i = 0; i < numberOfEdges; i++)
            {
                var edge = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                tree[i] = edge.Select(int.Parse).ToList();
                var childNode = tree[i][1];
                hasParent[childNode] = true;
            }

            return tree;
        }
    }
}