﻿using System;
using System.Collections.Generic;
using AcademiaDB.Data;
using Microsoft.EntityFrameworkCore;

namespace AcademiaDB.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string StudentFirstName { get; set; } = null!;

    public string StudentLastName { get; set; } = null!;

    public string StudentSsn { get; set; } = null!;

    public int ClassIdFk { get; set; }

    public virtual Class ClassIdFkNavigation { get; set; } = null!;

    public virtual ICollection<CourseEnrolment> CourseEnrolments { get; set; } = new List<CourseEnrolment>();
    
    public override string ToString()
    {
        using (var context = new AcademiaContext())
        {
            var student = context.Students
                .Include(i => i.ClassIdFkNavigation)
                .SingleOrDefault(s => s.StudentId == StudentId);
            
            return $"{StudentFirstName} {StudentLastName}: {student?.ClassIdFkNavigation.ClassName}";
        }
    }
}
