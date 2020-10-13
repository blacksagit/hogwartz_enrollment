namespace Hogwartz.Infrastructure.DbMemory.Enrollment.Services
{
    using Hogwartz.Enrollment.Domain.Enrollment.Exceptions;
    using Hogwartz.Enrollment.Domain.Enrollment.Services;
    using System.Linq;

    public class EnrollmentDeleter : IDeleteEnrollmentDomainService
    {
        private readonly EnrollmentContext _context;

        public EnrollmentDeleter(EnrollmentContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            var enrollment = _context.Enrollments.FirstOrDefault(x => x.Id == id);
            if (enrollment == null)
            {
                throw new EnrollmentNotFoundException();
            }
            _context.Remove(enrollment);
            _context.SaveChanges();
        }
    }
}
