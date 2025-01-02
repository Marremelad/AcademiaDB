using AcademiaDB.Data;
using AcademiaDB.Models;
using AcademiaDB.UserInterface.SelectionPrompts;

namespace AcademiaDB.Repositories;

public class CourseRepository
{
    private AcademiaContext _context;

    public CourseRepository(AcademiaContext context)
    {
        _context = context;
    }

    public List<Course> GetCourses()
    {
        var courses = _context.Courses
            .ToList();

        return courses;
    }

    public List<Course> GetActiveCourses()
    {
        var courses = _context.Courses
            .Where(c => c.Active == true)
            .ToList();

        return courses;
    }

    public string GetCourseInformation(List<Course> courses)
    {
        var selection = Prompt.DisplaySingleChoicePrompt("Select a course to see its information", courses);

        var courseObject = (Course)selection;

        return GetInformationString(courseObject);
    }
    
    private string GetInformationString(Course courseObject)
    {
        return $"Course Information\n\n" +
               $"Course ID: {courseObject.CourseId}\n" +
               $"Course Name: {courseObject.CourseName}\n" +
               $"Status: {(courseObject.Active ? "Active" : "Inactive")}";
    }
}