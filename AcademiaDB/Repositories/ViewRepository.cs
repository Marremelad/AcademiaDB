using AcademiaDB.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AcademiaDB.Repositories;

public class ViewRepository
{
    private AcademiaContext _context;

    public ViewRepository(AcademiaContext context)
    {
        _context = context;
    }

    public string GetTopGrades()
    {
        var topGrades = _context.TopGrades
            .Select(s => $"{s.Name} {s.Grade}")
            .ToList();

        var result = string.Join("\n", topGrades);
        return result;
    }
}