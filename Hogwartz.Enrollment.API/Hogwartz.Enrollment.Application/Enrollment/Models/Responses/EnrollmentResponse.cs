namespace Hogwartz.Enrollment.Application.Enrollment.Models.Responses
{
    using Hogwartz.Enrollment.Domain.Enrollment.Models;
    using System.Collections.Generic;

    public class EnrollmentResponse
    {
        public IEnumerable<EnrollmentRequest> Response { get; set; }
    }
}
