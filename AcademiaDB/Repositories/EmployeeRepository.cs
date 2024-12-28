﻿using AcademiaDB.Data;
using AcademiaDB.Models;
using AcademiaDB.UserInterface.SelectionPrompts;
using Microsoft.EntityFrameworkCore;

namespace AcademiaDB.Repositories;

public class EmployeeRepository
{
    private AcademiaContext _context; // Private instance of AcademiaContext. Will be resolved by the DI container.
    
    public EmployeeRepository(AcademiaContext context)
    {
        _context = context;
    }
    
    // Returns a list of Employee objects.
    public List<Employee> GetEmployees()
    {
        var employees = _context.Employees
            .ToList();

        return employees;
    }
    
    // Displays a prompt with all employees in the database.
    // The selected employee object is then used to filter the query and get the employee's information.
    public string GetEmployeeInformation()
    {
        var selection = Prompt.DisplaySingleChoicePrompt(
            "Select an employee to see their information.",
            GetEmployees());

        var employeeObject = (Employee)selection;

        var employee = _context.Employees
            .Include(e => e.DepartmentIdFkNavigation)
            .Include(e => e.RoleIdFkNavigation)
            .SingleOrDefault(e => e.EmployeeId == employeeObject.EmployeeId);

        if (employee == null) return "No Information found.";

        return $"Employee Information\n" +
               $"ID: {employee.EmployeeId}\n" +
               $"Name: {employee.EmployeeFirstName} {employee.EmployeeLastName}\n" +
               $"SSN: {employee.EmployeeSsn}\n" +
               $"Department: {employee.DepartmentIdFkNavigation.DepartmentName}\n" +
               $"Role: {employee.RoleIdFkNavigation.RoleName}\n" +
               $"Start Date: {employee.EmployeeStartDate}\n" +
               $"Years In Service: {GetEmployeeYearsInService(employee):F1}";
    }
    
    // Calculates an employee's years in service.
    private double GetEmployeeYearsInService(Employee employee)
    {
        DateTime startDateTime = employee.EmployeeStartDate.ToDateTime(TimeOnly.MinValue);
        TimeSpan timeSpan = DateTime.Now - startDateTime;
        
        var yearsInService = timeSpan.TotalDays / 365.25;

        return yearsInService;
    }
}