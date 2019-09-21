using System;
namespace ordered_binary_search_tree
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
}