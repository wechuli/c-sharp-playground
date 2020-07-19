using System;
using System.Linq;


namespace EFGetStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {

                // Create

                Console.WriteLine("Imserting a new blog");
                var newBlog = new Blog { Url = "https://medium.com/" };
                var newBlog2 = new Blog { Url = "https://dev.to/" };


                db.Blogs.Add(newBlog);
                db.Blogs.Add(newBlog2);
                db.SaveChanges();

                // Read

                Console.WriteLine("Querying for a blog");

                var blog = db.Blogs.OrderBy(blog => blog.BlogId).First();

                Console.WriteLine(blog.BlogId);
                Console.WriteLine(blog.Url);

                // Update

                Console.WriteLine("Updating the blog and adding a post");
                blog.Url = "https://devblogs.microsoft.com/dotnet";
                blog.Posts.Add(
                    new Post
                    {
                        Title = "Hello World",
                        Content = "I wrote an app using EF Core!"
                    }
                );
                db.SaveChanges();


            }
        }
    }
}
