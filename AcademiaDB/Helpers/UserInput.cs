using System.Globalization;
using System.Text.RegularExpressions;
using AcademiaDB.UserInterface.MenuOptions;
using AcademiaDB.UserInterface.SelectionPrompts;

namespace AcademiaDB.Helpers;

public static class UserInput
{
    
    // Get first name from user input.
    public static string GetFirstName(string title)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(title);
            
            var firstName = Console.ReadLine();
            
            if (!string.IsNullOrEmpty(firstName)) return firstName;
            Console.WriteLine("First name can not be empty.");
            Thread.Sleep(2000);
        }
    }

    // Get last name from user input.
    public static string GetLastName(string title)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(title);
            
            var lastName = Console.ReadLine();

            if (!string.IsNullOrEmpty(lastName)) return lastName;
            Console.WriteLine("Last name can not be empty");
            Thread.Sleep(2000);
        }
    }

    
    // Get SSN from user input.
    public static string GetSsn(string title)
    {
        const string pattern = @"^\d{8}-\d{4}$";
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine(title);
            
            var ssn = Console.ReadLine();
            
            if (ssn != null && Regex.IsMatch(ssn, pattern)) return ssn;
            Console.WriteLine("Invalid SSN format.");
            Thread.Sleep(2000);
        }
    }

    // Get class ID from user input.
    public static int GetClassId(string title)
    {
        Console.Clear();
        
        var choice = Prompt.DisplaySingleChoicePrompt(title,
            MenuText.ClassMenuText);
        
        return (MenuText.Options)choice switch
        {
            MenuText.Options.SoftwareEngineering => 1,
            MenuText.Options.DataScience => 2,
            MenuText.Options.AiAndMachineLearning => 3,
            _ => 0
        };
    }
    
    // Get employee start date from user input.
    public static DateOnly GetEmployeeStartDate(string title)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(title);

            var input = Console.ReadLine();

            // Attempt to parse the input into a DateTime object
            if (DateTime.TryParseExact(input, "yyyy-MM-dd",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out var startDate))
                return DateOnly.FromDateTime(startDate);
            
            Console.WriteLine("Invalid date format. Please use yyyy-MM-dd.");
            Thread.Sleep(2000);
        }
    }

    
    // Get employee salary from user input.
    public static decimal GetEmployeeSalary(string title)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(title);

            if (decimal.TryParse(Console.ReadLine(), out var salary)) return salary;
            Console.WriteLine("Invalid input.");
            Thread.Sleep(2000);
        }
    }
    
    // Get employee role and department from user input.
    public static (int, int) GetEmployeeDepartmentAndRole(string title)
    {
        Console.Clear();
        var selection = Prompt.DisplaySingleChoicePrompt(title,
            MenuText.EmployeeRoleMenuText);

        // Assigns the correct department depending on the chosen role.
        return (MenuText.Options)selection switch
        {
            MenuText.Options.Principal => (1, 1),
            MenuText.Options.Teacher => (1, 2),
            MenuText.Options.Administrator => (2, 3),
            MenuText.Options.Janitor => (3, 4),
            MenuText.Options.Security => (4, 5),
            _ => (0, 0)
        };
    }
}