using System.Xml;
using AcademiaDB.Data;
using AcademiaDB.Models;
using AcademiaDB.UserInterface.MenuOptions;
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
    // If the student has not yet been enrolled into any courses the method returns a string.
    public (string, int, bool) GetStudentCourseEnrolments(int studentId)
    {
        var courseEnrolments = _context.CourseEnrolments
            .Where(ce => ce.StudentIdFk == studentId)
            .ToList();

        if (courseEnrolments.Count < 1) return ("Student is not enrolled in any courses yet.", 0, false);
        
        var selection = Prompt.DisplaySingleChoicePrompt("Select a course to see the enrolment information.",
            courseEnrolments);

        var courseEnrolmentObject = (CourseEnrolment)selection;

        return (GetInformationString(courseEnrolmentObject), courseEnrolmentObject.EnrolmentId, true);
    }
    
    // Returns a string with the chosen course enrolment's information.
    private string GetInformationString(CourseEnrolment courseEnrolmentObject)
    {
        var courseEnrolment = _context.CourseEnrolments
            .Include(ce => ce.CourseIdFkNavigation)
            .Include(ce => ce.StudentIdFkNavigation)
            .Include(ce => ce.GradeSetterFkNavigation)
            .SingleOrDefault(ce => ce.EnrolmentId == courseEnrolmentObject.EnrolmentId);
        
        if (courseEnrolment == null) return "No Information found.";

        Console.Clear();
        
        return $"Enrolment information\n\n" +
               $"Enrolment ID: {courseEnrolment.EnrolmentId}\n" +
               $"Course Name: {courseEnrolment.CourseIdFkNavigation.CourseName}\n" +
               $"Student: {courseEnrolment.StudentIdFkNavigation.StudentFirstName} " +
               $"{courseEnrolment.StudentIdFkNavigation.StudentLastName}\n" +
               $"Grade: {courseEnrolment.Grade}\n" +
               $"Grade set by: {courseEnrolment.GradeSetterFkNavigation?.EmployeeFirstName} " +
               $"{courseEnrolment.GradeSetterFkNavigation?.EmployeeLastName}\n" +
               $"Grading date: {courseEnrolment.GradingDate}";
    }
    
    // Displays the options for updating a students grade.
    public void UpdateGradeOptions(int enrolmentId)
    {
        var selection = Prompt.DisplaySingleChoicePrompt("", MenuText.UpdateGradeText);

        switch (selection)
        {
            case MenuText.Options.UpdateGrade:
                SelectValidGrade(enrolmentId);
                break;
            
            case MenuText.Options.Exit:
                return;
        }
    }

    // User gets to select a grade.
    // If a student already has a grade, that grade can not be chosen. 
    private void SelectValidGrade(int enrolmentId)
    {
        var grade = _context.CourseEnrolments
            .Where(ce => ce.EnrolmentId == enrolmentId)
            .Select(ce => ce.Grade)
            .SingleOrDefault();
        
        List<string> validGrades =
        [
            "A", "B", "C", "D", "E", "F", "Exit"
        ];
        
        if (grade != null) validGrades.Remove(grade);

        Console.Clear();
        
        var selection = Prompt.DisplaySingleChoicePrompt("Select a grade.", validGrades);

        if ((string)selection == "Exit") return;

        var stringObject = (string)selection;
        
        UpdateCourseGrade(enrolmentId, stringObject);
    }
    
    // Updates the students grade in a selected course.
    private void UpdateCourseGrade(int enrolmentId, string grade)
    {
        var courseEnrolment = _context.CourseEnrolments
            .SingleOrDefault(ce => ce.EnrolmentId == enrolmentId);

        if (courseEnrolment == null)
        {
            Console.WriteLine("Course enrolment not found...");
            return;
        }

        // Makes sure that the grade is valid.
        // If an invalid grade is set make sure that the SQL trigger is configured correctly.
        try
        {
            courseEnrolment.Grade = grade;
            courseEnrolment.GradingDate = DateOnly.FromDateTime(DateTime.Today);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            Console.WriteLine("Something went wrong while attempting to update a grade.\n" +
                              "Make sure that the grade is a valid character.('A', 'B', 'C', 'D', 'E', 'F')\n" +
                              "Rolling back changes...");
            return;
        }

        Console.Clear();
        Console.WriteLine("Grade updated successfully.");
    }

    
    // Creates a new course enrolment.
    public void EnrolStudentIntoCourse(int studentId, int courseId, string? grade,
        int gradeSetterId, DateOnly? gradingDate)
    {
        var newCourseEnrolment = new CourseEnrolment()
        {
            StudentIdFk = studentId,
            CourseIdFk = courseId,
            Grade = grade,
            GradeSetterFk = gradeSetterId,
            GradingDate = gradingDate
        };

        try
        {
            _context.CourseEnrolments.Add(newCourseEnrolment);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            Console.WriteLine("Something went wrong while trying to enrol a student into a course. " +
                              "Make sure that the grade setter has access to the specified course.");
            return;
        }

        Console.WriteLine("Student enrolled successfully.");
    }
}