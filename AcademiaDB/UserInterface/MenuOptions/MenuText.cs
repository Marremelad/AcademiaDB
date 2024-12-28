namespace AcademiaDB.UserInterface.MenuOptions;

public class MenuText
{
    public enum Options
    {
        // Main Menu.
        Employees,
        Students,
        Classes,
        Courses,
        RecentlySetGrades,
        AddStudent,
        Exit,
        
        // Employee Menu.
        AllEmployees,
        Principal,
        Teacher,
        Administrator,
        Janitor,
        Security,
        AddEmployee,
        
        // Student Menu.
        SortByFirstName, // 14
        SortByLastName, // 15
        OrderByDescending, // 16
        OrderByAscending, // 17
        
        // Class Menu.
        SoftwareEngineering,
        DataScience,
        AiAndMachineLearning,
        
    }
    
    // Main Menu Options.
    public static readonly Dictionary<string, Options> MainMenuText = new()
    {
        { "Employees", Options.Employees },
        { "Students", Options.Students },
        { "Classes", Options.Classes },
        { "Courses", Options.Courses },
        { "Recently set grades", Options.RecentlySetGrades },
        { "Add a student", Options.AddStudent },
        { "Add an employee", Options.AddEmployee },
        { "Exit", Options.Exit }
    };
    
    // Employee Menu Options.
    public static readonly Dictionary<string, Options> EmployeeMenuText = new()
    {
        { "All employees", Options.AllEmployees},
        { "Principal", Options.Principal },
        { "Teachers", Options.Teacher },
        { "Administrators", Options.Administrator },
        { "Janitors", Options.Janitor },
        { "Security", Options.Security },
        { "Add a new employee", Options.AddEmployee }
    };
    
    // Employee Role Assignment Options
    public static readonly Dictionary<string, Options> EmployeeRoleMenuText = new()
    {
        { "Principal", Options.Principal },
        { "Teacher", Options.Teacher },
        { "Administrator", Options.Administrator },
        { "Janitor", Options.Janitor },
        { "Security", Options.Security },
    };

    // Student Menu Options.
    public static readonly Dictionary<string, Options> StudentMenuText = new()
    {
        { "Sort by First Name", Options.SortByFirstName },
        { "Sort by Last Name", Options.SortByLastName },
        { "Order by Descending", Options.OrderByDescending },
        { "Order by Ascending", Options.OrderByAscending }
    };

    // Class Menu Options.
    public static readonly Dictionary<string, Options> ClassMenuText = new()
    {
        { "SoftwareEngineering2024", Options.SoftwareEngineering },
        { "DataScience2024", Options.DataScience },
        { "AIAndMachineLearning2024", Options.AiAndMachineLearning }
    };
}
