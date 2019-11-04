using System;
using System.Collections.Generic;
using System.IO;

namespace sorting_students
{
    class Program
    {
        static void Main(string[] args)
        {
            // You are given a text file, containing the data of a group of students and courses which they attend, separated by |.
            // Write a progrma printing all courses and the students, who have joined them, ordered by last name, and then by first name (if the last names match)

            Dictionary<string, List<Student>> courses = new Dictionary<string, List<Student>>();
            StreamReader reader = new StreamReader("Students.txt");

            using (reader)
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    string[] entry = line.Split(new char[] { '|' });
                    string firstName = entry[0].Trim();
                    string lastName = entry[1].Trim();
                    string course = entry[2].Trim();
                    List<Student> students;
                    if (!courses.TryGetValue(course, out students))
                    {
                        // New course -> create a list of students for it
                        students = new List<Student>();
                        courses.Add(course, students);
                    }
                    Student student = new Student(firstName, lastName);
                    students.Add(student);
                }
            }

            // Print the courses and their students
            foreach (string course in courses.Keys)
            {
                Console.WriteLine("Course" + course + ":");
                List<Student> students = courses[course];
                students.Sort();
                foreach (Student student in students)
                {
                    Console.WriteLine("\t{0}", student);
                }
            }

        }
    }
    public class Student : IComparable<Student>
    {
        private string firstName;
        private string lastName;

        public Student(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public int CompareTo(Student student)
        {
            int result = lastName.CompareTo(student.lastName);
            if (result == 0)
            {
                result = firstName.CompareTo(student.firstName);
            }
            return result;
        }

        public override String ToString()
        {
            return firstName + " " + lastName;
        }
    }
}
