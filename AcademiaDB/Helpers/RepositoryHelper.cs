using AcademiaDB.Models;

namespace AcademiaDB.Repositories;

public static class RepositoryHelpers
{
    // Calculates an employee's years in service.
    public static double GetEmployeeYearsInService(Employee employee)
    {
        DateTime startDateTime = employee.EmployeeStartDate.ToDateTime(TimeOnly.MinValue);
        TimeSpan timeSpan = DateTime.Now - startDateTime;
        
        var yearsInService = timeSpan.TotalDays / 365.25;

        return yearsInService;
    }
}