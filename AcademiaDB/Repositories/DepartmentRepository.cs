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
               $"Name: {departmentObject.DepartmentName}";
    }
}