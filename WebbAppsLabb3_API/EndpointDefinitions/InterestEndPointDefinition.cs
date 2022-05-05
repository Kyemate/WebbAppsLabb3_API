


namespace WebbAppsLabb3_API.EndpointDefinitions;

public class InterestEndPointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/interests/{personId}", (int personId, InterestService apiService) 
            => apiService.GetInterestsByPerson(personId));
        app.MapPost("/interest/{interest}", (InterestDto interest, InterestService apiService) 
            => apiService.PostInterest(interest));
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<InterestService>();
    }
}