using AcademiaDB.Data;

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
            .Select(tg => $"{tg.Name} {tg.Grade}")
            .ToList();

        var result = string.Join("\n", topGrades);
        return result;
    }
}