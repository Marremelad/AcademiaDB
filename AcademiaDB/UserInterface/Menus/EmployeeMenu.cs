using AcademiaDB.Helpers;
using AcademiaDB.Models;
using AcademiaDB.Repositories;
using AcademiaDB.UserInterface.MenuOptions;
using Microsoft.Identity.Client;
using Prompt = AcademiaDB.UserInterface.SelectionPrompts.Prompt;

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
        
        var listOfEmployees = new List<Employee>();
        switch (selection)
        {
            case MenuText.Options.AllEmployees:
                listOfEmployees = _employeeRepository.GetEmployees();
                break;
            
            case MenuText.Options.Principal:
                listOfEmployees = _employeeRepository.GetPrincipal();
                break;
            
            case MenuText.Options.Teacher:
                listOfEmployees = _employeeRepository.GetTeachers();
                break;
            
            case MenuText.Options.Administrator:
                listOfEmployees = _employeeRepository.GetAdministrators();
                break;
            
            case MenuText.Options.Janitor:
                listOfEmployees = _employeeRepository.GetJanitors();
                break;
            
            case MenuText.Options.Security:
                listOfEmployees = _employeeRepository.GetSecurity();
                break;
                
            case MenuText.Options.AddEmployee:
                _create.CreateNewEmployee();
                break;
            
            case MenuText.Options.Exit:
                return;
        }

        Console.WriteLine(_employeeRepository.GetEmployeeInformation(listOfEmployees));
    }
}