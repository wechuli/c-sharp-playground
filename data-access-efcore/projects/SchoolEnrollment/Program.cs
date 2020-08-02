using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConsoleTables;

namespace SchoolEnrollment
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var schoolContext = new SchoolContext())
            {
                //await schoolContext.Database.MigrateAsync();
                await schoolContext.Database.EnsureCreatedAsync();

                Course course1 = new Course
                {
                    Title = "Computer Algorithms",
                    Credits = 45
                };
                Course course2 = new Course
                {
                    Title = "Philosophy",
                    Credits = 35
                };


                //schoolContext.Courses.Add(course1);
                //schoolContext.Courses.Add(course2);
                //schoolContext.SaveChanges();

                AddStudents(schoolContext);

                var countStudents = await schoolContext.Students.CountAsync();

                Console.WriteLine(countStudents);

                // var allCourses = await schoolContext.Courses.CountAsync();
                // Console.WriteLine(allCourses);

            }
        }

        public static void AddStudents(SchoolContext schoolContext)
        {
            var student1 = new Student { LastName = "Wechuli", FirstMidName = "Paul", EnrollmentDate = DateTime.Now.ToUniversalTime() };
            var student2 = new Student { LastName = "Nanjala", FirstMidName = "Mercyline", EnrollmentDate = DateTime.Now.AddDays(896).ToUniversalTime() };

            ICollection<Student> students = new List<Student> { student1, student2 };


            schoolContext.Students.AddRange(students);
            schoolContext.SaveChanges();

        }
    }
}
