using System.Linq.Expressions;
using AcademiaDB.Helpers;
using AcademiaDB.Models;
using AcademiaDB.Repositories;
using AcademiaDB.UserInterface.MenuOptions;
using AcademiaDB.UserInterface.SelectionPrompts;

namespace AcademiaDB.UserInterface.Menus;

public class StudentMenu
{
    private StudentRepository _studentRepository;
    private CourseEnrolmentRepository _courseEnrolmentRepository;
    private UserInput _userInput;
    private Create _create;

    public StudentMenu(
        StudentRepository studentRepository,
        CourseEnrolmentRepository courseEnrolmentRepository,
        UserInput userInput,
        Create create)
    {
        _studentRepository = studentRepository;
        _courseEnrolmentRepository = courseEnrolmentRepository;
        _userInput = userInput;
        _create = create;
    }

    // Displays the student menu through the single choice prompt.
    public void DisplayStudentMenu()
    {
        var selection = Prompt.DisplaySingleChoicePrompt("Select an option.", MenuText.StudentMenuText);

        IQueryable<Student> listOfStudents = Enumerable.Empty<Student>().AsQueryable();
        switch (selection)
        {
            case MenuText.Options.AllStudents:
                listOfStudents = _studentRepository.GetStudents();
                break;
            
            case MenuText.Options.StudentsByClass:
                var classId = UserInput.GetClassId("Select a class to see its students.");
                listOfStudents = _studentRepository.GetStudentsFromSpecifiedClass(classId);
                break;
            
            case MenuText.Options.StudentsByOrder:
                listOfStudents = _studentRepository.GetStudents();
                CallStudentRepository(listOfStudents, true);
                return;
            
            case MenuText.Options.AddStudent:
                _create.CreateNewStudent();
                return;
            
            case MenuText.Options.StudentById:
                var studentId = _userInput.GetStudentId("Please enter the students ID.");
                listOfStudents = _studentRepository.GetStudentById(studentId);
                break;
            
            case MenuText.Options.Exit:
                return;
        }
        
        CallStudentRepository(listOfStudents);
    }
    
    // Calls the student repository.
    private void CallStudentRepository(IQueryable<Student> listOfStudents, bool orderStudents = false)
    {
        string? studentInformation;
        int studentId;

        Console.Clear();
        
        if (orderStudents)
        {
            var (sortBy, orderBy) = DisplayOrderStudentsByMenu();
            (studentInformation, studentId) = _studentRepository.
                GetStudentInformation(listOfStudents, sortBy, orderBy);
        }
        else
        {
            (studentInformation, studentId) = _studentRepository.
                GetStudentInformation(listOfStudents);
        }
        Console.WriteLine(studentInformation);
        
        var (enrolmentInformation, enrolmentId, courseFound) = _courseEnrolmentRepository.
            GetStudentCourseEnrolments(studentId);
        
        Console.WriteLine(enrolmentInformation);
                
        if (courseFound) _courseEnrolmentRepository.UpdateGradeOptions(enrolmentId);
    }

    // Displays the order student by menu.
    private Tuple<Expression<Func<Student, string>>, bool> DisplayOrderStudentsByMenu()
    {
        while (true)
        {
            Console.Clear();
            
            // A list of type string that is converted into a list of type MenuChoice.
            var selection = Prompt.DisplayMultiChoicePrompt("Select options to order by.", MenuText.OrderStudentsByMenuText)
                .Where(MenuText.OrderStudentsByMenuText.ContainsKey)
                .Select(key => MenuText.OrderStudentsByMenuText[key])
                .ToList();
            
            if (PromptHelper.IsValidCombination(selection))
            {
                return PromptHelper.ApplyOptions(selection);
            }
            
            Console.WriteLine("Invalid combination selected.");
            Thread.Sleep(2000);
        }
    }
}