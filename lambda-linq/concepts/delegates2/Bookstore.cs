using System;
using System.Collections.Generic;
using System.Collections;

namespace Bookstore
{
    public struct Book
    {
        public string Title;
        public string Author;
        public decimal Price;
        public bool Paperback;

        public Book(string title, string author, decimal price, bool paperBack)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
            this.Paperback = paperBack;
        }

    }

    // Declare a delegate type for processing a book:

    public delegate void ProcessBookDelegate(Book book);

    // Maintains a book database
    public class BookDB
    {
        // List of all books in the database:
        List<Book> books = new List<Book>();



        //Add a book to the database:
        public void AddBook(string title, string author, decimal price, bool paperBack)
        {
            books.Add(new Book(title, author, price, paperBack));


        }

        // Call a passed-in delegate on each paperback book to process it

        public void ProcessPaperbackBooks(ProcessBookDelegate processBook)
        {
            foreach (var book in this.books)
            {
                if (book.Paperback)
                {
                    //calling the delegate
                    processBook(book);
                }
            }
        }
    }
}