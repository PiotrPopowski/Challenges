namespace EF.API.ValueObjects
{
    public record Registration
    {
        public string Country { get; }
        public string Number { get; }

        public Registration(string country, string number)
        {
            if (number?.Length != 6) throw new ApplicationException("Registration number must have 6 characters.");

            Country = country;
            Number = number;
        }

    }
}
