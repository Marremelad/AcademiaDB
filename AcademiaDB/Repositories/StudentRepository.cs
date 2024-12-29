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
    
    // Displays a single choice prompt of student objects.
    // User can select on of the objects and see the students information.
    public string GetStudentInformation()
    {
        var students = _context.Students
            .ToList();
        
        var selection = Prompt.DisplaySingleChoicePrompt(
            "Select a student to see their information.",
            students);
        
        var studentObject = (Student)selection;

        return GetInformationString(studentObject);
    }
    
    // Displays a single choice prompt of student objects ordered by specific input.
    // User can select on of the objects and see the students information.
    public string GetOrderedStudentInformation<T>(
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

        return GetInformationString(studentObject);
    }

    // Returns a string with the chosen student's information.
    private string GetInformationString(Student studentObject)
    {
        var student = _context.Students
            .Include(s => s.ClassIdFkNavigation)
            .SingleOrDefault(s => s.StudentId == studentObject.StudentId);
        
        if (student == null) return "No Information found.";
        
        return $"Student Information\n" +
               $"ID: {student.StudentId}\n" +
               $"Name: {student.StudentFirstName} {student.StudentLastName}\n" +
               $"Class: {student.ClassIdFkNavigation.ClassName}";
    }
    
    // Returns a string of students filtered by class name.
    public string DisplayStudentsFilteredByClass<TKey>(
        Expression<Func<Student, TKey>> orderByExpression,
        bool descending,
        string className)
    {
        var query = _context.Students
            .Where(s => s.ClassIdFkNavigation.ClassName == className);

        query = descending
            ? query.OrderByDescending(orderByExpression)
            : query.OrderBy(orderByExpression);

        var selection = query.Select(s => new
        {
            FirstName = s.StudentFirstName,
            LastName = s.StudentLastName
        });

        var result = string.Join("\n", new[]
        {
            $"{className}",
            string.Join("\n", selection.Select(s => $"{s.FirstName} {s.LastName}"))
        });

        return string.IsNullOrEmpty(result) ? "No students found." : result;

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