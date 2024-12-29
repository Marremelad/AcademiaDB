using AcademiaDB.Data;
using AcademiaDB.Models;
using Microsoft.EntityFrameworkCore;
using Prompt = AcademiaDB.UserInterface.SelectionPrompts.Prompt;

namespace AcademiaDB.Repositories;

public class CourseEnrolmentRepository
{
    private AcademiaContext _context;

    public CourseEnrolmentRepository(AcademiaContext context)
    {
        _context = context;
    }

    
    // Displays a list of all courses that a student has been enrolled into.
    // User can then select one of the courses to see the enrolment information.
    public string GetStudentCourseEnrolments(int studentId)
    {
        var courseEnrolments = _context.CourseEnrolments
            .Where(ce => ce.StudentIdFk == studentId)
            .ToList();

        var selection = Prompt.DisplaySingleChoicePrompt("Select a course to see the enrolment information",
            courseEnrolments);

        var courseEnrolmentObject = (CourseEnrolment)selection;

        return GetInformationString(courseEnrolmentObject);
    }
    
    
    // Returns a string with the chosen course enrolment information.
    private string GetInformationString(CourseEnrolment courseEnrolmentObject)
    {
        var courseEnrolment = _context.CourseEnrolments
            .Include(ce => ce.CourseIdFkNavigation)
            .Include(ce => ce.StudentIdFkNavigation)
            .Include(ce => ce.GradeSetterFkNavigation)
            .SingleOrDefault(ce => ce.EnrolmentId == courseEnrolmentObject.EnrolmentId);
        
        if (courseEnrolment == null) return "No Information found.";

        Console.Clear();
        
        return $"Enrolment information\n" +
               $"Enrolment ID: {courseEnrolment.EnrolmentId}\n" +
               $"Course Name: {courseEnrolment.CourseIdFkNavigation.CourseName}\n" +
               $"Student: {courseEnrolment.StudentIdFkNavigation.StudentFirstName} " +
               $"{courseEnrolment.StudentIdFkNavigation.StudentLastName}\n" +
               $"Grade: {courseEnrolment.Grade}\n" +
               $"Grade set by: {courseEnrolment.GradeSetterFkNavigation?.EmployeeFirstName} " +
               $"{courseEnrolment.GradeSetterFkNavigation?.EmployeeLastName}\n" +
               $"Grading date: {courseEnrolment.GradingDate}";
    }
}