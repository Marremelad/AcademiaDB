namespace AcademiaDB.UserInterface.MenuOptions;

public static class MenuText
{
    public enum Options
    {
        // Order Students By Menu.
        SortByFirstName, // 0
        SortByLastName, // 1
        OrderByDescending, // 2
        OrderByAscending, // 3
        
        // Main Menu.
        Employees,
        Students,
        Classes,
        Departments,
        Courses,
        Exit,
        
        // Employee Menu.
        AllEmployees,
        Principal,
        Teacher,
        Administrator,
        Janitor,
        Security,
        AddEmployee,
        
        // Department Menu.
        AllDepartments,
        
        // Student Menu.
        AllStudents,
        StudentsByClass,
        StudentById,
        StudentsByOrder,
        AddStudent,
        
        // Class Menu.
        A1,
        B2,
        C3,
        D4,
        E5,
        
        // Course Menu.
        AllCourses,
        ActiveCourses,
        EnrolStudentIntoCourse,
        
        // Update Grade.
        UpdateGrade
    }
    
    // Main Menu Options.
    public static readonly Dictionary<string, Options> MainMenuText = new()
    {
        { "Employees", Options.Employees },
        { "Departments", Options.Departments },
        { "Students", Options.Students },
        { "Classes", Options.Classes },
        { "Courses", Options.Courses },
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
        { "Add a new employee", Options.AddEmployee },
        { "Exit", Options.Exit }
    };
    
    // Employee Role Options
    public static readonly Dictionary<string, Options> EmployeeRoleText = new()
    {
        { "Teacher", Options.Teacher },
        { "Administrator", Options.Administrator },
        { "Janitor", Options.Janitor },
        { "Security", Options.Security },
    };
    
    // Department Menu Option.
    public static readonly Dictionary<string, Options> DepartmentMenuText = new()
    {
        { "All departments", Options.AllDepartments },
        { "Exit", Options.Exit }
    };
    
    // Student Menu Options.
    public static readonly Dictionary<string, Options> StudentMenuText = new()
    {
        { "All students", Options.AllStudents },
        { "Students by order", Options.StudentsByOrder },
        { "Students by class", Options.StudentsByClass },
        { "Students by ID", Options.StudentById },
        { "Add a new student", Options.AddStudent },
        { "Exit", Options.Exit }
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
        { "Class A1", Options.A1 },
        { "Class B2", Options.B2 },
        { "Class C3", Options.C3 },
        { "Class D4", Options.D4 },
        { "Class E5", Options.E5 },
    };
    
    // Course Menu Options.
    public static readonly Dictionary<string, Options> CourseMenuText = new()
    {
        { "All courses", Options.AllCourses },
        { "Active courses", Options.ActiveCourses },
        { "Enrol student into course", Options.EnrolStudentIntoCourse},
        { "Exit", Options.Exit }
    };
    
    // Update Grade Options.
    public static readonly Dictionary<string, Options> UpdateGradeText = new()
    {
        { "Update Grade", Options.UpdateGrade },
        { "Exit", Options.Exit }
    };
}
