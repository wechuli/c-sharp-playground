using System;
using System.Linq;
using System.Linq.Expressions;
using ConsoleTables;
using MovieApp.Entities;
using MovieApp.Extensions;
using MovieApp.Models;

namespace MovieApp
{
    public static class Module2Helper
    {

        public static void Sort()
        {


            var actors = MoviesContext.Instance.Actors.OrderBy(actor => actor.LastName).Select(actor => actor.Copy<Actor, ActorModel>());

            ConsoleTable.From(actors).Write();


            var films = MoviesContext.Instance.Films.OrderBy(f => f.Rating).ThenBy(f => f.ReleaseYear).ThenBy(f => f.Title).Select(f => f.Copy<Film, FilmModel>());

            ConsoleTable.From(films).Write();
        }
        public static void SortDescending()
        {
            var actors = MoviesContext.Instance.Actors.OrderByDescending(actor => actor.FirstName).Select(actor => actor.Copy<Actor, ActorModel>());
            ConsoleTable.From(actors).Write();

            var films = MoviesContext.Instance.Films.OrderByDescending(f => f.ReleaseYear).ThenBy(f => f.Title).Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();
        }
        public static void Skip()
        {
            var films = MoviesContext.Instance.Films.Skip(3).OrderBy(f => f.Title).Select(film => film.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();

            var filmsSortThenSkip = MoviesContext.Instance.Films.OrderBy(f => f.Title).Skip(3).Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(filmsSortThenSkip).Write();
        }
        public static void Take()
        {
            var films = MoviesContext.Instance.Films.Take(5).OrderBy(f => f.Title).Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();

            var filmsSortThenTake = MoviesContext.Instance.Films.OrderBy(f => f.Title).Take(5).Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(filmsSortThenTake).Write();
        }
        public static void Paging()
        {
            int pageSize = 5;
            int pageNumber = 2;

            var films = MoviesContext.Instance.Films.Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();

            var filmsSkippedAndOrdered = MoviesContext.Instance.Films.OrderBy(f => f.Title).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(f => f.Copy<Film, FilmModel>());

            ConsoleTable.From(filmsSkippedAndOrdered).Write();
        }

        public static void PagingWithUserInput()
        {
            Console.WriteLine("Enter a page size: ");
            var pageSize = Math.Max(5, Console.ReadLine().ToInt());


            Console.WriteLine("Enter a page number:");
            var pageNumber = Math.Max(1, Console.ReadLine().ToInt());

            Console.WriteLine("Enter a sort column:");
            Console.WriteLine("\ti - Film ID");
            Console.WriteLine("\tt - Title");
            Console.WriteLine("\ty - Year");
            Console.WriteLine("\tr - Rating");

            var key = Console.ReadKey();

            Console.WriteLine();

            var films = MoviesContext.Instance.Films.OrderBy(GetSort(key)).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(f => f.Copy<Film, FilmModel>());

            ConsoleTable.From(films).Write();



        }


        public static void LinqBasics()
        {

            // get multiple actors
            var actors = from a in MoviesContext.Instance.Actors
                         orderby a.FirstName
                         select a.Copy<Actor, ActorModel>();
            ConsoleTable.From(actors).Write();

            // get single actos

            var actor = from a in MoviesContext.Instance.Actors
                        where a.ActorId == 4
                        select a.Copy<Actor, ActorModel>();
            ConsoleTable.From(actor).Write();

            // filter and sort

            var search = "ar";

            actors = from a in MoviesContext.Instance.Actors
                     where a.FirstName.Contains(search)
                     orderby a.FirstName descending
                     select a.Copy<Actor, ActorModel>();
            ConsoleTable.From(actors).Write();
        }

        public static void LambdaBasics()
        {
            var films = MoviesContext.Instance.Films.OrderBy(f => f.Title).Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();

            films = MoviesContext.Instance.Films.Where(f => f.FilmId == 4).Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();


            string search = "g";
            films = MoviesContext.Instance.Films.Where(f => f.Title.Contains(search)).OrderByDescending(f => f.Title).Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();
        }

        public static void LinqVsLambda()
        {
            // var films = (from f in MoviesContext.Instance.Films
            //              select f.Copy<Film, FilmModel>());
            // ConsoleTable.From(films).Write();

            // films = MoviesContext.Instance.Films
            //             .Select(f => f.Copy<Film, FilmModel>());
            // ConsoleTable.From(films).Write();

            var title = "g";
            var rating = "pg-13";
            var years = new int[] { 2016, 2015, 2012 };

            var films = from f in MoviesContext.Instance.Films
                        where f.Title.Contains(title) &&
                        f.Rating == rating &&
                        f.ReleaseYear.HasValue &&
                        years.Contains(f.ReleaseYear.Value)
                        orderby f.ReleaseYear descending, f.Title
                        select f.Copy<Film, FilmModel>();
            ConsoleTable.From(films).Write();

            films = MoviesContext.Instance.Films
            .Where(f => f.Title.Contains(title) &&
                f.Rating == rating &&
                f.ReleaseYear.HasValue &&
                years.Contains(f.ReleaseYear.Value))
            .OrderByDescending(f => f.ReleaseYear)
            .ThenBy(f => f.Title)
            .Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();


            // Grouping data


            // grouping with linq
            var filmGroups = from f in MoviesContext.Instance.Films
                             group f by f.Rating into g
                             select new
                             {
                                 g.Key,
                                 Count = g.Count()
                             };
            foreach (var filmGroup in filmGroups)
            {

                Console.WriteLine(filmGroup.Key);
                Console.WriteLine(filmGroup.Count);
                // foreach (var film in filmGroup)
                // {
                //     Console.WriteLine($"\t{film.Title}");
                // }

            }

            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();


            // grouping with extension methods with lambdas
            var filmGroups2 = MoviesContext.Instance.Films.AsEnumerable()
                             .GroupBy(f => f.Rating);
            foreach (var filmGroup in filmGroups2)
            {
                Console.WriteLine(filmGroup.Key);
                foreach (var film in filmGroup.OrderBy(f => f.Title))
                {
                    Console.WriteLine($"\t{film.Title}");
                }
            }
        }

        private static Expression<Func<Film, object>> GetSort(ConsoleKeyInfo info)
        {
            switch (info.Key)
            {
                case ConsoleKey.I:
                    return f => f.FilmId;
                case ConsoleKey.Y:
                    return f => f.ReleaseYear;
                case ConsoleKey.R:
                    return f => f.Rating;
                default:
                    return f => f.Title;
            }
        }
    }
}