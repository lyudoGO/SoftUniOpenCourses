namespace ImplementAATree  
{
    using System;

    public class TestAATree
    {
        static void Main()
        {
            var aaTree = new AATree<int>();
            Console.WriteLine("The AA tree created.");
            var nums = new[] { -5, 20, 14, 11, 8, -3, 111, 7, 100, -55 };
            for (int i = 0; i < nums.Length; i++)
            {
                AddNumber(aaTree, nums[i]);
            }
            
            Console.WriteLine("Current root is: {0}", aaTree.Root.Value);
            aaTree.Remove(20);
            Console.WriteLine("When we remove the root, the new one will be: {0}", aaTree.Root.Value);
        }

        public static void AddNumber(AATree<int> tree, int value)
        {
            tree.Add(value);
            Console.WriteLine("Added " + value);

            DisplayTree(tree.Root, string.Empty);
            Console.WriteLine("----------------------");
        }

        private static void DisplayTree(AATree<int>.Node node, string intend)
        {
            Console.WriteLine(intend + node.Value + " (level:" + node.Level + ")");
            if (node.LeftChild.Level != 0)
            {
                DisplayTree(node.LeftChild, intend + "  ");
            }
            if (node.RightChild.Level != 0)
            {
                DisplayTree(node.RightChild, intend + "  ");
            }
        }
    }
}
