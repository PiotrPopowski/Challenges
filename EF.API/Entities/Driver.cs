using EF.API.ValueObjects;

namespace EF.API.Entities
{
    public class Driver
    {
        public Guid Id { get; set; }
        public Name Name { get; set; }
        public Company Company { get; set; }

        public Driver(Name name, Company company)
        {
            Id = Guid.NewGuid();
            Name = name;
            Company = company;
        }
    }
}
