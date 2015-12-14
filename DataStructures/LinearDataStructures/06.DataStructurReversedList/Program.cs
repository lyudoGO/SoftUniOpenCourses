//Problem 6.Implement the Data Structure ReversedList<T>
//Implement a data structure ReversedList<T> that holds a sequence of elements of 
//generic type T. It should hold a sequence of items in reversed order. 
//The structure should have some capacity that grows twice when it is filled. 
//The reversed list should support the following operations:
//•	Add(T item)  adds an element to the sequence (grow twice the underlying array to 
//extend its capacity in case the capacity is full)
//•	Count  returns the number of elements in the structure
//•	Capacity  returns the capacity of the underlying array holding the elements of 
//the structure
//•	this[index]  the indexer should access the elements by index (in range 0 … Count-1)
//in the reverse order of adding
//•	Remove(index)  removes an element by index (in range 0 … Count-1) in the reverse order of adding
//•	IEnumerable<T>  implement an enumerator to allow iterating over the elements in a foreach loop in
//a reversed order of their addition
//Hint: you can keep the elements in the order of their adding, by access them in reversed order
//(from end to start).


namespace _06.DataStructurReversedList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            var array = new ReversedList<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };

            Console.WriteLine("Original array is: ");
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n\nAdding element 100 to array: ");
            array.Add(100);
            Console.WriteLine(string.Join(" ", array));

            Console.WriteLine("Capacity = {0}", array.Capacity);
            Console.WriteLine("Count = {0}", array.Count);

            Console.WriteLine("\nRemove {0} at 0 index in reversed array:", array[0]);
            array.Remove(0);

            Console.WriteLine(string.Join(" ", array));
        }
    }
}
