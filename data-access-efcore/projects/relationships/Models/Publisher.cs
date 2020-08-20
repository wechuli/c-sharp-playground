using System;
using System.Collections.Generic;



namespace relationships.Models
{
    public class Publisher
    {

        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public ICollection<Book> Books { get; set; }



    }
}