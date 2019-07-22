using System;

namespace ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            var randomDate = new DateTime(2019, 07, 21);
            var randomDate2 = new DateTime(1850, 07, 21);
            var book1 = new Book("Pride And Prejudice", "Jane Austen", "Penguin", randomDate, "12");
            var book2 = new Book("Emma", "Jane Austen", "Penguin", randomDate2, "123");
            var book3 = new Book("Middlemarch", "George Eliot", "ClassicHouse", randomDate2.AddDays(960), "124");

            var myLibrary = new Library("Strathmore");

            myLibrary.CountAllBooksInLibrary();
            myLibrary.AddBookToLib(book1);
            myLibrary.AddBookToLib(book2);
            myLibrary.AddBookToLib(book3);


            myLibrary.CountAllBooksInLibrary();
            myLibrary.DisplayInformationAboutBook("123");
            myLibrary.SearchBookByAuthor("Jane Austen");
            myLibrary.DeleteBookByIsbn("124");
            myLibrary.CountAllBooksInLibrary();

            myLibrary.DeleteAllBooksByAuthor("Jane Austen");

            myLibrary.CountAllBooksInLibrary();





        }
    }
}
