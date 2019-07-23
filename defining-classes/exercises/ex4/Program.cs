using System;

namespace ex4
{
    class Program
    {
        static void Main(string[] args)
        {
            // create some disciplines

            var disc1 = new Discipline("Databases", 14, 28);
            var disc2 = new Discipline("Algorithms", 14, 40);
            var disc3 = new Discipline("Psychology", 8, 4);
            var disc4 = new Discipline("Hygrometer", 2, 5);

            //create some teachers - add disciplines to them

            var teacher1 = new Teacher("Paul Wechuli");
            var teacher2 = new Teacher("Dr Suess");

            teacher1.AddDisciplineToTeacher(disc1);
            teacher1.AddDisciplineToTeacher(disc2);
            teacher2.AddDisciplineToTeacher(disc3);
            teacher2.AddDisciplineToTeacher(disc4);

            //create some students

            var student1 = new Student("Nelly", "1");
            var student2 = new Student("John", "2");
            var student3 = new Student("Obed", "3");
            var student4 = new Student("Jackie", "4");

            //create a class - add teachers, add students

            var kibabii = new SchoolClass("Ng'ombe");
            kibabii.AddStudentsToClass(student1, student2, student3, student4);
            kibabii.AddTeachersToClass(teacher1, teacher2);



            kibabii.DisplayClassInfo();

        }
    }
}
