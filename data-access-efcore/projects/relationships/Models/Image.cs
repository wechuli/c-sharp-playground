using System;
using System.Collections.Generic;



namespace relationships.Models
{
    public class Image
    {

        public int ImageId { get; set; }
        public int AuthorId { get; set; }

        public byte ImageContent { get; set; }

        public Author Author { get; set; }



    }
}