using EF.API.ValueObjects;

namespace EF.API.Endpoints
{
    public record CreateDriver(string FirstName, string LastName, string CompanyName);
    public record CreateVehicle(string Country, string Registration);
    public record CreateCompany(string CompanyName);
    public record AddVehicleToCompany(string RegistrationNumber, string CompanyName);
    public record CreateSchedule(DateTime From, DateTime To, string VehicleRegistrationNo, string DriverFirstName, string DriverLastName, string CompanyName);
    public record AddDriverToCompany(string DriverId, string CompanyName);
}
