using System;
using System.Collections.Generic;

namespace AcademiaDB.Models;

public partial class CourseAssignment
{
    public int AssignmentId { get; set; }

    public int EmployeeIdFk { get; set; }

    public int CourseIdFk { get; set; }

    public virtual Course CourseIdFkNavigation { get; set; } = null!;

    public virtual Employee EmployeeIdFkNavigation { get; set; } = null!;
}
