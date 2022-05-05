namespace WebbAppsLabb3_API.EndpointDefinitions;

public class LinkEndPointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/links/{personId}", (int personId, LinkService apiService) => apiService.GetLinksByPerson(personId));
        app.MapPost("/link/{link}", (LinkDto link, LinkService apiService) => apiService.PostLink(link));
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<LinkService>();
    }
}