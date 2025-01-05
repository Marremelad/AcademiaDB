using AcademiaDB.Models;
using AcademiaDB.Repositories;
using AcademiaDB.UserInterface.MenuOptions;
using AcademiaDB.UserInterface.SelectionPrompts;
using Spectre.Console;

namespace AcademiaDB.UserInterface.Menus;

public class MainMenu
{
    private EmployeeMenu _employeeMenu;
    private DepartmentMenu _departmentMenu;
    private StudentMenu _studentMenu;
    private ClassMenu _classMenu;
    private CourseMenu _courseMenu;
    private ViewRepository _viewRepository;

    public MainMenu(
        EmployeeMenu employeeMenu,
        DepartmentMenu departmentMenu,
        StudentMenu studentMenu,
        ClassMenu classMenu,
        CourseMenu courseMenu,
        ViewRepository viewRepository
    )
    {
        _employeeMenu = employeeMenu;
        _departmentMenu = departmentMenu; 
        _studentMenu = studentMenu;
        _classMenu = classMenu;
        _courseMenu = courseMenu;
        _viewRepository = viewRepository;
    }

    // Displays the main menu through the single choice prompt.
    public void DisplayMainMenu()
    {
        while (true)
        {
            Console.Clear();
            var selection = Prompt.DisplaySingleChoicePrompt("Welcome to AcademiaDB!", MenuText.MainMenuText);

            switch (selection)
            {
                case MenuText.Options.Employees:
                    _employeeMenu.DisplayEmployeeMenu();
                    break;
                
                case MenuText.Options.Departments:
                    _departmentMenu.DisplayDepartmentMenu();
                    break;
                
                case MenuText.Options.Students:
                    _studentMenu.DisplayStudentMenu();
                    break;
                
                case MenuText.Options.Classes:
                    _classMenu.DisplayClassMenu();
                    break;

                case MenuText.Options.Courses:
                    _courseMenu.DisplayCourseMenu();
                    break;
                
                case MenuText.Options.TopGrades:
                    Console.WriteLine(_viewRepository.GetTopGrades());
                    break;
                
                case MenuText.Options.Exit:
                    return;
            }
        
            AnsiConsole.MarkupLine("\n[green]'Q'[/] to quit, or [green]Enter[/] to get back to the main menu.");
            
            if (Console.ReadLine() == "Q".ToLower()) break;
        }
    }
}