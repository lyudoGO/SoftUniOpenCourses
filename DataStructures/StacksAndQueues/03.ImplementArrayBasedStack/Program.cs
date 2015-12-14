namespace _03.ImplementArrayBasedStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var arr = new ArrayStack<int>();

            arr.Push(101);
            arr.Push(1001);
            arr.Push(2101);
            arr.Push(21001);

            var newArr = arr.ToArray();
            Console.WriteLine(string.Join(", ", newArr));

            while(arr.Count > 0)
            {
                Console.WriteLine(arr.Pop());
            }

            
            Console.WriteLine(arr.Count);
        }
    }
}
