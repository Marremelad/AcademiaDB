﻿using AcademiaDB.Repositories;

namespace AcademiaDB.Helpers;

public class Create
{
    private EmployeeRepository _employeeRepository;

    public Create(EmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    
    public static void CreateNewStudent()
    {
        var firstName = UserInput.GetFirstName("Please enter the new students first name.");
        
        var lastName = UserInput.GetLastName("Please enter the new students last name.");
        
        var ssn = UserInput.GetSsn("Please enter the new students SSN.");
        
        var classId = UserInput.GetClassId("What class should the new student be enrolled into?");

        // StudentRepository.AddStudentToDatabase(firstName, lastName, ssn, classId);
    }

    // Get user input to create a new employee.
    public void CreateNewEmployee()
    {
        var firstName =  UserInput.GetFirstName("Please enter the new employees first name.");
        
        var lastName =  UserInput.GetLastName("Please enter the new employees last name.");
        
        _employeeRepository.AddEmployeeToDatabase(firstName, lastName);
    }
}