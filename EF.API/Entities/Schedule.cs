namespace EF.API.Entities
{
    public sealed class Schedule
    {
        public Guid Id { get; private set; }
        public DateTime To { get; private set; }
        public DateTime From { get; private set; }
        public Driver Driver { get; private set; }
        public Vehicle Vehicle { get; private set; }
        public Company Company { get; private set; }


        private Schedule() { }

        public Schedule(DateTime to, DateTime from, Driver driver, Vehicle vehicle, Company company)
        {
            Id = Guid.NewGuid();
            To = to;
            From = from;
            Driver = driver;
            Vehicle = vehicle;
            Company = company;
        }

    }
}
