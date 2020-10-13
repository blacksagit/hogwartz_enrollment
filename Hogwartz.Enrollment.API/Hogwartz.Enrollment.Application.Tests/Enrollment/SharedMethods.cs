namespace Hogwartz.Enrollment.Application.Tests.Enrollment
{
    using Hogwartz.Common.Domain.Person.Enums;
    using Hogwartz.Common.Domain.Person.Models;
    using Hogwartz.Enrollment.Domain.Enrollment.Enums;
    using Hogwartz.Enrollment.Domain.Enrollment.Models;
    using System;
    using System.Collections.Generic;

    public class SharedMethods
    {
        public static EnrollmentRequest GetEnrollmentRequest()
        {
            return new EnrollmentRequest
            {
                Person = new Person
                {
                    Name = new PersonName
                    {
                        First = "First",
                        Middle = "Middle",
                        Last = "Last"
                    },
                    Info = new PersonInfo
                    {
                        DateOfBirth = DateTime.Today
                    },
                    Documents = new List<PersonDocument>
                    {
                        new PersonDocument
                        {
                            Type = DocumentType.Identification,
                            Number = "11223344"
                        }
                    }
                },
                House = HouseType.Gryffindor,
                Status = EnrollmentStatus.Pending,
                Id = 1
            };
        }
    }
}
