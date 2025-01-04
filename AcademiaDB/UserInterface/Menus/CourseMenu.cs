using AcademiaDB.Helpers;
using AcademiaDB.Models;
using AcademiaDB.Repositories;
using AcademiaDB.UserInterface.MenuOptions;
using AcademiaDB.UserInterface.SelectionPrompts;

namespace AcademiaDB.UserInterface.Menus;

public class CourseMenu
{
    private CourseRepository _courseRepository;
    private Create _create;

    public CourseMenu(
        CourseRepository courseRepository,
        Create create)
    {
        _courseRepository = courseRepository;
        _create = create;
    }

    // Displays the course menu.
    public void DisplayCourseMenu()
    {
        var selection = Prompt.DisplaySingleChoicePrompt("Select an option.", MenuText.CourseMenuText);

        var listOfCourses = new List<Course>();
        switch (selection)
        {
            case MenuText.Options.AllCourses:
                listOfCourses = _courseRepository.GetCourses();
                break;
            
            case MenuText.Options.ActiveCourses:
                listOfCourses = _courseRepository.GetActiveCourses();
                break;
            
            case MenuText.Options.EnrolStudentIntoCourse:
                _create.CreateNewCourseEnrolment();
                return;
            
            case MenuText.Options.Exit:
                return;
        }

        Console.WriteLine(_courseRepository.GetCourseInformation(listOfCourses));
    }
}