using System;

namespace ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentTest mytest = new StudentTest();
            mytest.CheckNumberOfStudents();
            mytest.PrintStudentsDetails();

            mytest.UpdateStudent1Details();

            mytest.PrintStudentsDetails();


            mytest.CheckNumberOfStudents();

            var allStudents = StudentTest.Students;

            foreach (var student in allStudents)
            {
                student.DisplayStudentInfo();
            }
            //create ten student classes
            //StudentTest.StudentRandomInstances();

            // foreach (var student in StudentTest.Students)
            // {
            //     student.DisplayStudentInfo();
            // }
        }
    }
}
