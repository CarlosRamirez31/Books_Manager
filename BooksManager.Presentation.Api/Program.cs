using Api.Extensions;
using Application;
using BooksManager.Infrastructure.Identity;
using BooksManager.Infrastructure.Identity.Entities;
using BooksManager.Infrastructure.Identity.Seeds;
using BooksManager.Infrastructure.Shared;
using Microsoft.AspNetCore.Identity;
using Persistence;
using WatchDog;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

builder.Services.AddApplicationExtensions();
builder.Services.AddPersistenceExtensions(Configuration);
builder.Services.AddIdentityInfrastructure(Configuration);
builder.Services.AddSharedInfrastructure();
builder.Services.AddControllers();
builder.Services.AddVersioningExtension();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        await DefaultRoles.SeedAsync(userManager, roleManager);
        await DefaultAdminUser.SeedAsync(userManager, roleManager);
        await DefaultBasicUser.SeedAsync(userManager, roleManager);
    }
    catch(Exception ex)
    {

    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseWatchDogExceptionLogger();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseErrorHandlerMiddleware();

app.MapControllers();

app.UseWatchDog(options =>
{
    options.WatchPageUsername = "admin";
    options.WatchPagePassword= "admin";
});

app.Run();
