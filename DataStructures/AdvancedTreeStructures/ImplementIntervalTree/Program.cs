namespace ImplementIntervalTree
{
    using System;

    public class Program
    {
        static void Main()
        {
            var tree = new IntervalTree<int>();
            tree.Insert(1, 11);
            tree.Insert(5, 9);
            tree.Insert(10, 46);
            tree.Insert(10, 45);
            tree.Insert(-345, 0);
            
            tree.Insert(0, 23);
            tree.Insert(0, 2342343);
            tree.Insert(0, 23);
            
            Console.WriteLine(tree);
        }
    }
}
