using System;
using System.Collections.Generic;

namespace MovieApp.Entities
{
    public partial class FilmCategory
    {
        public int FilmId { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Film Film { get; set; }
    }
}
