namespace Hogwartz.Enrollment.Application.Enrollment.Services.Impl
{
    using Hogwartz.Enrollment.Application.Enrollment.Models.Commands;
    using Hogwartz.Enrollment.Domain.Enrollment.Exceptions;
    using Hogwartz.Enrollment.Domain.Enrollment.Services;

    public class UpdateEnrollmentAppService : IUpdateEnrollmentAppService
    {
        private readonly IUpdateEnrollmentDomainService _updateEnrollmentDomainService;
        private readonly IGetEnrollmentDomainService _getEnrollmentDomainService;

        public UpdateEnrollmentAppService(IUpdateEnrollmentDomainService updateEnrollmentDomainService,
            IGetEnrollmentDomainService getEnrollmentDomainService)
        {
            _updateEnrollmentDomainService = updateEnrollmentDomainService;
            _getEnrollmentDomainService = getEnrollmentDomainService;
        }

        public void Update(UpdateEnrollmentCommand command)
        {
            if (command?.Id == null)
            {
                throw new InvalidEnrollmentRequestException();
            }
            command.Request.Validate();
            var enrollment = _getEnrollmentDomainService.Get(command.Id);
            if (enrollment == null)
            {
                throw new EnrollmentNotFoundException();
            }
            _updateEnrollmentDomainService.Update(command.Id, command.Request);
        }
    }
}
