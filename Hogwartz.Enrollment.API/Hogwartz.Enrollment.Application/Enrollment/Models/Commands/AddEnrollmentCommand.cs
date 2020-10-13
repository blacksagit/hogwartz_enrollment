namespace Hogwartz.Enrollment.Application.Enrollment.Models.Commands
{
    using Hogwartz.Enrollment.Domain.Enrollment.Models;

    public class AddEnrollmentCommand
    {
        public EnrollmentRequest Request { get; set; }
    }
}
