using System;

namespace linked_list_implementation
{
    class Program
    {
        static void Main(string[] args)
        {

            DynamicList<string> shoppingList = new DynamicList<string>();
            shoppingList.Add("Milk");
            shoppingList.Remove("Milk"); //Empty List
            shoppingList.Add("Honey");
            shoppingList.Add("Olives");
            shoppingList.Add("Water");
            shoppingList[2] = "A lot of " + shoppingList[2];
            shoppingList.Add("Fruits");
            shoppingList.RemoveAt(0); // Removes "Honey" (first)
            shoppingList.RemoveAt(2); //Removes "Fruits" (last)
            shoppingList.Add(null);
            shoppingList.Add("Beer");
            shoppingList.Remove(null);
            Console.WriteLine("We need to buy:");
            for (int i = 0; i < shoppingList.Count; i++)
            {
                Console.WriteLine(" - " + shoppingList[i]);
            }
            Console.WriteLine("Position of 'Beer' = {0}",
            shoppingList.IndexOf("Beer"));
            Console.WriteLine("Position of 'Water' = {0}",
            shoppingList.IndexOf("Water"));
            Console.WriteLine("Do we have to buy Bread? " +
            shoppingList.Contains("Bread"));
        }
    }
}
