namespace Hogwartz.Enrollment.Domain.Enrollment.Services
{
    using Hogwartz.Enrollment.Domain.Enrollment.Models;
    using System.Collections.Generic;

    public interface IGetEnrollmentDomainService
    {
        IEnumerable<EnrollmentRequest> Get();
        EnrollmentRequest Get(int id);
    }
}
