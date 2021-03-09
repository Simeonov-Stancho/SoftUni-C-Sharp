using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public Student Students { get; set; }

        public int CourseId { get; set; }
        public Course Courses { get; set; }
    }
}
