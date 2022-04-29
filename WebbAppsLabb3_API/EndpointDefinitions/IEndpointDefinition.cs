namespace WebbAppsLabb3_API.EndpointDefinitions;

public interface IEndpointDefinition
{
    void DefineEndpoints(WebApplication app);
    void DefineServices(IServiceCollection services);
}