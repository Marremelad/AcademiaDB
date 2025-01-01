using AcademiaDB.Models;
using AcademiaDB.UserInterface.MenuOptions;
using Spectre.Console;

namespace AcademiaDB.UserInterface.SelectionPrompts;

public class Prompt
{
    
    // Displays a single choice prompt. Overloaded to handle multiple data structures.
    public static object DisplaySingleChoicePrompt<T>(string title, T options)
    {
        var moreChoicesText = "Move up and down to reveal more options";
        
        // Handles a dictionary of type string and Menutext.Options.
        if (options is Dictionary<string, MenuText.Options> stringDict)
        {
            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(title)
                    .PageSize(10)
                    .MoreChoicesText(moreChoicesText)
                    .AddChoices(stringDict.Keys));

            return stringDict[selection];
        }

        // Handles a list of type string.
        if (options is List<string> stringList)
        {
            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(title)
                    .PageSize(10)
                    .MoreChoicesText(moreChoicesText)
                    .AddChoices(stringList));
            
            return selection;
        }
        
        // Handles a list of type Employee.
        if (options is List<Employee> employeeList)
        {
            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<Employee>()
                    .Title(title)
                    .PageSize(10)
                    .MoreChoicesText(moreChoicesText)
                    .AddChoices(employeeList));
            
            return selection;
        }
        
        if (options is List<Student> studentList)
        {
            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<Student>()
                    .Title(title)
                    .PageSize(10)
                    .MoreChoicesText(moreChoicesText)
                    .AddChoices(studentList));
            
            return selection;
        }
        
        if (options is List<CourseEnrolment> courseEnrolmentList)
        {
            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<CourseEnrolment>()
                    .Title(title)
                    .PageSize(10)
                    .MoreChoicesText(moreChoicesText)
                    .AddChoices(courseEnrolmentList));
            
            return selection;
        }
        
        if (options is List<Class> classList)
        {
            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<Class>()
                    .Title(title)
                    .PageSize(10)
                    .MoreChoicesText(moreChoicesText)
                    .AddChoices(classList));
            
            return selection;
        }
        
        if (options is List<Department> departmentList)
        {
            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<Department>()
                    .Title(title)
                    .PageSize(10)
                    .MoreChoicesText(moreChoicesText)
                    .AddChoices(departmentList));
            
            return selection;
        }
        
        throw new ArgumentException("Invalid choice type provided.");
    }


    // Displays a multi choice prompt.
    public static List<string> DisplayMultiChoicePrompt(string title,
        Dictionary<string, MenuOptions.MenuText.Options> options)
    {
        var multipleSelections = AnsiConsole.Prompt(
            new MultiSelectionPrompt<string>()
                .Title(title)
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                .InstructionsText(
                    "[grey](Press [blue]<space>[/] to toggle an option, " + 
                    "[green]<enter>[/] to accept)[/]")
                .AddChoices(options.Select(s => s.Key)));

        return multipleSelections;
    }
}