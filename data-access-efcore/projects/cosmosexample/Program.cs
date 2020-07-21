using System;
using System.Linq;
using System.Threading.Tasks;
using cosmosexample.Entities;


namespace cosmosexample
{
    class Program
    {
        static async Task Main()
        {

            using (var db = new BloggingContext())
            {

                await db.Database.EnsureCreatedAsync();
                // create
                Console.WriteLine("Inserting a new blog");
                var newBlog = new Blog { Url = "http://blogs.msdn.com/adonet", BlogId = 1 };

                db.Blogs.Add(newBlog);
                db.SaveChanges();


                // Read
                Console.WriteLine("Querying for a blog");
                var blog = db.Blogs.OrderBy(blog => blog.BlogId).First();


                // Update
                Console.WriteLine("Updating the blog and adding a post");
                blog.Url = "https://devblogs.microsoft.com/dotnet";
                blog.Posts.Add(
                    new Post
                    {
                        Title = "Hello World",
                        Content = "I wrote an app using EF Core!"
                    });
                db.SaveChanges();
            }

        }
    }
}
