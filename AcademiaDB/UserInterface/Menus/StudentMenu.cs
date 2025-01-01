using AcademiaDB.Helpers;
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

        switch (selection)
        {
            case MenuText.Options.AllStudents:
                var (studentInformation, studentId) = _studentRepository.GetStudentInformation();
                Console.WriteLine(studentInformation);
                
                var (enrolmentInformation, enrolmentId) = _courseEnrolmentRepository.GetStudentCourseEnrolments(studentId);
                Console.WriteLine(enrolmentInformation);
                _courseEnrolmentRepository.UpdateGradeOptions(enrolmentId);
                break;
            
            case MenuText.Options.OrderedStudents:
                _orderStudentsByMenu.DisplayOrderStudentsByMenu();
                break;
            
            case MenuText.Options.AddStudent:
                _create.CreateNewStudent();
                break;
            
            case MenuText.Options.Exit:
                return;
        }
    }
}