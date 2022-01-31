﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SkolanDB.Models
{
    public partial class VWgradesChemistry1
    {
        public string CourseName { get; set; }
        public int? AverageGrade { get; set; }
        public int? HighestGrade { get; set; }
        public int? LowestGrade { get; set; }
    }
}
