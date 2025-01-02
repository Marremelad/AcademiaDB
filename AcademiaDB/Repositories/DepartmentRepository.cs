using AcademiaDB.Data;
using AcademiaDB.Models;
using AcademiaDB.UserInterface.SelectionPrompts;

namespace AcademiaDB.Repositories;

public class DepartmentRepository
{
    private AcademiaContext _context;

    public DepartmentRepository(AcademiaContext context)
    {
        _context = context;
    }

    // Returns a list of department objects.
    public List<Department> GetDepartments()
    {
        var departments = _context.Departments
            .ToList();

        return departments;
    }

    // Displays a prompt with all departments in the database.
    // The selected department object is then used to filter the query and get the department's information.
    public string GetDepartmentInformation(List<Department> departments)
    {
        var selection = Prompt.DisplaySingleChoicePrompt("Select a department to se its information",
            departments);

        var departmentObject = (Department)selection;

        return GetInformationString(departmentObject);
    }

    // Returns a string with the selected department's information.
    private string GetInformationString(Department departmentObject)
    {
        return $"Department Information\n\n" +
               $"Department ID: {departmentObject.DepartmentId}\n" +
               $"Name: {departmentObject.DepartmentName}\n" +
               $"Number of registered employees: {NumberOfEmployeesInDepartment(departmentObject)}\n" +
               $"Total salary payout per month: {DepartmentSalaryPayoutPerMonth(departmentObject):C}\n" +
               $"Average salary: {DepartmentAverageSalary(departmentObject):C}";
    }

    // Returns the number of registered employees in a department.
    public int NumberOfEmployeesInDepartment(Department departmentObject)
    {
        var numberOfEmployees = _context.Employees
            .Where(e => e.DepartmentIdFk == departmentObject.DepartmentId)
            .ToList();

        return numberOfEmployees.Count;
    }

    // Returns the total salary payout per month in a department.
    public decimal DepartmentSalaryPayoutPerMonth(Department departmentObject)
    {
        var totalSalary = _context.Employees
            .Where(e => e.DepartmentIdFk == departmentObject.DepartmentId)
            .Sum(e => e.EmployeeSalary);

        return totalSalary;
    }

    // Returns the average salary per month in a department.
    public decimal DepartmentAverageSalary(Department departmentObject)
    {
        var medianSalary = _context.Employees
            .Where(e => e.DepartmentIdFk == departmentObject.DepartmentId)
            .Average(e => e.EmployeeSalary);

        return medianSalary;
    }
}