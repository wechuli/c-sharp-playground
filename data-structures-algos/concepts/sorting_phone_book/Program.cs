using System;
using System.IO;
using System.Collections.Generic;

namespace sorting_phone_book
{
    class Program
    {
        static void Main(string[] args)
        {
            // It is given a text file, containing people's names, their city names and phone numbers. Weite a program which prints all the city names in an alphabetical order and for each one of them prints all the people's names in alphabetical order and their corresponing phone number.

            SortedDictionary<string, List<Person>> cities = new SortedDictionary<string, List<Person>>();


            StreamReader file = new StreamReader("phonebook.txt");
            using (file)
            {
                while (true)
                {
                    string line = file.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    string[] items = line.Split(new Char[] { '|' });
                    string city = items[1].Trim();
                    string person_name = items[0].Trim();
                    string contact = items[2].Trim();

                    List<Person> persons;

                    if (!cities.TryGetValue(city, out persons))
                    {
                        persons = new List<Person>();
                        cities.Add(city, persons);
                    }
                    Person person = new Person(person_name, contact);
                    persons.Add(person);
                }
            }

            foreach (string city in cities.Keys)
            {
                Console.WriteLine("City " + city + ":");
                List<Person> persons = cities[city];
                persons.Sort();
                foreach (Person person in persons)
                {
                    Console.WriteLine("\t{0}", person);
                }
            }

        }
    }

    public class Person : IComparable<Person>
    {
        private string name;
        private string contact;

        public Person(string name, string contact)
        {
            this.name = name;
            this.contact = contact;
        }
        public int CompareTo(Person person)
        {
            return this.name.CompareTo(person.name);

        }

        public override string ToString()
        {
            return this.name + " : " + this.contact;
        }

    }
}
