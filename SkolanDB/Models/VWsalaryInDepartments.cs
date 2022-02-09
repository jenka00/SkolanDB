using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SkolanDB.Models
{
    public partial class VWsalaryInDepartments
    {
        public string DepartmentName { get; set; }
        public decimal? SumSalaryMonth { get; set; }
        public decimal? AverageSalary { get; set; }
    }
}
