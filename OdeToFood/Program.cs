using AspNetCore.Unobtrusive.Ajax;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OdeToFood.Data;
using OdeToFood.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString).EnableSensitiveDataLogging());
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddUnobtrusiveAjax();

builder.Services.AddIdentity<UserProfile, AppRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddDefaultUI()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
var app = builder.Build();

using var serviceScope = app.Services.CreateScope();

using var userManager = serviceScope.ServiceProvider.GetService<UserManager<UserProfile>>();
using var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<AppRole>>();

AppDataInit.SeedIdentity(userManager, roleManager);
SetupAppData(app, app.Environment);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseUnobtrusiveAjax();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    "Cuisine", "cuisine/{name}",
    new { controller = "Cuisine", action = "Search", name = "" }
);
app.MapRazorPages();

app.Run();

void SetupAppData(IApplicationBuilder app, IWebHostEnvironment env)
{
    using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
    using var context = serviceScope
        .ServiceProvider
        .GetService<ApplicationDbContext>();
    if (context == null)
    {
        throw new ApplicationException("Problem in services. Can not initialize ApplicationDbContext");
    }
    while (true)
    {
        try
        {
            context.Database.OpenConnection();
            context.Database.CloseConnection();
            break;
        }
        catch (SqlException e)
        {
            if (e.Message.Contains("The login failed.")) { break; }
            Thread.Sleep(1000);
        }
    }
    AppDataInit.SeedRestaurant(context);
}