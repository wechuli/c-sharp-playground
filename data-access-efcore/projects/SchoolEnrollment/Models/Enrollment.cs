using System;
using System.Collections.Generic;



namespace SchoolEnrollment
{
    public class Enrollment
    {



        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public string Grade { get; set; }

        public Course course { get; }
        public Student student { get; }

    }
}