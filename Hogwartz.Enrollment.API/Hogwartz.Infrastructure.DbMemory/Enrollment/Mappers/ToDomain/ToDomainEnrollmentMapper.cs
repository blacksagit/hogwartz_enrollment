namespace Hogwartz.Infrastructure.DbMemory.Enrollment.Mappers.ToDomain
{
    using Hogwartz.Common.Domain.Person.Enums;
    using Hogwartz.Common.Domain.Person.Models;
    using Hogwartz.Enrollment.Domain.Enrollment.Enums;
    using Hogwartz.Enrollment.Domain.Enrollment.Models;
    using Hogwartz.Infrastructure.DbMemory.Enrollment.Models;
    using System;
    using System.Collections.Generic;

    public class ToDomainEnrollmentMapper : IMapper<EnrollmentRequestDb, EnrollmentRequest>
    {
        public EnrollmentRequest Map(EnrollmentRequestDb source)
        {
            return new EnrollmentRequest
            {
                Person = new Person
                {
                    Name = new PersonName
                    {
                        First = source.FirstName,
                        Middle = source.MiddleName,
                        Last = source.LastName
                    },
                    Info = new PersonInfo
                    {
                        DateOfBirth = source.DoB,
                        Nationality = source.Nationality,
                        Gender = Enum.Parse<GenderType>(source.Gender)
                    },
                    Documents = new List<PersonDocument>
                    {
                        new PersonDocument
                        {
                            Type = Enum.Parse<DocumentType>(source.TypeIdentification),
                            Number = source.Identification
                        }
                    }
                },
                House = Enum.Parse<HouseType>(source.House),
                Status = Enum.Parse<EnrollmentStatus>(source.Status),
                Id = source.Id
            };
        }
    }
}
