using System;
using System.Collections.Generic;

namespace treeADT
{

    // Represents a tree node
    public class TreeNode<T>
    {
        // Contains the value of the node
        private T value;

        //Shows whether the current node has a parent or not
        private bool hasParent;

        //Contains the children of the node (zero or more)
        private List<TreeNode<T>> children;

        //Contructs a tree node

        public TreeNode(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }
            this.value = value;
            this.children = new List<TreeNode<T>>();
        }

        //The value of the node

        public T Value
        {
            get
            {
                return this.value;

            }
            set
            {
                this.value = value;
            }
        }

        //The number of node's children

        public int ChildrenCount
        {
            get
            {
                return this.children.Count;
            }
        }

        // Adds child to the node

        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException("Cannot insert null value");
            }
            if (child.hasParent)
            {
                throw new ArgumentException("The node already has a parent!");
            }
            child.hasParent = true;
            this.children.Add(child);
        }

        // Gets the child of the node at given index
        public TreeNode<T> GetChild(int index)
        {
            if (index < 0 || index >= this.children.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid child index");
            }

            return this.children[index];
        }

    }

    //Represents a tree data structure
    public class Tree<T>
    {
        //The root of the tree
        private TreeNode<T> root;

        //constructs the tree

        public Tree(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Cannot insert null value!");
            }
            this.root = new TreeNode<T>(value);
        }

        // Constructs the tree given the children

        public Tree(T value, params Tree<T>[] children) : this(value)
        {
            foreach (Tree<T> child in children)
            {
                this.root.AddChild(child.root);
            }
        }

        //The root node or null if the tree is empty

        public TreeNode<T> Root
        {
            get
            {
                return this.root;
            }
        }

        //Traverses and prints the tree in Depth-First Search(DFS) manner

        private void printDFS(TreeNode<T> root, string spaces)
        {
            if (this.root == null)
            {
                return;
            }

            Console.WriteLine(spaces + root.Value);
            TreeNode<T> child = null;
            for (int i = 0; i < root.ChildrenCount; i++)
            {
                child = root.GetChild(i);
                printDFS(child, spaces + " ");
            }
        }

        public void TraverseDFS()
        {
            this.printDFS(this.root, string.Empty);
        }
    }
}