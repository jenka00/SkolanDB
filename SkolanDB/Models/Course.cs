using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SkolanDB.Models
{
    public partial class Course
    {
        public Course()
        {
            StudentCourse = new HashSet<StudentCourse>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int? CourseLenghtDays { get; set; }
        public int? FkdepartmentId { get; set; }

        public virtual Department Fkdepartment { get; set; }
        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
