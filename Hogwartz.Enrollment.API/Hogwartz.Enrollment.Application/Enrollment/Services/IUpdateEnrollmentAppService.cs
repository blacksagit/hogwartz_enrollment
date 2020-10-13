namespace Hogwartz.Enrollment.Application.Enrollment.Services
{
    using Hogwartz.Enrollment.Application.Enrollment.Models.Commands;

    public interface IUpdateEnrollmentAppService
    {
        void Update(UpdateEnrollmentCommand command);
    }
}
