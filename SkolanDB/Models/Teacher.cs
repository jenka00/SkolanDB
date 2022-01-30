using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SkolanDB.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            StudentCourse = new HashSet<StudentCourse>();
            StudentGrade = new HashSet<StudentGrade>();
        }

        public int TeacherId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Role { get; set; }

        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
        public virtual ICollection<StudentGrade> StudentGrade { get; set; }
    }
}
