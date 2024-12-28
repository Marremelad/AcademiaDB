using AcademiaDB.Data;

namespace AcademiaDB.Repositories;

public class RoleRepository
{
    private AcademiaContext _context; // Private instance of AcademiaContext. Will be resolved by the DI container.

    public RoleRepository(AcademiaContext context)
    {
        _context = context;
    }
}