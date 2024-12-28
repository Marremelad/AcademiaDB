using System.Linq.Expressions;
using AcademiaDB.Data;
using AcademiaDB.Models;
using AcademiaDB.UserInterface.SelectionPrompts;
using Microsoft.EntityFrameworkCore;

namespace AcademiaDB.Repositories;

public class StudentRepository
{
    private AcademiaContext _context;

    public StudentRepository(AcademiaContext context)
    {
        _context = context;
    }
    
    // Returns a list of Student objects.
    public List<Student> GetStudents()
    {
        var students = _context.Students
            .ToList();

        return students;
    }

    public string GetStudentInformation()
    {
        var selection = Prompt.DisplaySingleChoicePrompt(
            "Select a student to see their information.",
            GetStudents());

        var studentObject = (Student)selection;

        var student = _context.Students
            .Include(s => s.ClassIdFkNavigation)
            .SingleOrDefault(s => s.StudentId == studentObject.StudentId);

        if (student == null) return "No Information found.";

        return $"Student Information\n" +
               $"ID: {student.StudentId}" +
               $"Name: {student.StudentFirstName} {student.StudentLastName}" +
               $"Class: {student.ClassIdFkNavigation.ClassName}";
    }
    
     // Returns a string of all students and their classes ordered by specific input.
    public string DisplayStudentsWithClasses<T>(
        Expression<Func<Student, T>> orderByExpression,
        bool descending)
    {
        IQueryable<Student> query = _context.Students
            .Include(i => i.ClassIdFkNavigation);

        query = descending
            ? query.OrderByDescending(orderByExpression)
            : query.OrderBy(orderByExpression);

        var result = string.Join("\n", query
            .Select(s =>
                $"{s.StudentFirstName} " +
                $"{s.StudentLastName}, " +
                $"{s.ClassIdFkNavigation.ClassName}"));

        return string.IsNullOrEmpty(result) ? "No students found." : result;
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