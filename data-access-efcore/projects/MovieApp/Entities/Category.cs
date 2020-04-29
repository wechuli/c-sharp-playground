using System;
using System.Collections.Generic;

namespace MovieApp.Entities
{
    public partial class Category
    {
        public Category()
        {
            FilmCategory = new HashSet<FilmCategory>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FilmCategory> FilmCategory { get; set; }
    }
}
