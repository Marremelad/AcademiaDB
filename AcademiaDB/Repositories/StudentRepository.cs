using System.Linq.Expressions;
using System.Transactions;
using AcademiaDB.Data;
using AcademiaDB.Models;
using AcademiaDB.UserInterface.SelectionPrompts;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AcademiaDB.Repositories;

public class StudentRepository
{
    private AcademiaContext _context;

    public StudentRepository(AcademiaContext context)
    {
        _context = context;
    }

    // Returns a list of student objects.
    public List<Student> GetStudents()
    {
        var students = _context.Students
            .ToList();

        return students;
    }
    
    // Displays a single choice prompt of student objects.
    // User can select one of the student objects and see the student's information.
    public (string, int) GetStudentInformation()
    {
        var students = GetStudents();
        
        var selection = Prompt.DisplaySingleChoicePrompt(
            "Select a student to see their information.",
            students);
        
        var studentObject = (Student)selection;

        return (GetInformationString(studentObject), studentObject.StudentId);
    }
    
    // Displays a single choice prompt of student objects ordered by specific input.
    // User can select one of the student objects and see the student's information.
    public (string, int) GetOrderedStudentInformation<T>(
        Expression<Func<Student, T>> orderByExpression,
        bool descending)
    {
        IQueryable<Student> students = _context.Students;

        students = descending
            ? students.OrderByDescending(orderByExpression)
            : students.OrderBy(orderByExpression);

        var selection = Prompt.DisplaySingleChoicePrompt(
                "Select a student to see their information", 
                students.ToList());

        var studentObject = (Student)selection;

        return (GetInformationString(studentObject), studentObject.StudentId);
    }

    // Returns a string with the chosen student's information.
    private string GetInformationString(Student studentObject)
    {
        var student = _context.Students
            .Include(s => s.ClassIdFkNavigation)
            .SingleOrDefault(s => s.StudentId == studentObject.StudentId);
        
        if (student == null) return "No Information found.";
        
        return $"Student Information\n\n" +
               $"ID: {student.StudentId}\n" +
               $"Name: {student.StudentFirstName} {student.StudentLastName}\n" +
               $"Class: {student.ClassIdFkNavigation.ClassName}\n";
    }
    
    // Adds a student to the database.
    public void AddStudentToDatabase(string firstName, string lastName, string studentSsn, int classId)
    {
        var newStudent = new Student()
        {
            StudentFirstName = firstName,
            StudentLastName = lastName,
            StudentSsn = studentSsn,
            ClassIdFk = classId
        };

        _context.Students.Add(newStudent);
        _context.SaveChanges();

        Console.Clear();
        Console.WriteLine("New student added successfully.");
    }
}