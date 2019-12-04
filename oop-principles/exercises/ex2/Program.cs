using System;
using System.Collections.Generic;

namespace ex2
{
    class Program
    {
        static void Main(string[] args)
        {


            List<Student> students = new List<Student>();
            List<Worker> workers = new List<Worker>();


            double[] marksAndWages = new double[] { 345, 234, 454, 434, 45, 34, 121, 4354, 456, 454, 554, 43, 45, 656, 434, 434 };
            double[] hoursWorked = new double[] { 23, 4, 43, 5, 23, 12, 34, 54, 66, 3, 423, 1, 21, 234, 43, 12, 34, 5, 789, 32, 34 };
            string[] firstNames = new string[] { "Paul", "Kevin", "Anna", "Eunice", "Brad", "Tina", "Nancy", "Valentine", "Greg" };
            string[] lastNames = new string[] { "Smith", "Wechuli", "Nafula", "Wanjiku", "Mueni", "Chebet", "Kato", "Omondi", "Achieng" };

            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                string firstName = firstNames[random.Next(0, firstNames.Length)];
                string lastName = lastNames[random.Next(0, lastNames.Length)];
                double marks = marksAndWages[random.Next(0, marksAndWages.Length)];
                Student newStudent = new Student(firstName, lastName, marks);
                students.Add(newStudent);
            }
            for (int i = 0; i < 10; i++)
            {
                string firstName = firstNames[random.Next(0, firstNames.Length)];
                string lastName = lastNames[random.Next(0, lastNames.Length)];
                double marks = marksAndWages[random.Next(0, marksAndWages.Length)];
                double hours = hoursWorked[random.Next(0, hoursWorked.Length)];

                Worker newWorker = new Worker(firstName, lastName, hours, marks);
                workers.Add(newWorker);

            }

            Console.WriteLine(".....................................");
            Console.WriteLine("Students");
            Console.WriteLine(".....................................");

            students.Sort();
            foreach (var student in students)
            {
                Console.WriteLine(student);

            }

            Console.WriteLine(".....................................");
            Console.WriteLine("Workers");
            Console.WriteLine(".....................................");


            workers.Sort();
            workers.Reverse();
            foreach (var worker in workers)
            {
                Console.WriteLine(worker);
            }

        }
    }
}
