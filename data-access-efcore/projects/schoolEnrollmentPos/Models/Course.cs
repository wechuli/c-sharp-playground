using System;
using System.Collections.Generic;


namespace schoolEnrollmentPos
{
    public class Course
    {

        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment> enrollments { get; }

    }
}