namespace _07.LinkedQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LinkedQueue<T>
    {
        private class QueueNode<T>
        {
            public QueueNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; private set; }

            public QueueNode<T> NextNode { get; set; }

            public QueueNode<T> PrevNode { get; set; }

        }

        private QueueNode<T> Head { get; set; }

        private QueueNode<T> Tail { get; set; }

        public int Count { get; set; }

        public void Enqueue(T element)
        {
            if (this.Count == 0)
            {
                this.Head = this.Tail = new QueueNode<T>(element);
            }
            else
            {
                var newTail = new QueueNode<T>(element);
                newTail.PrevNode = this.Tail;
                this.Tail.NextNode = newTail;
                this.Tail = newTail;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Empty LinkedQueue!");
            }

            var firstElement = this.Head.Value;
            this.Head = this.Head.NextNode;
            if (this.Head != null)
            {
                this.Head.PrevNode = null;
            }
            else
            {
                this.Tail = null;
            }

            this.Count--;
            return firstElement;
        }

        public T[] ToArray()
        {
            var array = new T[this.Count];
            int index = 0;
            var currentNode = this.Head;

            while (currentNode != null)
            {
                if (index == this.Count)
                {
                    break;
                }
                array[index] = currentNode.Value;
                currentNode = currentNode.NextNode;
                index++;

            }

            return array;
        }
    }
}
