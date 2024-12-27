namespace AcademiaDB.UserInterface.MenuOptions;

public class MenuOptions
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
        Admins,
        Teachers,
        
        // Student Menu.
        SortByFirstName, // 13
        SortByLastName, // 14
        OrderByDescending, // 15
        OrderByAscending, // 16
        
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
        { "Admins", Options.Admins },
        { "Teachers", Options.Teachers },
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
