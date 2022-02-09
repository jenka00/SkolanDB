using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SkolanDB.Models
{
    public partial class VWgradesOneMonth
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string CourseName { get; set; }
        public DateTime GradeDate { get; set; }
        public int? Grade { get; set; }
    }
}
