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
            Console.WriteLine(nameof(CreateItem));
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