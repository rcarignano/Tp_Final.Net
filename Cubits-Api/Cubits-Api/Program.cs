using Cubits.Application;
using Cubits.Application.Validators;
using Cubits.Infraestructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost5173", builder =>
    {
        builder.WithOrigins("http://localhost:5173")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.InstallApplication();
builder.Services.InstallRepositories(connectionString);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.UseCors("AllowLocalhost5173");
app.MapControllers();

app.Run();
