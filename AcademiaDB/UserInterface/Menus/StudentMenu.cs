using AcademiaDB.Repositories;
using AcademiaDB.UserInterface.MenuOptions;
using AcademiaDB.UserInterface.SelectionPrompts;

namespace AcademiaDB.UserInterface.Menus;

public class StudentMenu
{
    private StudentRepository _studentRepository;

    public StudentMenu(StudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public void DisplayStudentMenu()
    {
        var selection = Prompt.DisplaySingleChoicePrompt("Select an option", MenuText.StudentMenuText);

        switch (selection)
        {
            case MenuText.Options.AllStudents:
                Console.WriteLine(_studentRepository.DisplayStudentsWithClasses(s => s.ClassIdFkNavigation.ClassName, false));
                break;
        }
    }
}