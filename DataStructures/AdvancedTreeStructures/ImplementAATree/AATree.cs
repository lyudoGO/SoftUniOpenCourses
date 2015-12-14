namespace ImplementAATree
{
    using System;
    using System.Collections.Generic;

    public class AATree<T> where T : IComparable<T>
    {
        public class Node
        {
            internal int Level { get; set; }
            internal Node LeftChild { get; set; }
            internal Node RightChild { get; set; }

            internal T Value { get; set; }

            internal Node()
            {
                this.LeftChild = this;
                this.RightChild = this;
                this.Value = default(T);
                this.Level = 0;
            }

            internal Node(T value, Node sentinel)
            {
                this.LeftChild = sentinel;
                this.RightChild = sentinel;
                this.Value = value;
                this.Level = 1;
            }
        }

        private Node rootNode;
        private Node nullNode;
        private Node deletedNode;

        public AATree()
        {
            this.rootNode = this.nullNode = new Node();
            this.deletedNode = null;
        }

        public Node Root 
        {
            get { return this.rootNode; }
        }

        public void Add(T value)
        {
            this.rootNode = Insert(this.rootNode, value);
        }

        public void Remove(T value)
        {
            //this.deletedNode = this.nullNode;
            this.rootNode = Delete(this.rootNode, value);
        }

        public bool Find(T value)
        {
            Node currentNode = this.rootNode;
            nullNode.Value = value;

            while(true)
            {
                if (value.CompareTo(currentNode.Value) < 0)
                {
                    currentNode = currentNode.LeftChild;
                }
                else if (value.CompareTo(currentNode.Value) > 0)
                {
                    currentNode = currentNode.RightChild;
                }
                else if (currentNode != nullNode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public T FindMax()
        {
            if (this.rootNode == this.nullNode)
            {
                return default(T);
            }

            Node tempNode = this.rootNode;

            while (tempNode.RightChild != this.nullNode)
            {
                tempNode = tempNode.RightChild;
            }

            return tempNode.Value;
        }

        public T FindMin()
        {
            if (this.rootNode == this.nullNode)
            {
                return default(T);
            }

            Node tempNode = this.rootNode;

            while (tempNode.LeftChild != this.nullNode)
            {
                tempNode = tempNode.LeftChild;
            }

            return tempNode.Value;
        }

        private Node Skew(Node node)
        {
            if (node.Level == node.LeftChild.Level)
            {
                // Rotate right
                Node left = node.LeftChild;
                node.LeftChild = left.RightChild;
                left.RightChild = node;
                node = left;
            }

            return node;
        }

        private Node Split(Node node)
        {
            if (node.RightChild.Level == node.Level)
            {
                // Rotate left
                Node right = node.RightChild;
                node.RightChild = right.LeftChild;
                right.LeftChild = node;
                node = right;
                node.Level++;
            }

            return node;
        }

        private Node Insert(Node node, T value)
        {
            if (node == this.nullNode)
            {
                node = new Node(value, this.nullNode);
            }
            else if (value.CompareTo(node.Value) < 0)
            {
                node.LeftChild = Insert(node.LeftChild, value);
            }
            else if (value.CompareTo(node.Value) > 0)
            {
                node.RightChild = Insert(node.RightChild, value);
            }
            else
            {
                return node;
            }
  
            node = Skew(node);
            node = Split(node);

            return node;
        }

        private Node Delete(Node node, T value)
        {
            if (node != this.nullNode)
            {
                // Step 1: Search down the tree and set deleted node
                if (value.CompareTo(node.Value) < 0)
                {
                    node.LeftChild = Delete(node.LeftChild, value);
                }
                else
                {
                    this.deletedNode = node;
                    node.RightChild = Delete(node.RightChild, value);
                }

                // Step 2: If at the bottom of the tree and value is present, we remove it
                if (node != this.deletedNode)
                {
                    if (this.deletedNode == this.nullNode || value.CompareTo(this.deletedNode.Value) != 0)
                    {
                        return node;   // Item not found; do nothing
                    }
                        
                    this.deletedNode.Value = node.Value;
                    node = node.RightChild;
                }
                else                 // Step 3: Otherwise, we are not at the bottom; rebalance
                {
                    if (node.LeftChild.Level < node.Level - 1 || node.RightChild.Level < node.Level - 1)
                    {
                        if (node.RightChild.Level > --node.Level)
                        {
                            node.RightChild.Level = node.Level;
                        }
                            
                        node = Skew(node);
                        node.RightChild = Skew(node.RightChild);
                        node.RightChild.RightChild = Skew(node.RightChild.RightChild);
                        node = Split(node);
                        node.RightChild = Split(node.RightChild);
                    }
                }
            }

            return node;
        }
    }
}