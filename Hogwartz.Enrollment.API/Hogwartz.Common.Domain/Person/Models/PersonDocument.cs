namespace Hogwartz.Common.Domain.Person.Models
{
    using Hogwartz.Common.Domain.Common.DDD;
    using Hogwartz.Common.Domain.Person.Enums;
    using System;
    using System.Text.Json.Serialization;

    public class PersonDocument : ValueObject
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public DocumentType Type { get; set; }
        public string Number { get; set; }
    }
}
