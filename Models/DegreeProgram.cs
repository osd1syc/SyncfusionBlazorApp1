﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SyncfusionBlazorApp1.Models;

public partial class DegreeProgram
{
    public int DegreeProgramId { get; set; }

    public string DegreeProgramName { get; set; }

    public int CampusId { get; set; }

    public int RequiredCredits { get; set; }

    public int FacultyId { get; set; }

    public virtual Campus Campus { get; set; }

    public virtual Faculty Faculty { get; set; }

    public virtual ICollection<ProgramCourse> ProgramCourse { get; set; } = new List<ProgramCourse>();

    public virtual ICollection<Student> Student { get; set; } = new List<Student>();
}