namespace EF.API.Entities
{
    public class Company
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public List<Driver> Drivers { get; private set; } = new List<Driver>();
        public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();

        public Company(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
