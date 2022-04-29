using Domain;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Service.Models;
using Service.Services;
using WebbAppsLabb3_API.EndpointDefinitions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddScoped(typeof(IRepository<>), typeof(Repository<>))
    .AddScoped<ApiService>()
    ;
    
builder.Services.AddEndpointDefinitions(typeof(Person));

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


app.MapGet("/persons", (ApiService apiService) => apiService.GetPersons());

app.MapGet("/persons/{name}", (string name, bool? includeAll, int? take, ApiService apiService) => apiService.GetPersons(name, includeAll, take));

app.MapGet("/interests/{personId}", (int personId, ApiService apiService) => apiService.GetInterestsByPerson(personId));

app.MapGet("/links/{personId}", (int personId, ApiService apiService) => apiService.GetLinksByPerson(personId));

app.MapPost("/interest/{interest}", (InterestDto interest, ApiService apiService) => apiService.PostInterest(interest));

app.MapPost("/link/{link}", (LinkDto link, ApiService apiService) => apiService.PostLink(link));

app.Run();
