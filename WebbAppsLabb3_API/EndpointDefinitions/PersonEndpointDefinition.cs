using Service;

namespace WebbAppsLabb3_API.EndpointDefinitions;

public class PersonEndpointDefinition : IEndpointDefinition
{
    

    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/persons", (int page, int pageSize, PersonService apiService) 
            => apiService.GetPersons(new PageParameters(page, pageSize)));

        app.MapGet("/persons/{name}", (int page, int pageSize, string name, bool? includeAll, PersonService apiService) 
            => apiService.GetPersons(new PageParameters(page, pageSize), name, includeAll));
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<PersonService>();
    }
}