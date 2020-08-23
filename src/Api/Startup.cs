using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Api._Startup;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;

namespace Mobile
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            DependencyInjections.Add(services);
            Swagger.Add(services);
            ControllersAndNewtonsoftJson.Add(services);
            HealthCheck.Add(services);
            HttpClient.Add(services, Configuration);
        }

        public void Configure(IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            Swagger.Use(app, provider);
            HealthCheck.Use(app);
            app.UseRouting();
            app.UseCors();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
