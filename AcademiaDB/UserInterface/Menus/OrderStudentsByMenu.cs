using AcademiaDB.Helpers;
using AcademiaDB.Repositories;
using AcademiaDB.UserInterface.MenuOptions;
using AcademiaDB.UserInterface.SelectionPrompts;

namespace AcademiaDB.UserInterface.Menus;

public class OrderStudentsByMenu
{
    private StudentRepository _studentRepository;
    private CourseEnrolmentRepository _courseEnrolmentRepository;

    public OrderStudentsByMenu(
        StudentRepository studentRepository,
        CourseEnrolmentRepository courseEnrolmentRepository)
    {
        _studentRepository = studentRepository;
        _courseEnrolmentRepository = courseEnrolmentRepository;
    }

    public void DisplayOrderStudentsByMenu()
    {
        while (true)
        {
            Console.Clear();
            
            // A list of type string that is converted into a list of type MenuChoice.
            var choice = Prompt.DisplayMultiChoicePrompt("Select options to order by", MenuText.OrderStudentsByMenuText)
                .Where(MenuText.OrderStudentsByMenuText.ContainsKey)
                .Select(key => MenuText.OrderStudentsByMenuText[key])
                .ToList();
            
            if (PromptHelper.IsValidCombination(choice))
            {
                var (sortBy, orderBy) = PromptHelper.ApplyOptions(choice);
                var (studentInformation, studentId) = _studentRepository.GetOrderedStudentInformation(sortBy, orderBy);
                Console.WriteLine(studentInformation);
                
                var (enrolmentInformation, enrolmentId) = _courseEnrolmentRepository.GetStudentCourseEnrolments(studentId);
                Console.WriteLine(enrolmentInformation);
                _courseEnrolmentRepository.UpdateGradeOptions(enrolmentId);
                break;
            }
            Console.WriteLine("Invalid combination selected.");
            Thread.Sleep(2000);
        }
    }
}