using AcademiaDB.Repositories;
using AcademiaDB.UserInterface.MenuOptions;
using AcademiaDB.UserInterface.SelectionPrompts;
using Microsoft.Extensions.Options;

namespace AcademiaDB.UserInterface.Menus;

public class MainMenu
{
    private EmployeeRepository _employeeRepository;
    private ViewRepository _viewRepository;

    public MainMenu(
        EmployeeRepository employeeRepository,
        ViewRepository viewRepository
    )
    {
        _employeeRepository = employeeRepository;
        _viewRepository = viewRepository;
    }

    public void DisplayMainMenu()
    {
        var selection = Selection.DisplaySingleChoiceSelection("Welcome to Academia!", MenuText.MainMenuText);

        switch (selection)
        {
            case MenuText.Options.Employees:
                Console.WriteLine(_employeeRepository.GetEmployeeNames());
                break;
            
            case MenuText.Options.Students:
                Console.WriteLine(_viewRepository.GetTopGrades());
                break;
        }
    }
}