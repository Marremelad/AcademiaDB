﻿using System;
using System.Collections.Generic;

namespace AcademiaDB.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmployeeFirstName { get; set; } = null!;

    public string EmployeeLastName { get; set; } = null!;

    public string EmployeeSsn { get; set; } = null!;

    public DateOnly EmployeeStartDate { get; set; }

    public decimal EmployeeSalary { get; set; }

    public int DepartmentIdFk { get; set; }

    public int RoleIdFk { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<CourseAssignment> CourseAssignments { get; set; } = new List<CourseAssignment>();

    public virtual ICollection<CourseEnrolment> CourseEnrolments { get; set; } = new List<CourseEnrolment>();

    public virtual Department DepartmentIdFkNavigation { get; set; } = null!;

    public virtual Role RoleIdFkNavigation { get; set; } = null!;
}
