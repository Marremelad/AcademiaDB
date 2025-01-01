using AcademiaDB.Repositories;

namespace AcademiaDB.UserInterface.Menus;

public class DepartmentMenu
{
    private DepartmentRepository _departmentRepository;

    public DepartmentMenu(DepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }
    
    
}