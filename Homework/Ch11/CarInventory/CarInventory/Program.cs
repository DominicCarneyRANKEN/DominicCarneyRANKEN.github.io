using CarInventory;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Dependency Injection - Can also construct a CarDB object when neededwwww
//Which will allow the CarDB to be injected into the methods that needs it
builder.Services.AddDbContext<CarDB>(opt => opt.UseInMemoryDatabase("CarList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter(); 


var app = builder.Build();

RouteGroupBuilder cars = app.MapGroup("/cars");



cars.MapGet("/", GetAllCars);
cars.MapGet("/{id}", GetCar);
cars.MapPost("/", CreateCar);
cars.MapPut("/{id}", UpdateCar);
//Wire up a delete car by id function
cars.MapDelete("/{id}", DeleteCar);
cars.MapGet("/available", GetAvailableCars);

app.Run();

static async Task<IResult> GetAvailableCars(CarDB carDB)
{
    return TypedResults.Ok(await carDB.Cars.Where(car => car.IsAvailable).Select(x => new CarDTO(x)).ToArrayAsync());
}

static async Task<IResult> UpdateCar(int id, CarDTO carDTO, CarDB db)
{
    var car = await db.Cars.FindAsync(id);
    if (car is null) return TypedResults.NotFound();

    car.Make = carDTO.Make;
    car.Model = carDTO.Model;
    car.IsAvailable = carDTO.IsAvailable;

    await db.SaveChangesAsync();

    return TypedResults.Ok(new CarDTO(car));


}

static async Task<IResult> GetAllCars(CarDB db)
{
    return TypedResults.Ok(await db.Cars.Select(x => new CarDTO(x)).ToArrayAsync());
}

static async Task <IResult> CreateCar(Car car, CarDB db)
{
    db.Cars.Add(car);
    await db.SaveChangesAsync();

    var dto = new CarDTO(car);

    return TypedResults.Created($"/cars/{dto.Id}", dto);
}

static async Task<IResult> GetCar(int id, CarDB db)
{
    return await db.Cars.FindAsync(id)
        is Car car
            ? TypedResults.Ok(new CarDTO(car))
            : TypedResults.NotFound();
}

static async Task<IResult> DeleteCar(int id, CarDB db)
{
    if(await db.Cars.FindAsync(id) is Car car)
    {
        db.Cars.Remove(car);
        await db.SaveChangesAsync();
        return TypedResults.NoContent();
    }

    return TypedResults.NotFound();
}
