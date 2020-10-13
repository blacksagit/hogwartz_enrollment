namespace Hogwartz.Common.Domain.Person.Models
{
    using Hogwartz.Common.Domain.Common.DDD;
    using System.Collections.Generic;

    public class Person : ValueObject
    {
        public PersonName Name { get; set; }

        public List<PersonDocument> Documents { get; set; }

        public PersonInfo Info { get; set; }
    }
}
