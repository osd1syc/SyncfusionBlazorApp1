﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SyncfusionBlazorApp1.Models;

public partial class Semester
{
    public int SemesterId { get; set; }

    public int YearOfSemester { get; set; }

    public int SemesterNo { get; set; }

    public int? SemesterYear { get; set; }

    public virtual ICollection<SemesterCourse> SemesterCourse { get; set; } = new List<SemesterCourse>();
}