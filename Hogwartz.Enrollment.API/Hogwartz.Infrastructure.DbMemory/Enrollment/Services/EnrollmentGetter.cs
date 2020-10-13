namespace Hogwartz.Infrastructure.DbMemory.Enrollment.Services
{
    using Hogwartz.Enrollment.Domain.Enrollment.Models;
    using Hogwartz.Enrollment.Domain.Enrollment.Services;
    using Hogwartz.Infrastructure.DbMemory.Enrollment.Mappers;
    using Hogwartz.Infrastructure.DbMemory.Enrollment.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class EnrollmentGetter : IGetEnrollmentDomainService
    {
        private readonly EnrollmentContext _context;
        private readonly IMapper<EnrollmentRequestDb, EnrollmentRequest> _toDomainMapper;

        public EnrollmentGetter(EnrollmentContext context,
            IMapper<EnrollmentRequestDb, EnrollmentRequest> toDomainMapper)
        {
            _context = context;
            _toDomainMapper = toDomainMapper;
        }

        public IEnumerable<EnrollmentRequest> Get()
        {
            var result = new List<EnrollmentRequest>();
            _context.Enrollments.ForEachAsync(x =>
            {
                result.Add(_toDomainMapper.Map(x));
            });
            return result;
        }

        public EnrollmentRequest Get(int id)
        {
            EnrollmentRequest result = null;
            var enrollment = _context.Enrollments.FirstOrDefault(x => x.Id == id);
            if (enrollment != null)
            {
                result = _toDomainMapper.Map(enrollment);
            }
            return result;
        }
    }
}
