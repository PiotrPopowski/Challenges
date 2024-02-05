using Azure;
using EF.API.Entities;
using EF.API.Persistence;
using EF.API.ValueObjects;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EF.API.Endpoints
{
    public static class ApiEndpoints
    {
        public static void MapApiEndpoints(this WebApplication app) 
        {
            app.MapGet("/Companies", async (ApplicationDbContext ctx) => 
                await ctx.Companies.AsNoTracking().Include(x => x.Drivers).Include(x => x.Vehicles).ToListAsync());
            app.MapPost("/Company", async ([FromBody] CreateCompany request, ApplicationDbContext ctx) =>
            {
                if (ctx.Companies.Include(c => c.Drivers).Include(c => c.Vehicles).Any(x => x.Name == request.CompanyName))
                    return Results.BadRequest("Company already exists.");

                var company = new Company(request.CompanyName);
                ctx.Companies.Add(company);
                await ctx.SaveChangesAsync();

                return Results.Ok();
            }).WithName("CreateCompany");

            app.MapPost("/Company/AddVehicle", async ([FromBody]AddVehicleToCompany request, ApplicationDbContext ctx) =>
            {
                var vehicle = ctx.Vehicles.FirstOrDefault(x => x.Registration.Number == request.RegistrationNumber);
                if (vehicle == null)
                    return Results.BadRequest("Vehicle not found.");

                var company = ctx.Companies.FirstOrDefault(x => x.Name == request.CompanyName);
                if (company == null)
                    return Results.BadRequest("Company not found.");

                company.Vehicles.Add(vehicle);
                await ctx.SaveChangesAsync();

                return Results.Ok();
            });

            app.MapPost("/Company/AddDriver", async ([FromBody]AddDriverToCompany request, ApplicationDbContext ctx) =>
            {
                var driver = ctx.Drivers.FirstOrDefault(x => x.Id == Guid.Parse(request.DriverId));
                if (driver == null)
                    return Results.BadRequest("Driver not found.");

                var company = ctx.Companies.FirstOrDefault(x => x.Name == request.CompanyName);
                if (company == null)
                    return Results.BadRequest("Company not found.");

                company.Drivers.Add(driver);
                await ctx.SaveChangesAsync();

                return Results.Ok();
            });

            app.MapGet("/Drivers", async (ApplicationDbContext ctx) => await ctx.Drivers.AsNoTracking().ToListAsync());
            app.MapPost("/Driver", async ([FromBody]CreateDriver request, ApplicationDbContext ctx) =>
            {
                var company = ctx.Companies.FirstOrDefault(x => x.Name == request.CompanyName);
                if (company == null)
                {
                    return Results.NotFound(request.CompanyName);
                }

                var driverName = new Name(request.FirstName, request.LastName);
                if (ctx.Drivers.Any(x => x.Name == driverName))
                    return Results.BadRequest("Driver with that name already exists.");

                var driver = new Driver(driverName, company);
                ctx.Drivers.Add(driver);
                await ctx.SaveChangesAsync();

                return Results.Ok();
            }).WithName("CreateDriver")
            .Accepts<CreateDriver>("application/json").Produces(200).Produces(404)
            .WithOpenApi();

            app.MapGet("/Vehicles", async (ApplicationDbContext ctx) => await ctx.Vehicles.AsNoTracking().ToListAsync());
            app.MapPost("/Vehicle", async ([FromBody] CreateVehicle request, ApplicationDbContext ctx) =>
            {
                if (ctx.Vehicles.Any(x => x.Registration.Number == request.Registration))
                    return Results.BadRequest("Registration already exists.");

                var vehicle = new Vehicle(new Registration(request.Country, request.Registration));
                ctx.Vehicles.Add(vehicle);
                await ctx.SaveChangesAsync();

                return Results.Ok();
            });

            app.MapGet("/Schedules", async (ApplicationDbContext ctx) => await ctx.Schedules.AsNoTracking().ToListAsync());
            app.MapPost("/Schedule", async ([FromBody] CreateSchedule request, ApplicationDbContext ctx) =>
            {
                if (ctx.Schedules.Any(x => x.From == request.From && x.To == request.To && x.Company.Name == request.CompanyName))
                    return Results.BadRequest("Schedule exists");

                var driverName = new Name(request.DriverFirstName, request.DriverLastName);
                var driver = ctx.Drivers.FirstOrDefault(x => x.Name == driverName);
                if (driver == null)
                    return Results.BadRequest("Driver not found.");

                var company = ctx.Companies.FirstOrDefault(x => x.Name == request.CompanyName);
                if (company == null)
                    return Results.BadRequest("Company not found.");

                var vehicle = ctx.Vehicles.FirstOrDefault(x => x.Registration.Number == request.VehicleRegistrationNo);
                if (vehicle == null)
                    return Results.BadRequest("Vehicle not found.");

                var schedule = new Schedule(request.To, request.From, driver, vehicle, company);
                ctx.Schedules.Add(schedule);
                await ctx.SaveChangesAsync();

                return Results.Ok();
            });

            app.MapGet("/Vehicles/TestComplex", async (ApplicationDbContext ctx) =>
            {
                var reg = new Registration("PL", "654321");
                var vehicle1 = ctx.Vehicles.First();
                vehicle1.Registration = reg;
                var vehicle2 = new Vehicle(reg);

                ctx.Add(vehicle2);
                ctx.Update(vehicle1);
                await ctx.SaveChangesAsync();

                return await ctx.Vehicles.Where(x => x.Registration.Number == "654321").ToListAsync();
            });

            app.MapGet("/Drivers/TestOwned", async (ApplicationDbContext ctx) =>
            {
                var driver1 = ctx.Drivers.Include(x => x.Company).First();
                var driver2 = new Driver(new Name("Arnoldo", "Parse"), driver1.Company);

                driver1.Name = driver2.Name;

                ctx.Drivers.Update(driver1);
                ctx.Drivers.Add(driver2);

                await ctx.SaveChangesAsync(); // Works with Complex Types

                return await ctx.Drivers.Where(x => x.Name == driver2.Name).ToListAsync();
            });

            app.MapGet("/Drivers/TestOwnedList", async (ApplicationDbContext ctx) =>
            {
                var driver1 = ctx.Drivers.Include(x => x.Company).First();
                var driver2 = new Driver(new Name("Bom", "Parsse"), driver1.Company);

                var licensing = driver1.Licenses.First();
                var licensingToInster = new License(licensing.Name);

                driver2.Licenses.Add(licensing); // doesnt work
                driver2.Licenses.Add(licensingToInster); // works

                ctx.Drivers.Add(driver2);

                await ctx.SaveChangesAsync();

                return await ctx.Drivers.Where(x => x.Name.FirstName == driver2.Name.FirstName && x.Name.LastName == driver2.Name.LastName).ToListAsync();
            });
        }
    }
}
