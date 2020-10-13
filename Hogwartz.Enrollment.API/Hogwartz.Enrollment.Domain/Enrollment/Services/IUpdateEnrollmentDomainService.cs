namespace Hogwartz.Enrollment.Domain.Enrollment.Services
{
    using Hogwartz.Enrollment.Domain.Enrollment.Models;

    public interface IUpdateEnrollmentDomainService
    {
        void Update(int id, EnrollmentRequest request);
    }
}
