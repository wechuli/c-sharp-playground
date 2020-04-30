using System;
using System.Linq;
using ConsoleTables;
using MovieApp.Entities;
using MovieApp.Extensions;
using MovieApp.Models;


namespace MovieApp
{
    public static class Module1Helper
    {
        internal static void SelectList()
        {
            var actors = MoviesContext.Instance.Actors.Select(a => a.Copy<Actor, ActorModel>());
            //Console.WriteLine(actors.Count());
            ConsoleTable.From(actors).Write();

            var films = MoviesContext.Instance.Films.Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();
        }

        internal static void SelectById()
        {
            Console.WriteLine("Enter an Actor ID");
            var actorId = Console.ReadLine().ToInt();
            var actor = MoviesContext.Instance.Actors.SingleOrDefault(actor => actor.ActorId == actorId);

            if (actor == null)
            {
                Console.WriteLine($"Actor with ID {actorId} not found.");
            }
            else
            {
                Console.WriteLine($"ID: {actor.ActorId}  Name: {actor.FirstName} {actor.LastName}");
            }

            Console.WriteLine("Enter a Film Title");
            var title = Console.ReadLine();
            var film = MoviesContext.Instance.Films.FirstOrDefault(f => f.Title.Contains(title));
            if (film == null)
            {
                Console.WriteLine($"Film with Title {title} not found.");
            }
            else
            {
                Console.WriteLine($"ID: {film.FilmId}  Title: {film.Title}  Year: {film.ReleaseYear}  Rating: {film.Rating}");
            }
        }
        internal static void CreateItem()
        {

            // add an actor
            Console.WriteLine("Add an Actor");

            Console.WriteLine("Enter a First Name");
            var firstName = Console.ReadLine();

            Console.WriteLine("Enter a Last Name");
            var lastName = Console.ReadLine();

            var actor = new Actor { FirstName = firstName, LastName = lastName };
            MoviesContext.Instance.Actors.Add(actor);

            MoviesContext.Instance.SaveChanges();

            var actors = MoviesContext.Instance.Actors.Where(a => a.ActorId == actor.ActorId).Select(a => a.Copy<Actor, ActorModel>());
            ConsoleTable.From(actors).Write();


            // add a film
            Console.WriteLine("Add a Film");

            Console.WriteLine("Enter a Title");
            var title = Console.ReadLine();

            Console.WriteLine("Enter a Description");
            var description = Console.ReadLine();

            Console.WriteLine("Enter a Release Year");
            var year = Console.ReadLine().ToInt();

            Console.WriteLine("Enter a Rating");
            var rating = Console.ReadLine();

            var film = new Film { Title = title, Description = description, ReleaseYear = year, Rating = rating };

            MoviesContext.Instance.Films.Add(film);

            MoviesContext.Instance.SaveChanges();

            var films = MoviesContext.Instance.Films
                            .Where(f => f.FilmId == film.FilmId)
                            .Select(f => f.Copy<Film, FilmModel>());
            ConsoleTable.From(films).Write();
        }

        internal static void UpdateItem()
        {
            Console.WriteLine(nameof(UpdateItem));
        }

        internal static void DeleteItem()
        {
            Console.WriteLine(nameof(DeleteItem));
        }
    }
}