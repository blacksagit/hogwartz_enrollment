namespace Hogwartz.Common.Domain.Person.Models
{
    using Hogwartz.Common.Domain.Common.DDD;
    using Hogwartz.Common.Domain.Person.Enums;
    using System;
    using System.Text.Json.Serialization;

    public class PersonInfo : ValueObject
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public GenderType Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
    }
}
