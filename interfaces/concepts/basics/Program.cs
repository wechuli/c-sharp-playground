using System;

namespace basics
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleClass sc = new SampleClass();
            IControl ctrl = sc;
            ISurface srfc = sc;

            // The following lines all call the same method
            sc.Paint();
            ctrl.Paint();
            srfc.Paint();


            AnotherSampleClass sc2 = new AnotherSampleClass();
            IControl ctrl2 = sc2;
            ISurface srfc2 = sc2;
            ISalutations slts = sc2;



            ctrl2.Paint();
            srfc2.Paint();

            Console.WriteLine(sc2.Greeting);
            // change something
            slts.Greeting = "The interface has changed this";
            Console.WriteLine(sc2.Greeting);
        }
    }

    interface IEquitableCar<T>
    {
        bool Equals(T obj);
    }

    interface IVehicle
    {
        string Make { get; set; }
        string Model { get; set; }
        string Year { get; set; }


        string Move(string direction);
    }

    public class Car : IEquitableCar<Car>, IVehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Manufacturer { get; set; }

        public Car(string make, string model, string year, string manufacturer)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.Manufacturer = manufacturer;
        }

        //Implementation of IEquatable<T> interface
        public bool Equals(Car car)
        {

            return this.Make == car.Make && this.Model == car.Model && this.Year == car.Year;

        }

        public string Move(string direction)
        {
            return "that way";
        }
    }
}
