using EF.API.ValueObjects;

namespace EF.API.Entities
{
    public class Vehicle
    {
        public Guid Id { get; private set; }
        public Registration Registration { get; private set; }

        private Vehicle() { }

        public Vehicle(Registration registration)
        {
            Id = Guid.NewGuid();
            Registration = registration;
        }
    }
}
