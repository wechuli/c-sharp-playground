using System;
namespace ex1
{
    public class Student
    {
        private string fullName;
        private string course;
        private string subject;
        private string university;
        private string email;
        private string phoneNumber;
        public static int studentsNo;

        public Student(string fullName, string course, string subject, string university, string phoneNumber, string email)
        {
            this.fullName = fullName;
            this.course = course;
            this.subject = subject;
            this.university = university;
            this.phoneNumber = phoneNumber;
            this.email = email;


            studentsNo++;
        }

        public string FullName { get { return this.fullName; } set { this.fullName = value; } }
        public string Course { get { return this.course; } set { this.course = value; } }
        public string Subject { get { return this.subject; } set { this.subject = value; } }
        public string University { get { return this.university; } set { this.university = value; } }
        public string Email { get { return this.email; } set { this.email = value; } }
        public string PhoneNumber { get { return this.phoneNumber; } set { this.phoneNumber = value; } }
        public Student()
        {

            studentsNo++;
        }

        public void DisplayStudentInfo()
        {
            Console.WriteLine("................................");
            Console.WriteLine($"Full Name: {this.fullName}");
            Console.WriteLine($"Course: {this.course}");
            Console.WriteLine($"Subject: {this.subject}");
            Console.WriteLine($"University: {this.university}");
            Console.WriteLine($"Phone Number: {this.phoneNumber}");
            Console.WriteLine($"Email: {this.email}");
            Console.WriteLine("................................");
        }


    }

    internal class StudentTest
    {

        private static Student[] students = new Student[10];

        public static Student[] Students
        {
            get
            {
                return students;
            }
        }

        public StudentTest()
        {

        }
        private Student student1 = new Student();
        private Student student2 = new Student("Paul Wechuli", "Computer Programming", "Computer Science", "JKUAT", "0701234586", "wechulipaul@mars.venus");

        public void CheckNumberOfStudents()
        {
            Console.WriteLine($"There are {Student.studentsNo} students");
        }

        public void PrintStudentsDetails()
        {
            student1.DisplayStudentInfo();
            student2.DisplayStudentInfo();
        }

        public void UpdateStudent1Details()
        {
            student1.FullName = "Jennifer Okumu";
            student1.Email = "jen@venus.earth";
            student1.PhoneNumber = "122333366";
            student1.Subject = "HR";
            student1.Course = "HR";
            student1.University = "KU";
        }

        // public static void StudentRandomInstances()
        // {
        //     students =;

        //     for (int i = 0; i < students.Length; i++)
        //     {
        //         students[i].Course = $"course-{i}";
        //         students[i].FullName = $"fullName-{i}";
        //         students[i].University = $"University-{i}";
        //         students[i].Email = $"myemail-{i}";
        //         students[i].PhoneNumber = $"phoneNumber-{i}";
        //         students[i].Subject = $"subject-{i}";

        //     }
        // }
    }

}