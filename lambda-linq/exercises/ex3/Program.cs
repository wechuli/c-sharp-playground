using System;
using System.Linq;
using System.Collections.Generic;

namespace ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = { new Student("Paul", "Wechuli", 27), new Student("Paul", "Wafula", 27), new Student("Paul", "Another_paul", 27), new Student("Jackline", "Mwanza", 20), new Student("Tanganga", "Alfred", 44), new Student("Kevin", "Otieno", 37), new Student("Smith", "Allison", 90), new Student("June", "Achieng", 24), new Student("Norman", "Barasa", 30) };


            // Write a method that for a given array of students finds those, whose first name is before their last one in alphabetical order. Use LINQ.
            var lastNameBeforeFirstCollection =
                from student in students
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;
            Console.WriteLine("Students whose first name comes before last ");
            foreach (var student in lastNameBeforeFirstCollection)
            {
                Console.WriteLine($"First Name:{student.FirstName}, Last Name:{student.LastName}");
            }


            Console.WriteLine("......................................................................");
            // Create a LINQ query that finds the first and the last name of all students, aged between 18 and 24 years including. Use the class Student from the previous exercise.

            var studentsBetween18and24 =
                from student in students
                where student.Age >= 18 && student.Age <= 24
                select new { FirstName = student.FirstName, LastName = student.LastName, Age = student.Age };
            Console.WriteLine("Students whose age between 18 and 24 ");

            foreach (var student in studentsBetween18and24)
            {

                Console.WriteLine($"First Name:{student.FirstName}, Last Name:{student.LastName}, Age: {student.Age}");
            }


            Console.WriteLine("......................................................................");
            // By using the extension methods OrderBy(…) and ThenBy(…) with lambda expression, sort a list of students by their first and last name in descending order. Rewrite the same functionality using a LINQ query.

            var studentsSortedByFirstandLastNames = students.OrderBy((student) => student.FirstName).ThenBy((student) => student.LastName).Reverse();

            Console.WriteLine("Students sorted by First and LastName");
            foreach (var student in studentsSortedByFirstandLastNames)
            {
                Console.WriteLine($"First Name:{student.FirstName}, Last Name:{student.LastName}");
            }

            var studentsSortedByFirstandLastNamesLinq =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;
            Console.WriteLine(studentsSortedByFirstandLastNamesLinq.GetType());
            foreach (var student in studentsSortedByFirstandLastNamesLinq)
            {
                Console.WriteLine($"First Name:{student.FirstName}, Last Name:{student.LastName}");
            }
        }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Student(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }
}
