using Microsoft.EntityFrameworkCore;
using Repositories;
using StoreApp.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();

builder.Services.ConfigureDbContext(builder.Configuration);
var app = builder.Build();

app.UseStaticFiles();

app.MapControllerRoute(
	name: "default", 
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
