using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SkolanDB.Models
{
    public partial class Employee
    {
        public Employee()
        {
            StudentCourse = new HashSet<StudentCourse>();
        }

        public int EmploymentId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime StartDate { get; set; }
        public decimal Salary { get; set; }
        public int FkroleId { get; set; }

        public virtual Role Fkrole { get; set; }
        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
