using System;

namespace splitting_strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] beers;
            string listOfBeers = "Amstel, Heineken, Tuborg, Becks";
            beers = listOfBeers.Split(", ");
            foreach (var beer in beers)
            {
                Console.WriteLine(beer);
            }

            //Alternatively we can solve the above problem more elegantly by using a list of separators and passing is an option
            char[] separators = new char[] { ' ', ',', '.' };
            string[] beersArr = listOfBeers.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var beer in beersArr)
            {
                Console.WriteLine(beer);
            }
        }
    }
}
