using System;
namespace ordered_binary_search_tree
{

    public class BinarySearchTree<T> where T : IComparable<T>
    {


        /// <summary>Represents a binary tree node</summary>
        /// <typeparam name="T">Specifies the type for the values in the nodes</typeparam>
        internal class BinaryTreeNode<T> : IComparable<BinaryTreeNode<T>> where T : IComparable<T>
        {
            // Contains the value of the node
            internal T value;
            //Contains the parent of the node
            internal BinaryTreeNode<T> parent;
            //Contains the left child of the node
            internal BinaryTreeNode<T> leftChild;

            //Contains the right child of the node 
            internal BinaryTreeNode<T> rightChild;

            ///<summary>Contructs the tree node</summary>
            /// <param name="value">The value of the tree node</param>

            public BinaryTreeNode(T value)
            {
                if (value == null)
                {
                    // Null values cannot be compared so do not allow them
                    throw new ArgumentNullException("Cannot insert null value!");
                }
                this.value = value;
                this.parent = null;
                this.leftChild = null;
                this.rightChild = null;

            }
            public override string ToString()
            {
                return this.value.ToString();
            }
            public override int GetHashCode()
            {
                return this.value.GetHashCode();
            }
            public override bool Equals(object obj)
            {
                BinaryTreeNode<T> other = (BinaryTreeNode<T>)obj;
                return this.CompareTo(other) == 0;
            }
            public int CompareTo(BinaryTreeNode<T> other)
            {
                return this.value.CompareTo(other.value);
            }

        }

        /// <summary>The root of the tree</summary>
        private BinaryTreeNode<T> root;

        ///<summary>Constructs the tree</summary>
        public BinarySearchTree()
        {
            this.root = null;
        }

        ///<summary>Inserts a new value in the binary search tree</summary>
        ///<param name="value">the value to be inserted</param>
        public void Insert(T value)
        {
            this.root = Insert(value, null, root);
        }

        /// <summary>
        /// Inserts node in the binary search tree by given value
        /// </summary>
        /// <param name="value">the new value</param>
        /// <param name="parentNode">the parent of the new node</param>
        /// <param name="node">current node</param>
        /// <returns>the inserted node</returns>

        private BinaryTreeNode<T> Insert(T value, BinaryTreeNode<T> parentNode, BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                node = new BinaryTreeNode<T>(value);
                node.parent = parentNode;

            }
            else
            {
                int compareTo = value.CompareTo(node.value);
                if (compareTo < 0)
                {
                    node.leftChild = Insert(value, node, node.leftChild);
                }
                else if (compareTo > 0)
                {
                    node.rightChild = Insert(value, node, node.rightChild);
                }
            }
            return node;
        }


    }
}