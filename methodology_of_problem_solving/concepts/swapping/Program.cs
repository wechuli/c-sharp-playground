using System;
using System.Collections.Generic;

namespace swapping
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> girls = new List<string>() { "June", "Wahura", "Betty", "Aloe", "Brie", "Angela", "Mildred", "Mercy" };
            FakeClass<string>.SwapItemsInCollection(girls);
            foreach (var girl in girls)
            {
                Console.Write($"{girl} ");
            }

            string[] fruits = { "Tomatoes", "Mangoes", "Papaya", "Legumes" };
            FakeClass<string>.SwapItemsInCollection(fruits);

            Console.WriteLine();
            foreach (var fruit in fruits)
            {
                Console.Write($"{fruit} ");
            }


        }

    }

    public static class FakeClass<T>
    {

        public static void SwapItemsInCollection(IList<T> collection)
        {

            Random rand = new Random();

            for (var i = 0; i < collection.Count; i++)
            {
                T currentValue = collection[i];
                int swapIndex = rand.Next(collection.Count);
                collection[i] = collection[swapIndex];
                collection[swapIndex] = currentValue;
            }


        }

    }
}
