namespace Hogwartz.Infrastructure.DbMemory.Enrollment.Models
{
    using System;

    public class EnrollmentRequestDb
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DoB { get; set; }
        public string Nationality { get; set; }
        public string House { get; set; }
        public string TypeIdentification { get; set; }
        public string Identification { get; set; }
        public string Status { get; set; }
    }
}
