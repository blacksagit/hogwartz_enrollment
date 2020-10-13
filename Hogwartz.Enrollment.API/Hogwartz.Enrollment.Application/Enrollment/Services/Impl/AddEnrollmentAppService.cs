namespace Hogwartz.Enrollment.Application.Enrollment.Services.Impl
{
    using Hogwartz.Enrollment.Application.Enrollment.Models.Commands;
    using Hogwartz.Enrollment.Domain.Enrollment.Services;
    using System.Linq;

    public class AddEnrollmentAppService : IAddEnrollmentAppService
    {
        private readonly IAddEnrollmentDomainService _addEnrollmentDomainService;

        public AddEnrollmentAppService(IAddEnrollmentDomainService addEnrollmentDomainService)
        {
            _addEnrollmentDomainService = addEnrollmentDomainService;
        }

        public void Add(AddEnrollmentCommand command)
        {
            command.Request.Validate();

            _addEnrollmentDomainService.Add(command.Request);
        }
    }
}
