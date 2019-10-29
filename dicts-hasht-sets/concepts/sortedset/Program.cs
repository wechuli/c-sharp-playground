using System;
using System.Collections.Generic;

namespace sortedset
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> bandsBradLikes = new SortedSet<string>(new[] {
        "Manowar", "Blind Guardian", "Dio", "Kiss",
        "Dream Theater", "Megadeth", "Judas Priest",
        "Kreator", "Iron Maiden", "Accept"
                                        });

            SortedSet<string> bandsAngelinaLikes = new SortedSet<string>(new[] { "Iron Maiden", "Dio", "Accept", "Manowar", "Slayer", "Megadeth", "Running Wild", "Grave Gigger", "Metallica" });


            Console.Write("Brad Pitt likes these bands: ");
            Console.WriteLine(string.Join(", ", bandsBradLikes));

            Console.Write("Angelina Jolie likes these bands: ");
            Console.WriteLine(string.Join(", ", bandsAngelinaLikes));


            SortedSet<string> intersectBands = new SortedSet<string>(bandsBradLikes);
            intersectBands.IntersectWith(bandsAngelinaLikes);
            Console.WriteLine(string.Format(
            "Does Brad Pitt like Angelina Jolie? {0}",
            intersectBands.Count >= 5 ? "Yes!" : "No!"));
            Console.Write(
            "Because Brad Pitt and Angelina Jolie both like: ");
            Console.WriteLine(string.Join(", ", intersectBands));
            SortedSet<string> unionBands =
            new SortedSet<string>(bandsBradLikes);
            unionBands.UnionWith(bandsAngelinaLikes);
            Console.Write(
            "All bands that Brad Pitt or Angelina Jolie like: ");
            Console.WriteLine(string.Join(", ", unionBands));
        }
    }
}
