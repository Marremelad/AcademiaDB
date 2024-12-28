using AcademiaDB.Models;
using AcademiaDB.Repositories;
using AcademiaDB.UserInterface.MenuOptions;
using AcademiaDB.UserInterface.SelectionPrompts;

namespace AcademiaDB.UserInterface.Menus;

public class EmployeeMenu
{
    private EmployeeRepository _employeeRepository; // Private instance of EmployeeRepository. Will be resolved by DI container.

    public EmployeeMenu(EmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
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
        }
    }
}