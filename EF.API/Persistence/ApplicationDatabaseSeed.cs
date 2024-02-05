using Bogus;
using Bogus.Extensions.UnitedKingdom;
using EF.API.Entities;
using EF.API.ValueObjects;

namespace EF.API.Persistence
{
    public class ApplicationDatabaseSeed
    {
        public async static Task Seed(ApplicationDbContext context) 
        {
            if (!context.Companies.Any()) 
                await SeedCompanies(context, new Random(911));
        }

        private static async Task SeedCompanies(ApplicationDbContext context, Random seed)
        {
            Randomizer.Seed = seed;
            var faker = new Faker();
            var date = faker.Date.Recent();

            var fakeDriver = new Faker<Driver>()
                .CustomInstantiator(f => (Driver)Activator.CreateInstance(typeof(Driver), true))
                .RuleFor(x => x.Id, f => Guid.NewGuid())
                .RuleFor(x => x.Name, f => new Name(f.Name.FindName(), f.Name.LastName()))
                .RuleFor(x => x.Licenses, f => new List<License>() { new License("FBI"), new License("UOP") });

            var fakeVehicle = new Faker<Vehicle>()
                .CustomInstantiator(f => (Vehicle)Activator.CreateInstance(typeof(Vehicle), true))
                .RuleFor(x => x.Id, f => Guid.NewGuid())
                .RuleFor(x => x.Registration, f => 
                    new Registration(f.Address.Country(), 
                                     f.Random.AlphaNumeric(6)));

            var driver = fakeDriver.Generate();
            var vehicle1 = fakeVehicle.Generate();
            var vehicle2 = fakeVehicle.Generate();

            var fakeCompany = new Faker<Company>()
                .CustomInstantiator(f => (Company)Activator.CreateInstance(typeof(Company), true))
                .RuleFor(x => x.Id, f => Guid.NewGuid())
                .RuleFor(x => x.Name, f => f.Company.CompanyName())
                .RuleFor(x => x.Drivers, new List<Driver>() { driver })
                .RuleFor(x => x.Vehicles, new List<Vehicle>() { vehicle1, vehicle2 });

            var company = fakeCompany.Generate();
            context.Companies.Add(company);

            var fakeSchedule = new Faker<Schedule>()
                .CustomInstantiator(f => (Schedule)Activator.CreateInstance(typeof(Schedule), true))
                .RuleFor(x => x.Id, f => Guid.NewGuid())
                .RuleFor(x => x.From, f => f.Date.Past(2, date))
                .RuleFor(x => x.To, f => f.Date.Future(2, date))
                .RuleFor(x => x.Driver, driver)
                .RuleFor(x => x.Vehicle, vehicle1)
                .RuleFor(x => x.Company, company);

            var schedule = fakeSchedule.Generate();
            context.Schedules.Add(schedule);

            await context.SaveChangesAsync();
        }

    }
}
