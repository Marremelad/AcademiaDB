using System.Data;
using System.Security.Cryptography;
using AcademiaDB.Repositories;

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
        throw new NotImplementedException();
    }
}