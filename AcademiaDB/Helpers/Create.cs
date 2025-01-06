using AcademiaDB.Repositories;

namespace AcademiaDB.Helpers;

public class Create
{
    private EmployeeRepository _employeeRepository;
    private StudentRepository _studentRepository;
    private CourseEnrolmentRepository _courseEnrolmentRepository;
    private UserInput _userInput;

    public Create(
        EmployeeRepository employeeRepository,
        StudentRepository studentRepository,
        CourseEnrolmentRepository courseEnrolmentRepository,
        UserInput userInput)
    {
        _employeeRepository = employeeRepository;
        _studentRepository = studentRepository;
        _courseEnrolmentRepository = courseEnrolmentRepository;
        _userInput = userInput;
    }
    
    // Get user input to create a new student.
    public void CreateNewStudent()
    {
        var firstName = UserInput.GetFirstName("Please enter the new students first name.");
        
        var lastName = UserInput.GetLastName("Please enter the new students last name.");
        
        var ssn = UserInput.GetSsn("Please enter the new students SSN. (yyyyMMdd-nnnn)");
        
        var classId = UserInput.GetClassId("What class should the new student be enrolled into?");

        _studentRepository.AddStudentToDatabase(firstName, lastName, ssn, classId);
    }

    // Get user input to create a new employee.
    public void CreateNewEmployee()
    {
        var firstName =  UserInput.GetFirstName("Please enter the new employees first name.");
        
        var lastName =  UserInput.GetLastName("Please enter the new employees last name.");
        
        var ssn = UserInput.GetSsn("Please enter the new employees ssn. (yyyyMMdd-nnnn)");
        
        var startDate = UserInput.GetEmployeeStartDate("Please enter the new employees start date. (yyyy-MM-dd)");
        
        var salary = UserInput.GetEmployeeSalary("Please enter the new employees salary.");
        
        var (department, role) = UserInput.GetEmployeeDepartmentAndRole("PLease enter the new employees role.");
        
        _employeeRepository.AddEmployeeToDatabase(firstName, lastName, ssn, startDate, salary, department, role);
        
        // Code bellow will cause an error. Assigned department does not match assigned role.
        // _employeeRepository.AddEmployeeToDatabase("Foo", "Bar", "19901010-1111", new DateOnly(2010, 10, 10), 100, 4, 1);
    }

    // Get user input to create a new course enrolment.
    public void CreateNewCourseEnrolment()
    {
        var studentId = _userInput.GetStudentId("Please enter the ID of the student you want to enrol.");
        
        var (courseId, gradeSetterId) = _userInput.GetCourseAndGradeSetter(
            "Please select the course you want to enrol the student into.", studentId);
        
        _courseEnrolmentRepository.EnrolStudentIntoCourse(studentId, courseId, null, gradeSetterId, null);
        
        // Code bellow will cause an error. Assigned grade setter is not tied to the specified course.
        // _courseEnrolmentRepository.EnrolStudentIntoCourse(studentId, 1, null, 2, null);
    }
}