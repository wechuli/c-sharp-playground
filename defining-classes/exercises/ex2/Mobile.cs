using System;

namespace ex2
{
    class MobilePhone
    {

        private static Model nokiaN95 = new Model("Nokia N95");
        private Model model;
        private Manufacturer manufacturer;
        private Owner owner;
        private Battery battery;
        private Screen screen;
        private double price;

        public MobilePhone(Model model, Manufacturer manufacturer, Owner owner, Battery battery, Screen screen, double price)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.owner = owner;
            this.battery = battery;
            this.screen = screen;
            this.price = price;
        }

        public static void DisplayStaticModelInfo()
        {
            Console.WriteLine(nokiaN95.Name);
        }

        public override string ToString()
        {

            string model = this.model.Name;
            string owner = this.owner.Name;
            string manufacturer = this.manufacturer.Name;
            string battery = this.battery.Model;
            string screen = this.screen.PhoneInfo;
            double price = this.price;

            Console.WriteLine("........................");
            Console.WriteLine($"Model: {model}");
            Console.WriteLine($"Owner: {owner}");
            Console.WriteLine($"Manufacturer: {manufacturer}");
            Console.WriteLine($"Battery: {battery}");
            Console.WriteLine($"Screen: {screen}");
            Console.WriteLine($"Price: {price}");
            Console.WriteLine("...........................");

            return "New class";
        }
    }
}