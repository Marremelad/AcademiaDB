using System;
using System.Collections.Generic;

namespace AcademiaDB.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    public override string ToString()
    {
        return $"{DepartmentName}";
    }
}
