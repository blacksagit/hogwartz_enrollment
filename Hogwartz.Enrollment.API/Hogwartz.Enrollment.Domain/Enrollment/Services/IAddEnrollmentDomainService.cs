namespace Hogwartz.Enrollment.Domain.Enrollment.Services
{
    using Hogwartz.Enrollment.Domain.Enrollment.Models;

    public interface IAddEnrollmentDomainService
    {
        void Add(EnrollmentRequest request);
    }
}
