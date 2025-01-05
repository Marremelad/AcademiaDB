using AcademiaDB.Data;
using AcademiaDB.Helpers;
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

    // Returns a list of Employee objects with the role 'Principal'. Should only be one at a time.
    public List<Employee> GetPrincipal()
    {
        var principal = _context.Employees
            .Where(e => e.RoleIdFkNavigation.RoleName == "Principal")
            .ToList();
        
        if (principal.Count > 1)
        {
            throw new InvalidOperationException("WARNING: There seems to be more than one principal registered at your school. " +
                                                "Check the database and make sure that only one employee is registered with the role 'Principal'.");
        }
        
        return principal;
    }

    // Returns a list of employee objects with the role 'Teacher'.
    public List<Employee> GetTeachers()
    {
        var teachers = _context.Employees
            .Where(e => e.RoleIdFkNavigation.RoleName == "Teacher")
            .ToList();
        
        return teachers;
    }
    
    // Returns a list of employee objects with the role 'Administrator'.
    public List<Employee> GetAdministrators()
    {
        var administrators = _context.Employees
            .Where(e => e.RoleIdFkNavigation.RoleName == "Administrator")
            .ToList();

        return administrators;
    }
    
    // Returns a list of employee objects with the role 'Janitor'.
    public List<Employee> GetJanitors()
    {
        var janitors = _context.Employees
            .Where(e => e.RoleIdFkNavigation.RoleName == "Janitor")
            .ToList();

        return janitors;
    }

    // Returns a list of employee objects with the role 'Security'.
    public List<Employee> GetSecurity()
    {
        var security = _context.Employees
            .Where(e => e.RoleIdFkNavigation.RoleName == "Security")
            .ToList();

        return security;
    }
    
    // Displays a prompt with all employees in the database.
    // The selected employee object is then used to filter the query and get the employee's information.
    public string GetEmployeeInformation(List<Employee> employees)
    {
        var selection = Prompt.DisplaySingleChoicePrompt(
            "Select an employee to see their information.",
            employees);

        var employeeObject = (Employee)selection;

        return GetInformationString(employeeObject);
    }
    
    // Returns a string with the selected employee's information.
    private string GetInformationString(Employee employeeObject)
    {
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
               $"Salary: {employee.EmployeeSalary:C}\n" +
               $"Start Date: {employee.EmployeeStartDate}\n" +
               $"Years In Service: {RepositoryHelper.GetEmployeeYearsInService(employee):F1}";
    }
    
    // Adds a new employee to the database.
    public void AddEmployeeToDatabase(string firstName, string lastName, string ssn,
        DateOnly startDate, decimal salary, int department, int role)
    {
        var newEmployee = new Employee()
        {
            EmployeeFirstName = firstName,
            EmployeeLastName = lastName,
            EmployeeSsn = ssn,
            EmployeeStartDate = startDate,
            EmployeeSalary = salary,
            DepartmentIdFk = department,
            RoleIdFk = role
        };
        
        try
        {
            _context.Employees.Add(newEmployee);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            Console.WriteLine("Something went wrong while attempting to add a new employee to the database.\n" +
                              "Rolling back changes...");
            return;
        }
        
        Console.Clear();
        Console.WriteLine("New employee added successfully.");
    }
}