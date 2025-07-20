using GiftCardsShop.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 104857600;
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<GiftCardDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GiftCardDbContext")));

builder.Services.AddRazorPages();

builder.Services.AddAuthentication("CookieAuth").AddCookie("CookieAuth", options =>
{
    options.LoginPath = "/Home/Login";
    options.AccessDeniedPath = "/Home/RoleRequired";
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<GiftCardDbContext>();

    if (!context.Users.Any(u => u.Username == "admin"))
    {
        context.Users.Add(new UserAccounts
        {
            Username = "admin",
            FirstName = "Evan",
            LastName = "Gudmestad",
            Email = "admin@email.com",
            Password = "Admin123",
            Roles = "Admin"
        });
        context.SaveChanges();
    }
}




if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
    }

app.UseHttpsRedirection();


app.UseRouting();

app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "{controller=Admin}/{action=Index}/{id?}"
    );



app.Run();
