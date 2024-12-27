using AcademiaDB.Data;

namespace AcademiaDB.Repositories;

public class EmployeeRepository
{
    private AcademiaContext _context;

    public EmployeeRepository(AcademiaContext context)
    {
        _context = context;
    }

    public string GetEmployeeNames()
    {
        var employeeNames = _context.Employees
            .Select(s => $"{s.EmployeeFirstName} {s.EmployeeLastName}")
            .ToList();

        var result = string.Join("\n", employeeNames);
        return result;
    }
}