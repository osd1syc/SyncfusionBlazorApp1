﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SyncfusionBlazorApp1.Models;

public partial class ProgramCourse
{
    public int ProgramCourseId { get; set; }

    public int CourseId { get; set; }

    public int ProgramId { get; set; }

    public virtual Course Course { get; set; }

    public virtual DegreeProgram Program { get; set; }
}