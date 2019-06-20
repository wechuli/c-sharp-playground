using System;
using CreatingAndUsingObjects;

namespace ex8
{
    class Program
    {
        static void Main(string[] args)
        {

            Cat[] Cats = new Cat[10];
            for (int i = 0; i < 10; i++)
            {
                string name = "name" + i.ToString();
                string color = "color" + i.ToString();


                Cats[i] = new Cat(name, color);


            }

            for (int i = 0; i < 10; i++)
            {
                Cats[i].SayMiau();
            }
        }
    }
}
