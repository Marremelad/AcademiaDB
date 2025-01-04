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

    // Returns a list of course objects.
    public List<Course> GetCourses()
    {
        var courses = _context.Courses
            .ToList();

        return courses;
    }

    // Returns a list of course objects where the course is active. 
    public List<Course> GetActiveCourses()
    {
        var courses = _context.Courses
            .Where(c => c.Active == true)
            .ToList();

        return courses;
    }
    
    // Displays a list of all courses.
    // User can then select one of the courses to see its information.
    public string GetCourseInformation(List<Course> courses)
    {
        var selection = Prompt.DisplaySingleChoicePrompt("Select a course to see its information.", courses);

        var courseObject = (Course)selection;

        return GetInformationString(courseObject);
    }
    
    // Returns a string with the chosen course's information.
    private string GetInformationString(Course courseObject)
    {
        return $"Course Information\n\n" +
               $"Course ID: {courseObject.CourseId}\n" +
               $"Course Name: {courseObject.CourseName}\n" +
               $"Status: {(courseObject.Active ? "Active" : "Inactive")}";
    }
}