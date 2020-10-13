namespace Hogwartz.Enrollment.Application.Enrollment.Services.Impl
{
    using Hogwartz.Enrollment.Application.Enrollment.Models.Commands;
    using Hogwartz.Enrollment.Domain.Enrollment.Exceptions;
    using Hogwartz.Enrollment.Domain.Enrollment.Services;

    public class DeleteEnrollmentAppService : IDeleteEnrollmentAppService
    {
        private readonly IDeleteEnrollmentDomainService _deleteEnrollmentDomainService;
        private readonly IGetEnrollmentDomainService _getEnrollmentDomainService;

        public DeleteEnrollmentAppService(IDeleteEnrollmentDomainService deleteEnrollmentDomainService,
            IGetEnrollmentDomainService getEnrollmentDomainService)
        {
            _deleteEnrollmentDomainService = deleteEnrollmentDomainService;
            _getEnrollmentDomainService = getEnrollmentDomainService;
        }

        public void Delete(DeleteEnrollmentCommand command)
        {
            if (command?.Id == null)
            {
                throw new InvalidEnrollmentRequestException();
            }
            var enrollment = _getEnrollmentDomainService.Get(command.Id);
            if (enrollment == null)
            {
                throw new EnrollmentNotFoundException();
            }
            _deleteEnrollmentDomainService.Delete(command.Id);
        }
    }
}
