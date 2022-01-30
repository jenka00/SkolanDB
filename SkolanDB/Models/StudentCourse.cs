using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SkolanDB.Models
{
    public partial class StudentCourse
    {
        public int StudentCourseId { get; set; }
        public int? FkstudentId { get; set; }
        public int? FkcourseId { get; set; }
        public int? FkteacherId { get; set; }

        public virtual Course Fkcourse { get; set; }
        public virtual Student Fkstudent { get; set; }
        public virtual Teacher Fkteacher { get; set; }
    }
}
