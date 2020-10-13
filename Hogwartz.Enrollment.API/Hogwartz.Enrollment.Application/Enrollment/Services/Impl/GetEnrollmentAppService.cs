namespace Hogwartz.Enrollment.Application.Enrollment.Services.Impl
{
    using Hogwartz.Enrollment.Application.Enrollment.Models.Responses;
    using Hogwartz.Enrollment.Domain.Enrollment.Services;

    public class GetEnrollmentAppService : IGetEnrollmentAppService
    {
        private readonly IGetEnrollmentDomainService _getEnrollmentDomainService;

        public GetEnrollmentAppService(IGetEnrollmentDomainService getEnrollmentDomainService)
        {
            _getEnrollmentDomainService = getEnrollmentDomainService;
        }

        public EnrollmentResponse Get()
        {
            return new EnrollmentResponse
            {
                Response = _getEnrollmentDomainService.Get()
            };

        }
    }
}
