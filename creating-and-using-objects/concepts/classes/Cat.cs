using System;
namespace myclasses
{

   class Cat
    {
        //Field name
        private string name;
        //Field color
        private string color;

        public string Name
        {
            //Getter of the property "Name"
            get
            {
                return this.name;
            }

            //Setter of the property 'Name'
            set
            {
                this.name = value;
            }
        }
        public string Color
        {
            //Getter of the property "Color"
            get
            {
                return this.color;
            }

            //Setter of the property 'Color'
            set
            {
                this.color = value;
            }
        }

        //Default constructor
        public Cat()
        {
            this.name = "Unnamed";
            this.color = "gray";
        }

        //constructor with parameters
        public Cat(string name, string color)
        {
            this.name = name;
            this.color = color;
        }
        //Method SayMiau
        public void SayMiau()
        {
            Console.WriteLine($"Cat {name} said: Miauuu!");
        }
    }

}