using AcademiaDB.Models;
using AcademiaDB.Repositories;
using AcademiaDB.UserInterface.MenuOptions;
using AcademiaDB.UserInterface.SelectionPrompts;

namespace AcademiaDB.UserInterface.Menus;

public class CourseMenu
{
    private CourseRepository _courseRepository;

    public CourseMenu(CourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public void DisplayCourseMenu()
    {
        var selection = Prompt.DisplaySingleChoicePrompt("Select an option", MenuText.CourseMenuText);

        var listOfCourses = new List<Course>();
        switch (selection)
        {
            case MenuText.Options.AllCourses:
                listOfCourses = _courseRepository.GetCourses();
                break;
            
            case MenuText.Options.ActiveCourses:
                listOfCourses = _courseRepository.GetActiveCourses();
                break;
            
            case MenuText.Options.Exit:
                return;
        }

        Console.WriteLine(_courseRepository.GetCourseInformation(listOfCourses));
    }
}