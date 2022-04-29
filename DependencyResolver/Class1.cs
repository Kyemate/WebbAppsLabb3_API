using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;


namespace Microsoft.Extensions.DependencyInjection
{
    public static class StartupExtensions
    {
        public static void RegisterProjectBBServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            //Do your setup here
            services.AddDbContext
        }
    }
}