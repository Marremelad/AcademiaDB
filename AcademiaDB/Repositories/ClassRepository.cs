using AcademiaDB.Data;
using AcademiaDB.Models;
using AcademiaDB.UserInterface.SelectionPrompts;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace AcademiaDB.Repositories;

public class ClassRepository
{
    private AcademiaContext _context;

    public ClassRepository(AcademiaContext context)
    {
        _context = context;
    }

    public List<Class> GetClasses()
    {
        var classes = _context.Classes
            .ToList();

        return classes;
    }

    public string GetClassInformation()
    {
        var classes = GetClasses();
        var selection = Prompt.DisplaySingleChoicePrompt("Select a class to see its information", classes);

        var classObject = (Class)selection;
        
        return GetInformationString(classObject);
    }

    public string GetInformationString(Class classObject)
    {
        var thisClass = _context.Classes
            .Include(c => c.EmployeeIdFkNavigation)
            .SingleOrDefault(c => c.ClassId == classObject.ClassId);

        return $"Class Information" +
               $"Name: {thisClass?.ClassName}" +
               $"Administrator: {thisClass?.EmployeeIdFkNavigation.EmployeeFirstName} " +
               $"{thisClass?.EmployeeIdFkNavigation.EmployeeLastName}";
    }
}