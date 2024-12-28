﻿using AcademiaDB.Repositories;

namespace AcademiaDB.Helpers;

public class Create
{
    private EmployeeRepository _employeeRepository;

    public Create(EmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    
    public  void CreateNewStudent()
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

        var ssn = UserInput.GetSsn("Please enter the new employees ssn.");
        
        var startDate = UserInput.GetEmployeeStartDate("Please enter the new employees start date.");

        var salary = UserInput.GetEmployeeSalary("Please enter the new employees salary");

        var (department, role) = UserInput.GetEmployeeDepartmentAndRole("PLease enter the new employees role.");
        
        _employeeRepository.AddEmployeeToDatabase(firstName, lastName, ssn, startDate, salary, department, role);
    }
}