using System.Runtime.InteropServices.JavaScript;
using AcademiaDB.Data;
using AcademiaDB.Models;
using Azure.Core;

namespace AcademiaDB.Repositories;

public class EmployeeRepository
{
    private AcademiaContext _context;

    public EmployeeRepository(AcademiaContext context)
    {
        _context = context;
    }

    public List<Employee> GetEmployees()
    {
        var employees = _context.Employees
            .ToList();

        return employees;
    }

    public string GetEmployeeInformation()
    {
        throw new NotImplementedException();
    }
}