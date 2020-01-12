using System;
using System.Linq;
using System.Collections.Generic;

namespace ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = { new Student("Paul", "Wechuli", 27), new Student("Jackline", "Mwanza", 20), new Student("Tanganga", "Alfred", 44), new Student("Kevin", "Otieno", 37), new Student("Smith", "Allison", 90) };

            var lastNameBeforeFirstCollection =
                from student in students
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;


            foreach (var student in lastNameBeforeFirstCollection)
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
            age = Age;
        }
    }
}
