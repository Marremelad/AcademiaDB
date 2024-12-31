using System.ComponentModel;
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
    public (string, int) GetStudentCourseEnrolments(int studentId)
    {
        var courseEnrolments = _context.CourseEnrolments
            .Where(ce => ce.StudentIdFk == studentId)
            .ToList();

        var selection = Prompt.DisplaySingleChoicePrompt("Select a course to see the enrolment information",
            courseEnrolments);

        var courseEnrolmentObject = (CourseEnrolment)selection;

        return (GetInformationString(courseEnrolmentObject), courseEnrolmentObject.EnrolmentId);
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
        
        var selection = Prompt.DisplaySingleChoicePrompt("Select a grade", validGrades);

        if ((string)selection == "Exit") return;

        var stringObject = (string)selection;
        
        UpdateCourseGrade(enrolmentId, stringObject);
    }
    
    private void UpdateCourseGrade(int enrolmentId, string grade)
    {
        var courseEnrolment = _context.CourseEnrolments
            .SingleOrDefault(ce => ce.EnrolmentId == enrolmentId);

        if (courseEnrolment == null)
        {
            Console.WriteLine("Course enrolment not found...");
            return;
        }

        try
        {
            courseEnrolment.Grade = grade;
            // var currentDate = DateTime.Now;
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
}