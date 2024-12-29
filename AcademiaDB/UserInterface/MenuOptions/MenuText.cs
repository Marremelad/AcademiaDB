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
        AllStudents,
        OrderedStudents,
        AddStudent,
        
        // Order Students By Menu
        SortByFirstName, // 16
        SortByLastName, // 17
        OrderByDescending, // 18
        OrderByAscending, // 19
        
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
        { "Teacher", Options.Teacher },
        { "Administrator", Options.Administrator },
        { "Janitor", Options.Janitor },
        { "Security", Options.Security },
    };

    // Student Menu Options.
    public static readonly Dictionary<string, Options> StudentMenuText = new()
    {
        { "All students", Options.AllStudents },
        { "Order students", Options.OrderedStudents },
        { "Add a new student", Options.AddStudent },
    };
    
    // Order Students By Menu Options.
    public static readonly Dictionary<string, Options> OrderStudentsByMenuText = new()
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
