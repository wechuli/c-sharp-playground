using System;

namespace binary_tree_traversal_in_order
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the binary tree from the sample
            BinaryTree<int> binaryTree =
            new BinaryTree<int>(14,
            new BinaryTree<int>(19, new BinaryTree<int>(23), new BinaryTree<int>(6, new BinaryTree<int>(10), new BinaryTree<int>(21))),
            new BinaryTree<int>(15, new BinaryTree<int>(3), new BinaryTree<int>(17)));

            //Traverse and print the tree in the in-order manner
            Console.Write("In Order:- ");
            binaryTree.PrintInOrder();
            Console.WriteLine();
            Console.Write("Pre Order:- ");
            binaryTree.PrintPreOrder();
            Console.WriteLine();
            Console.Write("Post Order:- ");
            binaryTree.PrintPostOrder();

        }
    }
}
