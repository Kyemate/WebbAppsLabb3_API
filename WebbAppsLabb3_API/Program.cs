global using Service.Services;
global using Service.Models;
using Domain;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using WebbAppsLabb3_API.EndpointDefinitions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddScoped(typeof(IRepository<>), typeof(Repository<>));
    
builder.Services.AddEndpointDefinitions(typeof(Program));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseEndpointDefinitions();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.EnsureDeleted();
    scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.EnsureCreated();
}


app.UseHttpsRedirection();
app.Run();
