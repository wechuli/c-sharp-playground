using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;

namespace netwosoft
{
    class Program
    {
        static void Main(string[] args)
        {

            var prideAndPrejudice = new Movie { Name = "Pride and Prejudice", ReleaseDate = DateTime.Now.AddDays(-9022).ToUniversalTime(), Genres = new List<string> { "Romance", "Comedy", "Drama" } };
            var constantine = new Movie { Name = "Constantine", ReleaseDate = DateTime.Now.AddDays(-5000).ToUniversalTime(), Genres = new List<string> { "Romance", "Mystery", "Action", "Horror" } };

            IDictionary<string, int> studentsMarks = new Dictionary<string, int>();

            KeyValuePair<string, int>[] st;

            ICollection<KeyValuePair<string, int>> marks;


            string stringMovie = JsonSerializer.Serialize(new Movie[] { prideAndPrejudice, constantine });

            File.WriteAllText("movies.json", stringMovie);

            Console.WriteLine(stringMovie);

        }

        struct Movie
        {
            public string Name { get; set; }
            public DateTime ReleaseDate { get; set; }
            public List<string> Genres { get; set; }
        }
    }
}
