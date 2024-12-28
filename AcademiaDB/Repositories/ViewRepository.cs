using AcademiaDB.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AcademiaDB.Repositories;

public class ViewRepository
{
    private AcademiaContext _context; // Private instance of AcademiaContext. Will be resolved by the DI container.

    public ViewRepository(AcademiaContext context)
    {
        _context = context;
    }
    
    // Returns a string of students with the highest grades.
    public string GetTopGrades()
    {
        var topGrades = _context.TopGrades
            .Select(s => $"{s.Name} {s.Grade}")
            .ToList();

        var result = string.Join("\n", topGrades);
        return result;
    }
}