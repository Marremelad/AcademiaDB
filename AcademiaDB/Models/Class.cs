using System;
using System.Collections.Generic;

namespace AcademiaDB.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public string ClassName { get; set; } = null!;

    public int EmployeeIdFk { get; set; }

    public virtual Employee EmployeeIdFkNavigation { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    // Returns a string with the name of the class.
    public override string ToString()
    {
        return $"{ClassName}";
    }
}
