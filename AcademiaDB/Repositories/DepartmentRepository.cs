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

    public List<Department> GetDepartments()
    {
        var departments = _context.Departments
            .ToList();

        return departments;
    }

    public string GetDepartmentInformation(List<Department> departments)
    {
        var selection = Prompt.DisplaySingleChoicePrompt("Select a department to se its information",
            GetDepartments());

        var departmentObject = (Department)selection;

        return GetInformationString(departmentObject);
    }

    public string GetInformationString(Department departmentObject)
    {
        return $"Department Information\n\n" +
               $"Department ID: {departmentObject.DepartmentId}\n" +
               $"Name: {departmentObject.DepartmentName}\n" +
               $"Number of registered employees: {NumberOfEmployeesInDepartment(departmentObject)}\n" +
               $"Total salary payout per month: {DepartmentSalaryPayoutPerMonth(departmentObject):C}\n" +
               $"Average salary: {DepartmentAverageSalary(departmentObject):C}";
    }

    public int NumberOfEmployeesInDepartment(Department departmentObject)
    {
        var numberOfEmployees = _context.Employees
            .Where(e => e.DepartmentIdFk == departmentObject.DepartmentId)
            .ToList();

        return numberOfEmployees.Count;
    }

    public decimal DepartmentSalaryPayoutPerMonth(Department departmentObject)
    {
        var totalSalary = _context.Employees
            .Where(e => e.DepartmentIdFk == departmentObject.DepartmentId)
            .Sum(e => e.EmployeeSalary);

        return totalSalary;
    }

    public decimal DepartmentAverageSalary(Department departmentObject)
    {
        var medianSalary = _context.Employees
            .Where(e => e.DepartmentIdFk == departmentObject.DepartmentId)
            .Average(e => e.EmployeeSalary);

        return medianSalary;
    }
}