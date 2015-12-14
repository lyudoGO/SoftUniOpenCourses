namespace ImplementBinaryHeap
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> data;

        public PriorityQueue()
        {
            this.data = new List<T>();
        }

        public int Count 
        {
            get { return this.data.Count; } 
        }

        public T Peek()
        {
            T frontItem = this.data[0];
            return frontItem;
        }

        public void Enqueue(T item)
        {
            this.data.Add(item);
            int childIndex = this.data.Count - 1;
            while (childIndex > 0)
            {
                int parentIndex = (childIndex - 1) / 2;
                if (data[childIndex].CompareTo(data[parentIndex]) >= 0)
                {
                    break;
                }
                T tempItem = this.data[childIndex];
                this.data[childIndex] = this.data[parentIndex];
                this.data[parentIndex] = tempItem;
                childIndex = parentIndex;
            }
        }

        public T Dequeue()
        {
            if (this.data.Count == 0)
            {
                throw new ArgumentException("The queue is empty!");
            }
            int lastIndex = this.data.Count - 1;
            T frontItem = this.data[0];
            this.data[0] = this.data[lastIndex];
            this.data.RemoveAt(lastIndex);

            --lastIndex;
            int parentIndex = 0;
            while (true)
            {
                int leftChildIndex = parentIndex * 2 + 1;
                if (leftChildIndex > lastIndex)
                {
                    break;
                }
                int rightChild = leftChildIndex + 1;
                if (rightChild <= lastIndex && this.data[rightChild].CompareTo(this.data[leftChildIndex]) < 0)
                {
                    leftChildIndex = rightChild;
                }
                if (this.data[parentIndex].CompareTo(this.data[leftChildIndex]) <= 0)
                {
                    break;
                }
                T tempItem = this.data[parentIndex];
                this.data[parentIndex] = this.data[leftChildIndex];
                this.data[leftChildIndex] = tempItem;
            }

            return frontItem;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < this.data.Count; i++)
            {
                result.AppendLine(i + " -> " + this.data[i].ToString());
            }

            return result.ToString();
        }
    }
}
