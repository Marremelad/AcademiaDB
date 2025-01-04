using AcademiaDB.Data;
using Microsoft.EntityFrameworkCore;

namespace AcademiaDB.Models;

public partial class CourseEnrolment
{
    public int EnrolmentId { get; set; }

    public int StudentIdFk { get; set; }

    public int CourseIdFk { get; set; }

    public string? Grade { get; set; }

    public int? GradeSetterFk { get; set; }

    public DateOnly? GradingDate { get; set; }

    public virtual Course CourseIdFkNavigation { get; set; } = null!;

    public virtual Employee? GradeSetterFkNavigation { get; set; }

    public virtual Student StudentIdFkNavigation { get; set; } = null!;
    
    // Returns a string with the name of the course in the CourseEnrolment.
    public override string ToString()
    {
        using (var context = new AcademiaContext())
        {
            var courseEnrolment = context.CourseEnrolments
                .Include(ce => ce.CourseIdFkNavigation)
                .SingleOrDefault(ce => ce.EnrolmentId == EnrolmentId);

            return $"{courseEnrolment?.CourseIdFkNavigation.CourseName}";
        }
    }
}
