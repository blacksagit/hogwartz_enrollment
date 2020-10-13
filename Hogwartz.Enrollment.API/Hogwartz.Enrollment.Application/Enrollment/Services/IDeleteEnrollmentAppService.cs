namespace Hogwartz.Enrollment.Application.Enrollment.Services
{
    using Hogwartz.Enrollment.Application.Enrollment.Models.Commands;

    public interface IDeleteEnrollmentAppService
    {
        void Delete(DeleteEnrollmentCommand command);
    }
}
