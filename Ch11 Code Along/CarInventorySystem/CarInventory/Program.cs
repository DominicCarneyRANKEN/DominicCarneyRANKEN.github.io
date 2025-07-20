using CarInventory;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Dependency Injection will constrct a carDbv object when needed
//Allow the CarDb to be injected into the methods that need it
builder.Services.AddDbContext<CarDb>(opt => opt.UseInMemoryDatabase("CarList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//http://localhost:2025/getcars


var app = builder.Build();

RouteGroupBuilder cars = app.MapGroup("/cars");

cars.MapGet("/", GetAllCars);
//wire a post request to the CreateCar method
cars.MapPost("/", CreateCar);
cars.MapGet("/{id}", GetCar);

app.Run();

static async Task<IResult> GetAllCars(CarDb db)
{
    return TypedResults.Ok(await db.Cars.Select(x => new CarDTO(x)).ToArrayAsync());
}

static async Task<IResult> CreateCar(Car car, CarDb db)
{
    db.Cars.Add(car);
    await db.SaveChangesAsync();

    var dto = new CarDTO(car);
    return TypedResults.Created($"/cars/{car.Id}", dto);
}

static async Task<IResult> GetCar(int id, CarDb db)
{
    return await db.Cars.FindAsync(id)
        is Car car
            ? TypedResults.Ok(new CarDTO(car))
            : TypedResults.NotFound();
}
