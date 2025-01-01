using AcademiaDB.Data;

namespace AcademiaDB.Repositories;

public class DepartmentRepository
{
    private AcademiaContext _context;

    public DepartmentRepository(AcademiaContext context)
    {
        _context = context;
    }
}