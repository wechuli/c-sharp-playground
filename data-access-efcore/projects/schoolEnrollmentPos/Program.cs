using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace schoolEnrollmentPos
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var schoolContext = new SchoolContext())
            {



                await AddSomeStudents(schoolContext);


            }
        }

        static async Task AddSomeStudents(SchoolContext schoolContext)
        {

            var student1 = new Student { LastName = "Wechuli", FirstMidName = "Paul", EnrollmentDate = DateTime.Now.AddYears(-3) };
            var student2 = new Student { LastName = "Chep", FirstMidName = "Jennifer", EnrollmentDate = DateTime.Now.AddYears(1) };

            var allStudents = new List<Student> { student1, student2 };

            await schoolContext.AddRangeAsync(allStudents);
            await schoolContext.SaveChangesAsync();

        }
    }
}
