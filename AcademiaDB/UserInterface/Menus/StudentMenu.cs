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
    private OrderStudentsByMenu _orderStudentsByMenu;
    private CourseEnrolmentRepository _courseEnrolmentRepository;
    private Create _create;

    public StudentMenu(
        StudentRepository studentRepository,
        OrderStudentsByMenu orderStudentsByMenu,
        CourseEnrolmentRepository courseEnrolmentRepository,
        Create create)
    {
        _studentRepository = studentRepository;
        _orderStudentsByMenu = orderStudentsByMenu;
        _courseEnrolmentRepository = courseEnrolmentRepository;
        _create = create;
    }

    public void DisplayStudentMenu()
    {
        var selection = Prompt.DisplaySingleChoicePrompt("Select an option", MenuText.StudentMenuText);

        IQueryable<Student> listOfStudents = Enumerable.Empty<Student>().AsQueryable();
        switch (selection)
        {
            case MenuText.Options.AllStudents:
                listOfStudents = _studentRepository.GetStudents();
                break;
            
            case MenuText.Options.StudentsByClass:
                var classId = UserInput.GetClassId("Select a class to see its students");
                listOfStudents = _studentRepository.GetStudentsFromSpecifiedClass(classId);
                break;
            
            case MenuText.Options.OrderedStudents:
                listOfStudents = _studentRepository.GetStudents();
                CallStudentRepository(listOfStudents, true);
                return;
            
            case MenuText.Options.AddStudent:
                _create.CreateNewStudent();
                return;
            
            case MenuText.Options.Exit:
                return;
        }
        
        CallStudentRepository(listOfStudents);
    }
    
    private void CallStudentRepository(IQueryable<Student> listOfStudents, bool orderStudents = false)
    {
        string? studentInformation;
        int studentId;

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
        
        var (enrolmentInformation, enrolmentId, courseFound) = _courseEnrolmentRepository.
            GetStudentCourseEnrolments(studentId);
        
        Console.WriteLine(studentInformation);
        Console.WriteLine(enrolmentInformation);
                
        if (courseFound) _courseEnrolmentRepository.UpdateGradeOptions(enrolmentId);
    }

    private Tuple<Expression<Func<Student, string>>, bool> DisplayOrderStudentsByMenu()
    {
        while (true)
        {
            Console.Clear();
            
            // A list of type string that is converted into a list of type MenuChoice.
            var selection = Prompt.DisplayMultiChoicePrompt("Select options to order by", MenuText.OrderStudentsByMenuText)
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