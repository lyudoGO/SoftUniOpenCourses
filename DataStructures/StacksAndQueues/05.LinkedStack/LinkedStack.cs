namespace _05.LinkedStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class LinkedStack<T>
    {
        private class Node<K>
        {
            public Node(K value, Node<K> nextNode = null)
            {
                this.Value = value;
                this.NextNode = nextNode;
            }

            public K Value { get; private set; }
            public Node<K> NextNode { get; set; }
        }

        private Node<T> firstNode;

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.firstNode == null)
            {
                this.firstNode = new Node<T>(element);
            }
            else
            {
                var newNode = new Node<T>(element, this.firstNode);
                this.firstNode = newNode;
            }

            this.Count++;
        }
        public T Pop()
        {
            if (this.firstNode == null)
            {
                throw new InvalidOperationException("The LinkedStack is empty!");
            }

            var popElement = this.firstNode.Value;
            this.firstNode = this.firstNode.NextNode;
            this.Count--;

            return popElement;
        }

        public T[] ToArray()
        {
            var array = new T[this.Count];
            int index = 0;
            var currentNode = this.firstNode;

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
