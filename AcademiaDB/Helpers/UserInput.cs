using System.Globalization;
using System.Text.RegularExpressions;
using AcademiaDB.Data;
using AcademiaDB.Models;
using AcademiaDB.Repositories;
using AcademiaDB.UserInterface.MenuOptions;
using AcademiaDB.UserInterface.SelectionPrompts;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Spectre.Console;

namespace AcademiaDB.Helpers;

public class UserInput
{
    private StudentRepository _studentRepository;
    private CourseRepository _courseRepository;

    public UserInput(
        CourseRepository courseRepository,
        StudentRepository studentRepository)
    {
        _courseRepository = courseRepository;
        _studentRepository = studentRepository;
    }
    
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
            Console.WriteLine("Last name can not be empty.");
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
            Console.WriteLine("Invalid SSN format. Please use yyyyMMdd-nnnn.");
            Thread.Sleep(2000);
        }
    }

    // Get student ID from user input.
    public int GetStudentId(string title)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(title);
            
            if (!int.TryParse(Console.ReadLine(), out var studentId))
            {
                Console.WriteLine("Student ID has to be a number.");
                Thread.Sleep(2000);
                continue;
            }

            if (_studentRepository.StudentExists(studentId)) return studentId;
            Console.WriteLine("The given ID is not tied to any student.");
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
            MenuText.Options.A1 => 1,
            MenuText.Options.B2 => 2,
            MenuText.Options.C3 => 3,
            MenuText.Options.D4 => 4,
            MenuText.Options.E5 => 5,
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
            MenuText.EmployeeRoleText);

        // Assigns the correct department depending on the chosen role.
        return (MenuText.Options)selection switch
        {
            MenuText.Options.Teacher => (1, 2),
            MenuText.Options.Administrator => (2, 3),
            MenuText.Options.Janitor => (3, 4),
            MenuText.Options.Security => (4, 5),
            _ => (0, 0)
        };
    }

    // Get course and grade setter when creating a new course enrolment.
    public (int, int) GetCourseAndGradeSetter(string title, int studentId)
    {
        Console.Clear();
        
        var student = _studentRepository.GetStudentById(studentId).Single();
        Console.WriteLine(_studentRepository.GetInformationString(student));
        
        var selection = Prompt.DisplaySingleChoicePrompt(title, _courseRepository.GetCourses());

        var course = (Course)selection;

        // Assigns the correct teacher depending on the chosen course.
        return course.CourseId switch
        {
            1 => (1, 3),
            2 => (2, 2),
            3 => (3, 7),
            4 => (4, 11),
            5 => (5, 9),
            _ => (0, 0)
        };
    }
}