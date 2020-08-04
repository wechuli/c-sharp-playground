using System;
using System.Collections.Generic;


namespace schoolEnrollmentPos
{
    public class Student
    {
        public int StudentID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }


        public ICollection<Enrollment> enrollments { get; }

    }
}