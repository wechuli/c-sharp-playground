using System;
using System.Collections.Generic;

namespace ex2
{
    public class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

        }
    }
    public class Student : Human, IComparable<Student>
    {
        public double Marks { get; set; }
        public Student(string firstName, string lastName, double marks) : base(firstName, lastName)
        {
            this.Marks = marks;
        }
        public int CompareTo(Student student)
        {
            return this.Marks.CompareTo(student.Marks);
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} : {this.Marks} marks";
        }

    }
    public class Worker : Human, IComparable<Worker>
    {
        public double Hours { get; set; }
        public double Wage { get; set; }
        public Worker(string firstName, string lastName, double hours, double wage) : base(firstName, lastName)
        {
            this.Hours = hours;
            this.Wage = wage;
        }

        public double CalculateHourlyWages()
        {
            return this.Wage / this.Hours;
        }
        public int CompareTo(Worker worker)
        {
            return this.Wage.CompareTo(worker.Wage);
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} : {this.Wage} marks";
        }
    }

}