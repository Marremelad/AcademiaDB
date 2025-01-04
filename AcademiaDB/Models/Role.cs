
namespace AcademiaDB.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public int DepartmentIdFk { get; set; }

    public virtual Department DepartmentIdFkNavigation { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
