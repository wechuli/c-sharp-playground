using System;
using System.Collections.Generic;


namespace hashset
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> aspNetStudents = new HashSet<string>();
            aspNetStudents.Add("S. Jobs");
            aspNetStudents.Add("B. Gates");
            aspNetStudents.Add("M. Dell");


            HashSet<string> silverlightStudents = new HashSet<string>();
            silverlightStudents.Add("M. Zuckerberg");
            silverlightStudents.Add("M. Dell");

            HashSet<string> allStudents = new HashSet<string>();
            allStudents.UnionWith(aspNetStudents);
            allStudents.UnionWith(silverlightStudents);


            HashSet<string> intersectStudents = new HashSet<string>(aspNetStudents);
            intersectStudents.IntersectWith(silverlightStudents);


            Console.WriteLine("ASP.NET students: " + string.Join(", ", aspNetStudents));
            Console.WriteLine("Silverlight students: " +
            string.Join(", ", silverlightStudents));
            Console.WriteLine("All students: " +
            string.Join(", ", allStudents));
            Console.WriteLine(
            "Students in both ASP.NET and Silverlight: " +
            string.Join(", ", intersectStudents));
        }
    }
}
