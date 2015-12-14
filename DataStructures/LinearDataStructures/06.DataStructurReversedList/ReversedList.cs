namespace _06.DataStructurReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class ReversedList<T> : IEnumerable<T>
    {
        private const int CAPACITY = 8;

        private T[] array;
        private int usedIndex;

        public ReversedList()
        {
            this.array = new T[CAPACITY];
            this.usedIndex = 0;
        }

        public void Add(T element)
        {
            if (this.usedIndex == this.array.Length)
            {
                AutoGrowFunction();
            }

            this.array[this.usedIndex] = element;
            this.usedIndex++;
        }

        private void AutoGrowFunction()
        {
            int newCapacity = this.array.Length * 2;
            T[] newArray = new T[newCapacity];

            for (int i = 0; i < this.array.Length; i++)
            {
                newArray[i] = this.array[i];
            }

            this.array = newArray;
        }

        public int Count 
        { 
            get { return this.usedIndex; }
        }

        public int Capacity 
        {
            get { return this.array.Length; }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.usedIndex)
                {
                    throw new IndexOutOfRangeException("Invalid index: " + index);
                }
                T result = this.array[this.usedIndex - 1 - index];

                return result;
            }
        }

        public void Remove(int index) 
        {
            if (index < 0 || index > this.usedIndex)
            {
                throw new ArgumentOutOfRangeException("You entered a invalid index: " + index);
            }

            int indexOfRemoved = this.usedIndex - 1 - index;

            for (int i = indexOfRemoved; i < this.usedIndex - 1; i++)
            {
                this.array[i] = this.array[i + 1];
            }
            this.array[this.usedIndex - 1] = default(T);
            this.usedIndex--;
        }


        public IEnumerator<T> GetEnumerator()
        {
            int index = this.usedIndex - 1;
            
            while (index > -1)
            {
                var currentElement = this.array[index];
                yield return currentElement;
                index--;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
