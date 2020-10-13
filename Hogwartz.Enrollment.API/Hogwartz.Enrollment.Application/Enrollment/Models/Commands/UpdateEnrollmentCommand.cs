namespace Hogwartz.Enrollment.Application.Enrollment.Models.Commands
{
    using Hogwartz.Enrollment.Domain.Enrollment.Models;

    public class UpdateEnrollmentCommand
    {
        public int Id { get; set; }
        public EnrollmentRequest Request { get; set; }
    }
}
