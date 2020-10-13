namespace Hogwartz.Infrastructure.DbMemory.Enrollment.Services
{
    using Hogwartz.Enrollment.Domain.Enrollment.Exceptions;
    using Hogwartz.Enrollment.Domain.Enrollment.Models;
    using Hogwartz.Enrollment.Domain.Enrollment.Services;
    using Hogwartz.Infrastructure.DbMemory.Enrollment.Mappers;
    using Hogwartz.Infrastructure.DbMemory.Enrollment.Models;
    using Microsoft.EntityFrameworkCore.Internal;
    using System.Linq;

    public class EnrollmentAdder : IAddEnrollmentDomainService
    {
        private readonly EnrollmentContext _context;
        private readonly IMapper<EnrollmentRequest, EnrollmentRequestDb> _toInfrastructureMapper;

        public EnrollmentAdder(EnrollmentContext context,
            IMapper<EnrollmentRequest, EnrollmentRequestDb> toInfrastructureMapper)
        {
            _context = context;
            _toInfrastructureMapper = toInfrastructureMapper;
        }

        public void Add(EnrollmentRequest request)
        {
            var documents = request.Person.Documents.Select(x => x.Type + x.Number);
            if (_context.Enrollments.Any(x => documents.Contains(x.TypeIdentification + x.Identification)))
            {
                throw new EnrollmentAlreadyExistsException();
            }
            _context.Add(_toInfrastructureMapper.Map(request));
            _context.SaveChanges();
        }
    }
}
