using AcademiaDB.Data;

namespace AcademiaDB.Repositories;

public class EmployeeRoleRepository
{
    private AcademiaContext _context;

    public EmployeeRoleRepository(AcademiaContext context)
    {
        _context = context;
    }

    public string GetEmployeeRoles()
    {
        var query = _context.
    }
}