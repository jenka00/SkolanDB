using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SkolanDB.Models
{
    public partial class Grades
    {
        public Grades()
        {
            StudentGrade = new HashSet<StudentGrade>();
        }

        public int GradeId { get; set; }
        public int Grade { get; set; }

        public virtual ICollection<StudentGrade> StudentGrade { get; set; }
    }
}
