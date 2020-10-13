namespace Hogwartz.Infrastructure.DbMemory
{
    using Hogwartz.Infrastructure.DbMemory.Enrollment.Models;
    using Microsoft.EntityFrameworkCore;

    public class EnrollmentContext : DbContext
    {
        public EnrollmentContext(DbContextOptions<EnrollmentContext> options)
            : base(options)
        {
        }

        public DbSet<EnrollmentRequestDb> Enrollments { get; set; }
    }
}
