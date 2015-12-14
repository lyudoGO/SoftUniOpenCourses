//Problem 7.Implement a LinkedList<T>
//Implement the data structure singly linked list LinkedList<T> that holds a sequence of linked elements.
//Define two classes:
//•	ListNode<T> holding the value and a pointer to the next element.
//•	LinkedList<T> holding the first element + operations Add(T item), Remove(index), Count,
//IEnumerable<T>, FirstIndexOf(T item), LastIndexOf(T item).
//The LinkedList<T> is very similar to DoublyLinkedList<T> but holds a pointer to the next 
//element only (not to both next and previous element).


namespace _07.ImplementLinkedList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new LinkedList<int>() { 9834, 100, -123, -434, -43434, 555 };
            linkedList.Add(100);
            linkedList.Add(222);
            linkedList.Add(-988);
            linkedList.Add(100);

            Console.WriteLine("Linked list is:");
            Console.WriteLine(string.Join(", ", linkedList));

            linkedList.Remove(5);
            Console.WriteLine("\nAfter remove element at index 5:");
            Console.WriteLine(string.Join(", ", linkedList));

            Console.WriteLine("\nFirst index of 100: {0}", linkedList.FirstIndexOf(100));
            Console.WriteLine("Last index of 100: {0}", linkedList.LastIndexOf(100));
            Console.WriteLine("\nCount of elements: {0}", linkedList.Count);
            Console.WriteLine("\nFirst element in linked list: {0}", linkedList.FirstElement);
        }
    }
}
