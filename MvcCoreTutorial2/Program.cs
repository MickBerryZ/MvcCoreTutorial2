using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MvcCoreTutorial2.Models.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
// whatever services are needed in application will be declared here
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// section for configuring middlewares
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Index method of home controller will be execute first thing in the application
// it is default URL
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Person}/{action=DisplayPersons}/{id?}");

app.Run();
