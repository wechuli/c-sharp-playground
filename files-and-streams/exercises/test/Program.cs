using System;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {

            List<String> names = new List<String>();

            names.Add("Paul");
            names.Add("Wechuli");
            names.Add("Brian");
            names.Add("Nancy");


            names.Sort();

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

        }
    }
}


