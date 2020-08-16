using System;
using System.Collections.Generic;



namespace Models
{
    public class Category
    {

        public Category()
        {
            books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Book> books;


    }
}