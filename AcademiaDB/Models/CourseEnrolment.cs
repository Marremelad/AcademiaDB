using System;
using System.Collections.Generic;

namespace AcademiaDB.Models;

public partial class CourseEnrolment
{
    public int EnrolmentId { get; set; }

    public int StudentIdFk { get; set; }

    public int CourseIdFk { get; set; }

    public string? Grade { get; set; }

    public int? GradeSetterFk { get; set; }

    public int? GradingDate { get; set; }

    public virtual Course CourseIdFkNavigation { get; set; } = null!;

    public virtual Employee? GradeSetterFkNavigation { get; set; }

    public virtual Student StudentIdFkNavigation { get; set; } = null!;
}
