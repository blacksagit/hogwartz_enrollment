namespace Hogwartz.Infrastructure.DbMemory.Enrollment.Mappers.ToInfrastructure
{
    using Hogwartz.Enrollment.Domain.Enrollment.Models;
    using Hogwartz.Infrastructure.DbMemory.Enrollment.Models;
    using System.Linq;

    public class ToInfrastructureEnrollmentMapper : IMapper<EnrollmentRequest, EnrollmentRequestDb>
    {
        public EnrollmentRequestDb Map(EnrollmentRequest source)
        {
            return new EnrollmentRequestDb
            {
                FirstName = source.Person.Name.First,
                MiddleName = source.Person.Name.Middle,
                LastName = source.Person.Name.Last,
                DoB = source.Person.Info.DateOfBirth,
                Gender = source.Person.Info.Gender.ToString(),
                Nationality = source.Person.Info.Nationality,
                House = source.House.ToString(),
                TypeIdentification = source.Person.Documents.FirstOrDefault()?.Type.ToString(),
                Identification = source.Person.Documents.FirstOrDefault()?.Number,
                Status = source.Status.ToString()
            };
        }
    }
}
