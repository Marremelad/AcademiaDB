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
        AddEmployee,
        Exit,
        
        // Employee Menu.
        AllEmployees,
        AllEmployeesWithAssignedRoles,
        Principal,
        Teacher,
        Administrator,
        Janitor,
        Security,
        
        // Student Menu.
        SortByFirstName, // 15
        SortByLastName, // 16
        OrderByDescending, // 17
        OrderByAscending, // 18
        
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
        { "All employees with assigned roles", Options.AllEmployeesWithAssignedRoles},
        { "Principal", Options.Principal },
        { "Teachers", Options.Teacher },
        { "Administrators", Options.Administrator },
        { "Janitors", Options.Janitor },
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
    
    // Employee Role Assignment Options
    public static readonly Dictionary<string, Options> EmployeeRoleMenuText = new()
    {
        { "Principal", Options.Principal },
        { "Teacher", Options.Teacher },
        { "Administrator", Options.Administrator },
        { "Janitor", Options.Janitor },
        { "Security", Options.Security }
    };
}
