namespace Hogwartz.Enrollment.Application.Enrollment.Services
{
    using Hogwartz.Enrollment.Application.Enrollment.Models.Responses;

    public interface IGetEnrollmentAppService
    {
        EnrollmentResponse Get();
    }
}
