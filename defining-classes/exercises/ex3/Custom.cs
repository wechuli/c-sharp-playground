using System;
using System.Collections.Generic;
namespace ex3
{
    internal class Library
    {

        public string Name { get; set; }
        List<Book> books = new List<Book>();

        public Library(string name)
        {
            this.Name = name;
        }

        public Book AddBookToLib(Book book)
        {
            books.Add(book);
            return book;

        }
        public Book SearchBookByAuthor(string author)
        {
            Book result = books.Find(book => book.Author == author);

            Console.WriteLine($"Book Title: {result.Title}");
            Console.WriteLine($"Book Author: {result.Author}");
            Console.WriteLine($"Book Publisher: {result.Publisher}");
            Console.WriteLine($"Book Release Date: {result.ReleaseDate}");
            Console.WriteLine($"Book ISBN: {result.IsbnNumber}");
            Console.WriteLine("..................");

            return result;
        }

        public List<Book> DeleteBookByIsbn(string isbn)
        {
            books.RemoveAll(book => book.IsbnNumber == isbn);

            return this.books;
        }

        public void DeleteAllBooksByAuthor(string author)
        {
            this.books.RemoveAll(book => book.Author = author);
        }

        public void DisplayInformationAboutBook(string isbn)
        {

            Book book = books.Find(item => item.IsbnNumber == isbn);

            Console.WriteLine($"Book Title: {book.Title}");
            Console.WriteLine($"Book Author: {book.Author}");
            Console.WriteLine($"Book Publisher: {book.Publisher}");
            Console.WriteLine($"Book Release Date: {book.ReleaseDate}");
            Console.WriteLine($"Book ISBN: {book.IsbnNumber}");
            Console.WriteLine("..................");
        }

        public void CountAllBooksInLibrary()
        {
            var count = this.books.Count;

            Console.WriteLine($"Number of books in the library: {count}");
        }

    }

    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string IsbnNumber { get; set; }

        public Book(string title, string author, string publisher, DateTime releaseDate, string isbn)
        {
            this.Title = title;
            this.Author = author;
            this.Publisher = publisher;
            this.ReleaseDate = releaseDate;
            this.IsbnNumber = isbn;
        }

    }
}