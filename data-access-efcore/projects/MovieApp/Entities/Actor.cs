using System;
using System.Collections.Generic;

namespace MovieApp.Entities
{
    public partial class Actor
    {
        public Actor()
        {
            FilmActor = new HashSet<FilmActor>();
        }

        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<FilmActor> FilmActor { get; set; }
    }
}
