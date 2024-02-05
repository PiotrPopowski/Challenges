namespace EF.API.Entities
{
    public class Company
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public virtual List<Driver> Drivers { get; private set; } = new List<Driver>();
        public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();

        private Company() { }

        public Company(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
