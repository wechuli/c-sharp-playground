using System;

namespace forEachLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            //The forEach programming construct serves to iterate over all elements of an array, list or other collection of elements. It passes through all the elements of the specified collection even if the collection is not indexed

            int[] numbers = { 2, 3, 4, 5, 6, 3, 3, 4, 2, 3, 2, 3 };
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
            //saves from writing alot of code
            string[] towns = { "Nairobi", "Kisumu", "Mombasa", "Nakuru", "Kakamega", "Bomet", "Mandera", "Narok", "Eldoret" };
            foreach (var town in towns)
            {
                Console.WriteLine(town);
            }
        }
    }
}
