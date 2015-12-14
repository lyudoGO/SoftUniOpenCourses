namespace OrderedSet
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class Node<T> : IEnumerable<T>
    {
        public Node() { }

        public Node(T value, Node<T> leftChild = null, Node<T> rigthChild = null)
            : this()
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RigthChild = rigthChild;
        }

        public T Value { get; set; }

        public Node<T> LeftChild { get; set; }

        public Node<T> RigthChild { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.LeftChild != null)
            {
                foreach (var value in this.LeftChild)
                {
                    yield return value;
                }
            }

            yield return this.Value;

            if (this.RigthChild != null)
            {
                foreach (var value in this.RigthChild)
                {
                    yield return value;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}
