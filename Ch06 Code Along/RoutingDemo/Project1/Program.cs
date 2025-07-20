//In general, after ASP.NET Core 3.0, we use endpoint routing, which is a new feature
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Add the services necessary to subport an MVC app.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

//Selects the endpoint for the route if one is found
app.UseRouting();

app.UseAuthorization();

//Top to bottom your routes must be configured from-
//most specific to least specific

//5 Required segments
app.MapControllerRoute(
    name: "paging_and_sorting",
    pattern: "{controller=Home}/{action=Index}/{id}/page{num}/sort-by-{sortby}"
    );

//4 required segments
app.MapControllerRoute(
    name: "paging",
    pattern: "{controller=Home}/{action=Index}/{id}/page{num}"
    );

app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

//Default route has 0 required segments
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
