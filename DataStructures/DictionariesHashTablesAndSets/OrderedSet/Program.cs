namespace OrderedSet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var newSet = new OrderedSet<int>();
            newSet.Add(17);
            newSet.Add(9);
            newSet.Add(12);
            newSet.Add(19);
            newSet.Add(6);
            newSet.Add(25);
            newSet.Add(18);

            Console.WriteLine("Print all values in binary tree in ascending order:");
            foreach (var item in newSet)
            {
                Console.WriteLine(item);
            }

            newSet.Remove(18);

            Console.WriteLine("Print all values in binary tree in ascending order after removed value 18:");
            foreach (var item in newSet)
            {
                Console.WriteLine(item);
            }
        }
    }
}
