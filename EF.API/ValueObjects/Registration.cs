namespace EF.API.ValueObjects
{
    public record Registration
    {
        public string Country { get; private set; }
        public string Number { get; private set; }

        private Registration() { }

        public Registration(string Country, string Number)
        {
            if (Number?.Length != 6) throw new ApplicationException("Registration number must have 6 characters.");

            this.Country = Country;
            this.Number = Number;
        }

    }
}
