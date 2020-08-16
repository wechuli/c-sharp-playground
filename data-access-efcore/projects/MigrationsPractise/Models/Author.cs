using System;
using System.Collections.Generic;



namespace Models
{
    public class Author
    {

        public Author()
        {
            books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }


        public ICollection<Book> books;
    }
}