namespace OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class OrderedSet<T> : IEnumerable<T> where T : IComparable<T>
    {
        public OrderedSet()
        {
            this.Root = null;
            this.Count = 0;
        }

        public Node<T> Root { get; private set; }

        public int Count { get; private set; }

        public void Add(T value)
        {
            this.Root = this.InsertNode(value, this.Root);
            this.Count++;
        }

        public bool Contains(T value)
        {
            var node = this.Find(value, this.Root);
            return node != null;
        }

        public void Remove(T value)
        {
            this.Root = this.RemoveNode(value, this.Root);
            this.Count--;
        }

        private Node<T> InsertNode(T value, Node<T> node)
        {
            if (node == null)
            {
                node = new Node<T>(value);
            }
            else if (value.CompareTo(node.Value) < 0)
            {
                node.LeftChild = InsertNode(value, node.LeftChild);
            }
            else if (value.CompareTo(node.Value) > 0)
            {
                node.RigthChild = InsertNode(value, node.RigthChild);
            }
            else
            {
                throw new ArgumentException("Duplicate value, it should be unique!");
            }

            return node;
        }

        private Node<T> Find(T value, Node<T> node)
        {
            while (node != null)
            {
                int compareTo = value.CompareTo(node.Value);
                if (compareTo < 0)
                {
                    node = node.LeftChild;
                }
                else if (compareTo > 0)
                {
                    node = node.RigthChild;
                }
                else
                {
                    return node; ;
                }
            }

            return null;
        }

        private Node<T> RemoveNode(T value, Node<T> node)
        {
            if (node == null)
            {
                throw new ArgumentException("Value not found!");
            }
            else if (value.CompareTo(node.Value) < 0)
            {
                node.LeftChild = RemoveNode(value, node.LeftChild);
            }
            else if (value.CompareTo(node.Value) > 0)
            {
                node.RigthChild = RemoveNode(value, node.RigthChild);
            }
            else if (node.LeftChild != null && node.RigthChild != null)
            {
                node.Value = FindMin(node.RigthChild).Value;
                node.RigthChild = RemoveMin(node.RigthChild);
            }
            else
            {
                node = (node.LeftChild != null) ? node.LeftChild : node.RigthChild;
            }

            return node;
        }

        private Node<T> RemoveMin(Node<T> node)
        {
            if (node == null)
            {
                throw new ArgumentException("Value not found!");
            }
            else if (node.LeftChild != null)
            {
                node.LeftChild = RemoveMin(node.LeftChild);
                return node;
            }
            else
            {
                return node.RigthChild;
            }
        }

        private Node<T> FindMin(Node<T> node)
        {
            if (node != null)
            {
                while (node.LeftChild != null)
                {
                    node = node.LeftChild;
                }
            }

            return node;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.Root.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}
