using Api.Extensions;
using Application;
using Persistence;
using WatchDog;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

builder.Services.AddApplicationExtensions();
builder.Services.AddPersistenceExtensions(Configuration);
builder.Services.AddControllers();
builder.Services.AddVersioningExtension();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseWatchDogExceptionLogger();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseErrorHandlerMiddleware();

app.MapControllers();

app.UseWatchDog(options =>
{
    options.WatchPageUsername = "admin";
    options.WatchPagePassword= "admin";
});

app.Run();
