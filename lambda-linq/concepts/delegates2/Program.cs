using System;
using Bookstore;

namespace delegates2
{
    class Program
    {
        static void Main(string[] args)
        {

            BookDB bookDB = new BookDB();
            // Initialize the database with some books
            AddBooks(bookDB);

            // Print all the titles of paperbacks
            Console.WriteLine("Paperback Book Titles: ");

            // create a new delegate object associated with the static method Test.PrintTitle
            ProcessBookDelegate printTitleDelegate = PrintTitle;
            bookDB.ProcessPaperbackBooks(printTitleDelegate);

            // Get the average price of a paperback by usinf a Pricetotaller object:
            PriceTotaller totaller = new PriceTotaller();

            // Create a new delegate object associated with the nonstatic method AddBookToTotal on the object totaller
            ProcessBookDelegate totallerDelegate = totaller.AddBookToTotal;
            bookDB.ProcessPaperbackBooks(totallerDelegate);

            Console.WriteLine("Average Paperback Book Price: ${0:#.##}",
                   totaller.AveragePrice());

        }

        // Print the title of the book
        static void PrintTitle(Book book)
        {
            Console.WriteLine($"{book.Title}");
        }

        // Initialize the book database with some test books

        static void AddBooks(BookDB bookDB)
        {
            bookDB.AddBook("The C Programming Language", "Brian W. Kernighan and Dennis M. Ritchie", 19.95m, true);
            bookDB.AddBook("The Unicode Standard 2.0", "The Unicode Consortium", 39.95m, true);
            bookDB.AddBook("The MS-DOS Encyclopedia", "Ray Duncan", 129.95m, false);
            bookDB.AddBook("Dogbert's Clues for the Clueless", "Scott Adams", 12.00m, true);

        }
    }

    //Class to total and average prices of books
    public class PriceTotaller
    {
        int countBooks = 0;
        decimal priceBooks = 0.0m;

        internal void AddBookToTotal(Book book)
        {
            countBooks += 1;
            priceBooks += book.Price;
        }

        internal decimal AveragePrice()
        {
            return priceBooks / countBooks;
        }
    }
}
