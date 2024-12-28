using System.Linq.Expressions;
using System.Text.RegularExpressions;
using AcademiaDB.Models;
using AcademiaDB.UserInterface.MenuOptions;
using AcademiaDB.UserInterface.SelectionPrompts;
using Spectre.Console;

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

        int classId = 0;
        switch ((MenuText.Options)choice)
        {
            case MenuText.Options.SoftwareEngineering:
                classId = 1;
                break;
            
            case MenuText.Options.DataScience:
                classId = 2;
                break;
            
            case MenuText.Options.AiAndMachineLearning:
                classId = 3;
                break;
        }

        return classId;
    }
}