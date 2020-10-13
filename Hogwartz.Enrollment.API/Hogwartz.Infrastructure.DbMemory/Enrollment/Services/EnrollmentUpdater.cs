namespace Hogwartz.Infrastructure.DbMemory.Enrollment.Services
{
    using Hogwartz.Enrollment.Domain.Enrollment.Exceptions;
    using Hogwartz.Enrollment.Domain.Enrollment.Models;
    using Hogwartz.Enrollment.Domain.Enrollment.Services;
    using Hogwartz.Infrastructure.DbMemory.Enrollment.Mappers;
    using Hogwartz.Infrastructure.DbMemory.Enrollment.Models;
    using System.Linq;

    public class EnrollmentUpdater : IUpdateEnrollmentDomainService
    {
        private readonly EnrollmentContext _context;
        private readonly IMapper<EnrollmentRequest, EnrollmentRequestDb> _toInfrastructureMapper;

        public EnrollmentUpdater(EnrollmentContext context,
            IMapper<EnrollmentRequest, EnrollmentRequestDb> toInfrastructureMapper)
        {
            _context = context;
            _toInfrastructureMapper = toInfrastructureMapper;
        }
        public void Update(int id, EnrollmentRequest request)
        {
            var enrollment = _context.Enrollments.FirstOrDefault(x => x.Id == id);
            if (enrollment == null)
            {
                throw new EnrollmentNotFoundException();
            }

            enrollment.FirstName = request.Person.Name.First;
            enrollment.MiddleName = request.Person.Name.Middle;
            enrollment.LastName = request.Person.Name.Last;
            enrollment.DoB = request.Person.Info.DateOfBirth;
            enrollment.House = request.House.ToString();
            enrollment.TypeIdentification = request.Person.Documents.FirstOrDefault()?.Type.ToString();
            enrollment.Identification = request.Person.Documents.FirstOrDefault()?.Number;
            enrollment.Status = request.Status.ToString();

            _context.Update(enrollment);
            _context.SaveChanges();
        }
    }
}
