using System;
using System.Collections.Generic;



namespace relationships.Models
{
    public class Author
    {

        public int AuthorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public string Bio { get; set; }

    }
}