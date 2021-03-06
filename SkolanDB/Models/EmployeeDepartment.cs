using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SkolanDB.Models
{
    public partial class EmployeeDepartment
    {
        public int EmpDepId { get; set; }
        public int FkdepartmentId { get; set; }
        public int FkemploymentId { get; set; }

        public virtual Department Fkdepartment { get; set; }
        public virtual Employee Fkemployment { get; set; }
    }
}
