using System;




namespace relationships.Models
{
    public class Book
    {

        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PublisherID { get; set; }

        public DateTime DatePublished { get; set; }

        public Publisher Publisher { get; set; }



    }
}