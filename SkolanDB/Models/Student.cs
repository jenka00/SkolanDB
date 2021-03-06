using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SkolanDB.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentCourse = new HashSet<StudentCourse>();
        }

        public int StudentId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string PersonalNumber { get; set; }
        public string Role { get; set; }
        public int FkclassId { get; set; }

        public virtual Class Fkclass { get; set; }
        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
