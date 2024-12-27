using AcademiaDB.Repositories;

namespace AcademiaDB.Views;

public class MainMenu
{
    private EmployeeRepository _employeeRepository;

    public MainMenu(EmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
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
            default:
                Console.WriteLine("Hello, World!");
                break;
        }
    }
}