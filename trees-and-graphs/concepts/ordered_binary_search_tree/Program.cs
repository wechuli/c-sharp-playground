using System;

namespace ordered_binary_search_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>();
            tree.Insert("Telerik");
            tree.Insert("Google");
            tree.Insert("Microsoft");
            tree.Insert("Andela");
            tree.Insert("EquityLtd");
            tree.Insert("TechnoBrain");
            tree.Insert("IlabAfrica");
            tree.PrintTreeDFS();
            Console.WriteLine(tree.Contains("Telerik")); //True
            Console.WriteLine(tree.Contains("IBM")); // False
            tree.Remove("Microsoft");
            Console.WriteLine(tree.Contains("Microsoft")); //False
            tree.PrintTreeDFS();
        }
    }
}
