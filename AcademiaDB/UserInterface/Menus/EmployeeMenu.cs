using AcademiaDB.Helpers;
using AcademiaDB.Models;
using AcademiaDB.Repositories;
using AcademiaDB.UserInterface.MenuOptions;
using AcademiaDB.UserInterface.SelectionPrompts;

namespace AcademiaDB.UserInterface.Menus;

public class EmployeeMenu
{
    private readonly EmployeeRepository _employeeRepository; // Private instance of EmployeeRepository. Will be resolved by DI container.
    private readonly Create _create; // Private instance of Create. Will be resolved by DI container.

    public EmployeeMenu(
        EmployeeRepository employeeRepository,
        Create create
    )
    {
        _employeeRepository = employeeRepository;
        _create = create;
    }

    // Displays the employee menu through the single choice prompt.
    public void DisplayEmployeeMenu()
    {
        var selection = Prompt.DisplaySingleChoicePrompt("Employee Menu", MenuText.EmployeeMenuText);

        switch (selection)
        {
            case MenuText.Options.AllEmployees:
                Console.WriteLine(_employeeRepository.GetEmployeeInformation());
                break;
            
            case MenuText.Options.AddEmployee:
                _create.CreateNewEmployee();
                break;
        }
    }
}