﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SkolanDB.Models
{
    public partial class VWshowAllTeachers
    {
        public int EmploymentId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string RoleName { get; set; }
    }
}
