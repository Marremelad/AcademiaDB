using AcademiaDB.Repositories;

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

    public void Display()
    {
        Console.WriteLine("Write something.");
        var userInput = Console.ReadLine();

        switch (userInput)
        {
            case "a":
                Console.WriteLine(_employeeRepository.GetEmployeeNames());
                break;
            
            case "v":
                Console.WriteLine(_viewRepository.GetTopGrades());
                break;
            
            default:
                Console.WriteLine("Hello, World!");
                break;
        }
    }
}