using System;
using System.Collections.Generic;



namespace Models
{
    public class Book
    {

        public int Id { get; set; }
        public string bookName { get; set; }

        public int AuthorId { get; set; }
        public string isbn { get; set; }

        public int? CategoryId { get; set; }

        public Author author { get; set; }
        public Category category { get; set; }

    }
}