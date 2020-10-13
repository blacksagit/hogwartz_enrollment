namespace Hogwartz.Common.Domain.Person.Models
{
    using Hogwartz.Common.Domain.Common.DDD;

    public class PersonName : ValueObject
    {
        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }
    }
}
