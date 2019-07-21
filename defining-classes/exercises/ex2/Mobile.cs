using System;
using System.Collections.Generic;
namespace ex2
{
    class MobilePhone
    {


        private List<Call> callHistory = new List<Call>();
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

        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
        }

        public static void DisplayStaticModelInfo()
        {
            Console.WriteLine(nokiaN95.Name);
        }

        public List<Call> AddCallRecord(Call callRecord)
        {

            callHistory.Add(callRecord);

            return callHistory;
        }

        public List<Call> DeleteCallRecord()
        {
            callHistory.RemoveAt(0);

            return callHistory;
        }

        public List<Call> DeleteAllCallRecords()
        {
            callHistory.Clear();
            return callHistory;
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