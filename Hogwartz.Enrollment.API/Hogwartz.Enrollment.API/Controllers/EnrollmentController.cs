namespace Hogwartz.Enrollment.API.Controllers
{
    using Hogwartz.Enrollment.Application.Enrollment.Models.Commands;
    using Hogwartz.Enrollment.Application.Enrollment.Models.Responses;
    using Hogwartz.Enrollment.Application.Enrollment.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly ILogger<EnrollmentController> _logger;
        private readonly IAddEnrollmentAppService _addEnrollmentAppService;
        private readonly IGetEnrollmentAppService _getEnrollmentAppService;
        private readonly IDeleteEnrollmentAppService _deleteEnrollmentAppService;
        private readonly IUpdateEnrollmentAppService _updateEnrollmentAppService;

        public EnrollmentController(ILogger<EnrollmentController> logger,
            IAddEnrollmentAppService addEnrollmentAppService,
            IGetEnrollmentAppService getEnrollmentAppService,
            IDeleteEnrollmentAppService deleteEnrollmentAppService,
            IUpdateEnrollmentAppService updateEnrollmentAppService)
        {
            _logger = logger;
            _addEnrollmentAppService = addEnrollmentAppService;
            _getEnrollmentAppService = getEnrollmentAppService;
            _deleteEnrollmentAppService = deleteEnrollmentAppService;
            _updateEnrollmentAppService = updateEnrollmentAppService;
        }

        [HttpGet]
        public EnrollmentResponse Get()
        {
            return _getEnrollmentAppService.Get();
        }

        [HttpPost]
        public void Post([FromBody] AddEnrollmentCommand command)
        {
            _addEnrollmentAppService.Add(command);
        }

        [HttpPut]
        public void Put([FromBody] UpdateEnrollmentCommand command)
        {
            _updateEnrollmentAppService.Update(command);
        }

        [HttpDelete]
        public void Delete([FromBody] DeleteEnrollmentCommand command)
        {
            _deleteEnrollmentAppService.Delete(command);
        }
    }
}
