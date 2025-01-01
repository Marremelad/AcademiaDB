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

    // Returns a list of class objects.
    public List<Class> GetClasses()
    {
        var classes = _context.Classes
            .ToList();

        return classes;
    }

    // Displays a prompt with all classes in the database.
    // The selected class object is then used to filter the query and get the class's information.
    public string GetClassInformation()
    {
        var classes = GetClasses();
        var selection = Prompt.DisplaySingleChoicePrompt("Select a class to see its information", classes);

        var classObject = (Class)selection;
        
        return GetInformationString(classObject);
    }

    // Returns a string with the selected class's information.
    public string GetInformationString(Class classObject)
    {
        var thisClass = _context.Classes
            .Include(c => c.EmployeeIdFkNavigation)
            .SingleOrDefault(c => c.ClassId == classObject.ClassId);

        return $"Class Information\n\n" +
               $"Name: {thisClass?.ClassName}\n" +
               $"Administrator: {thisClass?.EmployeeIdFkNavigation.EmployeeFirstName} " +
               $"{thisClass?.EmployeeIdFkNavigation.EmployeeLastName}\n" +
               $"Number of registered students: {NumberOfStudentsInAClass(classObject)}";
    }

    // Returns the number of registered students in a class.
    public int NumberOfStudentsInAClass(Class classObject)
    {
        var numberOfStudent = _context.Students
            .Where(s => s.ClassIdFk == classObject.ClassId)
            .ToList();

        return numberOfStudent.Count;
    }
}