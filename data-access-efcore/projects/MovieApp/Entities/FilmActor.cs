using System;
using System.Collections.Generic;

namespace MovieApp.Entities
{
    public partial class FilmActor
    {
        public int FilmId { get; set; }
        public int ActorId { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Film Film { get; set; }
    }
}
