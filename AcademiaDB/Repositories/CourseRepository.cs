using AcademiaDB.Data;

namespace AcademiaDB.Repositories;

public class CourseRepository
{
    private AcademiaContext _context;

    public CourseRepository(AcademiaContext context)
    {
        _context = context;
    }
}