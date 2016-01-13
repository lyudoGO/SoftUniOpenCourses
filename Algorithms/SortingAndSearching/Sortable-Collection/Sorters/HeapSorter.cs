namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class HeapSorter<T> : ISorter<T> where T : IComparable<T>
    {
        private BinaryHeap<T> heapArray;

        public void Sort(List<T> collection)
        {
            this.HeapSort(collection);
        }

        private void HeapSort(List<T> collection)
        {
            heapArray = new BinaryHeap<T>(collection);
            int index = 0;
            while (heapArray.Count > 0)
            {
                var currentElement = heapArray.ExtractMin();
                collection[index] = currentElement;
                index++;
            }
        }

        internal class BinaryHeap<K> where K : IComparable<K>
        {
            private List<K> heap;

            public BinaryHeap(List<K> elements)
            {
                this.heap = new List<K>(elements);
                for (int i = this.heap.Count / 2; i >= 0; i--)
                {
                    this.HeapifyDown(i);
                }
            }

            public int Count
            {
                get
                {
                    return this.heap.Count;
                }
            }

            public K ExtractMin()
            {
                var min = this.heap[0];
                this.heap[0] = this.heap[this.Count - 1];
                this.heap.RemoveAt(this.Count - 1);
                if (this.heap.Count > 0)
                {
                    this.HeapifyDown(0);
                }

                return min;
            }

            public K PeekMin()
            {
                var min = this.heap[0];
                return min;
            }

            public void Insert(K node)
            {
                this.heap.Add(node);
                this.HeapifyUp(this.heap.Count - 1);
            }

            private void HeapifyDown(int i)
            {
                var left = 2 * i + 1;
                var right = 2 * i + 2;
                var smallest = i;
                if (left < this.heap.Count && this.heap[left].CompareTo(this.heap[smallest]) < 0)
                {
                    smallest = left;
                }
                if (right < this.heap.Count && this.heap[right].CompareTo(this.heap[smallest]) < 0)
                {
                    smallest = right;
                }
                if (smallest != i)
                {
                    K old = this.heap[i];
                    this.heap[i] = this.heap[smallest];
                    this.heap[smallest] = old;
                    HeapifyDown(smallest);
                }
            }

            private void HeapifyUp(int i)
            {
                var parent = (i - 1) / 2;
                while (i > 0 && this.heap[i].CompareTo(this.heap[parent]) < 0)
                {
                    K old = this.heap[i];
                    this.heap[i] = this.heap[parent];
                    this.heap[parent] = old;

                    i = parent;
                    parent = (i - 1) / 2;
                }
            }
        }
    }
}
