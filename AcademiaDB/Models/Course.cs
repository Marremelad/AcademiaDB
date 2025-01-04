using System;
using System.Collections.Generic;

namespace AcademiaDB.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public bool Active { get; set; }

    public virtual ICollection<CourseAssignment> CourseAssignments { get; set; } = new List<CourseAssignment>();

    public virtual ICollection<CourseEnrolment> CourseEnrolments { get; set; } = new List<CourseEnrolment>();

    // Returns a string with the name of the course.
    public override string ToString()
    {
        return $"{CourseName}";
    }
}
