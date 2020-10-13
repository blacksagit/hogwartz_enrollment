namespace Hogwartz.Enrollment.Domain.Enrollment.Models
{
    using Hogwartz.Common.Domain.Common.DDD;
    using Hogwartz.Common.Domain.Common.Validators;
    using Hogwartz.Common.Domain.DI;
    using Hogwartz.Common.Domain.Person.Models;
    using Hogwartz.Enrollment.Domain.Enrollment.Enums;
    using Microsoft.Extensions.DependencyInjection;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Serialization;

    public class EnrollmentRequest : AggregateRoot
    {
        private readonly IEnumerable<IValidator<EnrollmentRequest>> _validators;

        public EnrollmentRequest()
        {
            using (var serviceScope = ServiceActivator.GetScope())
            {
                _validators = serviceScope.ServiceProvider.GetServices<IValidator<EnrollmentRequest>>();
            };
        }

        public override int Id { get; set; }

        public Person Person { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public HouseType House { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EnrollmentStatus Status { get; set; }
        
        public void Validate()
        {
            _validators.ToList().ForEach(x => x.Validate(this));
        }
    }
}
