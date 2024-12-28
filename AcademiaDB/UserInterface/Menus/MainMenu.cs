using AcademiaDB.Repositories;
using AcademiaDB.UserInterface.MenuOptions;
using AcademiaDB.UserInterface.SelectionPrompts;
using Microsoft.Extensions.Options;
using Spectre.Console;

namespace AcademiaDB.UserInterface.Menus;

public class MainMenu
{
    private EmployeeRepository _employeeRepository; // Private instance of EmployeeRepository. Will be resolved by DI container.
    private EmployeeMenu _employeeMenu; // Private instance of EmployeeMenu. Will be resolved by DI container.
    private ViewRepository _viewRepository; // Private instance of ViewRepository. Will be resolved by DI container.

    public MainMenu(
        EmployeeRepository employeeRepository, 
        EmployeeMenu employeeMenu, 
        ViewRepository viewRepository 
    )
    {
        _employeeRepository = employeeRepository;
        _employeeMenu = employeeMenu;
        _viewRepository = viewRepository;
    }

    // Displays the main menu through the single choice prompt.
    public void DisplayMainMenu()
    {
        while (true)
        {
            Console.Clear();
            var selection = Prompt.DisplaySingleChoicePrompt("Welcome to Academia!", MenuText.MainMenuText);

            switch (selection)
            {
                case MenuText.Options.Employees:
                    _employeeMenu.DisplayEmployeeMenu();
                    break;
            
                case MenuText.Options.Students:
                    Console.WriteLine(_viewRepository.GetTopGrades());
                    break;
            }
        
            AnsiConsole.MarkupLine("\n[green]'Q'[/] to quit, or [green]Enter[/] to get back to the main menu");
            
            if (Console.ReadLine() == "Q".ToLower()) break;
        }
    }
}