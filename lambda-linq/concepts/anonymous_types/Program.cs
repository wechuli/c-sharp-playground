using System;

namespace anonymous_types
{
    class Program
    {
        static void Main(string[] args)
        {
            var myCar = new { Color = "Black", Brand = "Mazda", Speed = 180 };

            Console.WriteLine($"My car is a {myCar.Color} {myCar.Brand}");
            Console.WriteLine($"It runs {myCar.Speed} km/h");
            Console.WriteLine(myCar.GetType());




            Console.WriteLine("ToString: {0}", myCar.ToString());
            Console.WriteLine("Hash code: {0}", myCar.GetHashCode().ToString());
            Console.WriteLine("Equals? {0}", myCar.Equals(
            new { Color = "Red", Brand = "BMW", Speed = 180 }
            ));
            Console.WriteLine("Type name: {0}", myCar.GetType().ToString());


            var arr = new[] { new { X = 3, Y = 5 }, new { X = 1, Y = 2 }, new { X = 0, Y = 7 } };
            foreach (var item in arr)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
