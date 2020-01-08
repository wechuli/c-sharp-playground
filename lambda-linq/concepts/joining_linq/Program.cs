using System;
using System.Linq;
using System.Collections.Generic;

namespace joining_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>(){
                new Category() { ID = 1, Name = "Fruit" },
                new Category() { ID = 2, Name = "Food" },
                new Category() { ID = 3, Name = "Shoe" },
                new Category() { ID = 4, Name = "Juice" },
                new Category(){ ID = 5, Name="Electronics"}
            };
            List<Product> products = new List<Product>()
            {
                new Product() { Name = "Strawberry", CategoryID = 1 },
                new Product() { Name = "Banana", CategoryID = 1 },
                new Product() { Name = "Chicken meat", CategoryID = 2 },
                new Product() { Name = "Apple Juice", CategoryID = 4 },
                new Product() { Name = "Fish", CategoryID = 2 },
                new Product() { Name = "Orange Juice", CategoryID = 4 },
                new Product() { Name = "Sandal", CategoryID = 3 },
                // new Product() { Name = "Keyboard Piano", CategoryID = 9 }

            };

            var productWithCategories =
                from product in products
                join category in categories
                    on product.CategoryID equals category.ID
                select new { Name = product.Name, Category = category.Name };


            Console.WriteLine("Using joins");
            foreach (var item in productWithCategories)
            {
                Console.WriteLine(item);
            }

            var productWithCategoriesNested =
                from product in products
                select new
                {
                    Name = product.Name,
                    Category =
                        (from category in categories
                         where category.ID == product.CategoryID
                         select category.Name).First()
                };


            Console.WriteLine("Using nested queries");
            foreach (var item in productWithCategoriesNested)
            {
                Console.WriteLine(item);
            }
        }
    }
    public class Product
    {
        public string Name { get; set; }
        public int CategoryID { get; set; }

    }
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }

    }
}
