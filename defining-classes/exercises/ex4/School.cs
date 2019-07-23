using System;
using System.Collections.Generic;
namespace ex4
{

    public class SchoolClass
    {

        public string Name { get; set; }
        List<Teacher> teachers = new List<Teacher>();
        List<Student> students = new List<Student>();

        public SchoolClass(string name)
        {
            this.Name = name;
        }

        public Teacher[] AddTeachersToClass(params Teacher[] teachers)
        {
            foreach (var teacher in teachers)
            {
                this.teachers.Add(teacher);
            }

            return teachers;
        }
        public Student[] AddStudentsToClass(params Student[] students)
        {
            foreach (var student in students)
            {
                this.students.Add(student);
            }

            return students;
        }

        public void DisplayClassInfo()
        {

            Console.WriteLine($"{this.Name}");

            Console.WriteLine($"Students in {this.Name}....");
            foreach (var student in this.students)
            {
                Console.WriteLine($"{student.Name} - {student.StudentId}");
            }

            Console.WriteLine($"Teachers in {this.Name} ...");
            foreach (var teacher in this.teachers)
            {
                Console.WriteLine($"{teacher.Name}");
            }
        }



    }
    public class Teacher
    {
        public string Name { get; set; }
        List<Discipline> disciplines = new List<Discipline>();

        public Teacher(string name)
        {
            this.Name = name;
        }

        public Discipline AddDisciplineToTeacher(Discipline discipline)
        {
            this.disciplines.Add(discipline);
            return discipline;
        }

    }
    public class Student
    {

        public string Name { get; set; }
        public string StudentId { get; set; }

        public Student(string name, string studentId)
        {
            this.Name = name;
            this.StudentId = studentId;
        }

    }
    public class Discipline
    {
        public string Name { get; set; }
        public int NoOfLessons { get; set; }
        public int NoOfExercises { get; set; }

        public Discipline(string name, int noOfLessons, int noOfExercises)
        {
            this.Name = name;
            this.NoOfLessons = noOfLessons;
            this.NoOfExercises = noOfExercises;
        }
    }

}