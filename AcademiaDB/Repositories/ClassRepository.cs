using AcademiaDB.Data;
using AcademiaDB.Models;
using Spectre.Console;

namespace AcademiaDB.Repositories;

public class ClassRepository
{
    private AcademiaContext _context;

    public ClassRepository(AcademiaContext context)
    {
        _context = context;
    }

    public List<Class> GetClasses()
    {
        var classes = _context.Classes
            .ToList();

        return classes;
    }
}