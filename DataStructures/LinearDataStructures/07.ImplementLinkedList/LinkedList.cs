namespace _07.ImplementLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
    {
        private class ListNode<K>
        {
            public ListNode(K value)
            {
                this.Value = value;
                this.NextNode = null;
            }

            public K Value { get; private set; }

            public ListNode<K> NextNode { get; set; }
        }

        private ListNode<T> head;
        private ListNode<T> tail;
        private int count;

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public T FirstElement 
        {
            get { return this.head.Value; } 
 
        }

        public int Count 
        {
            get { return this.count; } 
        }

        public void Add(T item)
        {
            if (this.head == null)
            {
                this.head = new ListNode<T>(item);
                this.tail = this.head;
            }
            else
            {
                var newNode = new ListNode<T>(item);
                this.tail.NextNode = newNode;
                this.tail = newNode;
            }
            this.count++;
        }

        public T Remove(int index)
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentOutOfRangeException("Invalid index: " + index);
            }

            int currentIndex = 0;
            ListNode<T> currentNode = this.head;
            ListNode<T> previousNode = null;

            while (currentIndex < index)
            {
                previousNode = currentNode;
                currentNode = currentNode.NextNode;
                currentIndex++;
            }

            this.count--;
            if (this.count == 0)
            {
                this.head = null;
            }
            else if (previousNode == null)
            {
                this.head = currentNode.NextNode;
            }
            else
            {
                previousNode.NextNode = currentNode.NextNode;
            }

            ListNode<T> lastNode = null;

            if (this.head != null)
            {
                lastNode = this.head;
                while (lastNode.NextNode != null)
                {
                    lastNode = lastNode.NextNode;
                }
            }

            this.tail = lastNode;

            return currentNode.Value;
        }

        public int FirstIndexOf(T item)
        {
            var currentNode = this.head;
            int index = 0;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item) )
                {
                    return index;
                }
                currentNode = currentNode.NextNode;
                index++;
            }

            return -1;
        }

        public int LastIndexOf(T item)
        {
            var currentNode = this.head;
            List<int> indexes = new List<int>();
            int index = 0;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    indexes.Add(index);
                }
                currentNode = currentNode.NextNode;
                index++;
            }

            if (indexes.Count > 0)
            {
                return indexes[indexes.Count - 1];
            }

            return -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}