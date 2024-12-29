using AcademiaDB.Repositories;
using AcademiaDB.UserInterface.MenuOptions;
using AcademiaDB.UserInterface.SelectionPrompts;

namespace AcademiaDB.UserInterface.Menus;

public class StudentMenu
{
    private StudentRepository _studentRepository;
    private OrderStudentsByMenu _orderStudentsByMenu;

    public StudentMenu(
        StudentRepository studentRepository,
        OrderStudentsByMenu orderStudentsByMenu)
    {
        _studentRepository = studentRepository;
        _orderStudentsByMenu = orderStudentsByMenu;
    }

    public void DisplayStudentMenu()
    {
        var selection = Prompt.DisplaySingleChoicePrompt("Select an option", MenuText.StudentMenuText);

        switch (selection)
        {
            case MenuText.Options.AllStudents:
                Console.WriteLine(_studentRepository.GetStudentInformation());
                // _studentRepository.GetStudents();
                break;
            
            case MenuText.Options.OrderedStudents:
                _orderStudentsByMenu.DisplayOrderStudentsByMenu();
                break;
        }
    }
}