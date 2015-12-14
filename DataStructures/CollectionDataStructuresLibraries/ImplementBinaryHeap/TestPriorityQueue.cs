namespace ImplementBinaryHeap
{
    using System;
    using System.Collections.Generic;

    class TestPriorityQueue
    {
        static void Main()
        {
            var timeQueue = new PriorityQueue<DateTime>();
            timeQueue.Enqueue(new DateTime(2015, 8, 18));
            timeQueue.Enqueue(new DateTime(2014, 8, 18));
            timeQueue.Enqueue(new DateTime(2015, 1, 11));
            timeQueue.Enqueue(new DateTime(2015, 5, 21));
            timeQueue.Enqueue(new DateTime(2014, 12, 31));

            Console.WriteLine("The first element is: {0}", timeQueue.Peek());
            Console.WriteLine("Priority queue is: ");
            Console.WriteLine(timeQueue.ToString());

            var intQueue = new PriorityQueue<int>();
            intQueue.Enqueue(1);
            intQueue.Enqueue(1233434);
            intQueue.Enqueue(56);
            intQueue.Enqueue(-67);
            intQueue.Enqueue(23);
            intQueue.Enqueue(999);
            intQueue.Enqueue(2);

            Console.WriteLine("\nThe first element is: {0}", intQueue.Peek());
            Console.WriteLine("Priority queue is: ");
            Console.WriteLine(intQueue.ToString());

            intQueue.Dequeue();
            Console.WriteLine("\nAfter remove first element.The new one is: {0}", intQueue.Peek());
            Console.WriteLine("Priority queue is: ");
            Console.WriteLine(intQueue.ToString());
        }
    }
}
