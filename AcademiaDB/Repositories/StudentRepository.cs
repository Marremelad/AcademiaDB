﻿using System.Linq.Expressions;
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

    // Returns a list of student objects.
    public IQueryable<Student> GetStudents()
    {
        var students = _context.Students;

        return students;
    }
    
    // Returns a list of student objects from a specified class.
    public IQueryable<Student> GetStudentsFromSpecifiedClass(int classId)
    {
        var students = _context.Students
            .Where(s => s.ClassIdFk == classId);

        return students;
    }
    
    // Displays a single choice prompt of student objects based on specific input.
    // User can select one of the student objects and see the student's information.
    // If the user chooses to not order the students by any parameter the overload will call the method with default values.
    public (string, int) GetStudentInformation<T>(
        IQueryable<Student> students, 
        Expression<Func<Student, T>> orderByExpression,
        bool ascending)
    {
        students = ascending
            ? students.OrderBy(orderByExpression)
            : students.OrderByDescending(orderByExpression);

        var selection = Prompt.DisplaySingleChoicePrompt(
                "Select a student to see their information", 
                students.ToList());

        var studentObject = (Student)selection;

        return (GetInformationString(studentObject), studentObject.StudentId);
    }
    
    // Overload of GetStudentInformation.
    public (string, int) GetStudentInformation(IQueryable<Student> students)
    {
        return GetStudentInformation(students, student => student.StudentId, true);
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