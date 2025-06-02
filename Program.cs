using CarAPI.Data.AppDContext;
using CarAPI.Domain;
using CarAPI.DTO;
using CarAPI.Extention;
using CarAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarService();
builder.Configuration.AddUserSecrets("secrets.json"); // connecting the database

var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();



var routes = app.MapGroup("")
    .WithTags("Cars");

routes.MapGet("api/car/all", async (ICarService service) =>
{
    return Results.Ok(await service.GetCarAllAsync());
});


routes.MapGet("api/car/{id}", async ([FromRoute] int id, ICarService service) =>
{
    var car = await service.GetCarIdAsync(id);
    return car != null
     ? TypedResults.Ok(car)
     : Results.ValidationProblem(new Dictionary<string, string[]>
     {
        {"id", new[] { "Unknown id" }  }
     });
});



routes.MapPost("api/cars", async ([FromBody] CarDTO car, ICarService service) =>
{
    return await service.AddCarAsync(car)
    ? TypedResults.Created($"/api/cars", car)
    : Results.ValidationProblem(new Dictionary<string, string[]>
     {
        {"fields", new[] { "Invalid fields" }  }
     });
});


routes.MapPut("api/car/driving/{id}", async ([FromRoute] int id,[FromBody] FuelForDriving fuel, ICarService service) =>
{
    if(fuel.FuelDriving <= 0 || fuel.FuelDriving > 50)
    {
       return Results.ValidationProblem(new Dictionary<string, string[]>
     {
        {"fuel", new[] { "The range of spent fuel is from 0 to 50" }  }
     });
    }
    var car = await service.DriveCarIdAsync(id, fuel.FuelDriving);
    return car != null
    ?TypedResults.Ok(car)
    : Results.ValidationProblem(new Dictionary<string, string[]>
     {
        {"id", new[] { "Unknown id" }  }
     });
});
   


routes.MapDelete("api/car/delete/{id}", async ([FromRoute] int id, ICarService service) =>
{
    return await service.DeleteCarIDAsync(id)
    ? TypedResults.NoContent()
    : Results.ValidationProblem(new Dictionary<string, string[]>
    {
        {"id", new[] { "Unknown id" }  }
    });
});


app.Run();
