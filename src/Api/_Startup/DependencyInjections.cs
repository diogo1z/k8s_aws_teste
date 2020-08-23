using Microsoft.Extensions.DependencyInjection;
using Api.Configurations;
using Vidalink.Net.Logging;

namespace Api._Startup
{
    public static class DependencyInjections
    {
        public static void Add(IServiceCollection services)
        {
            services.AddScoped<GlobalExceptionHandlingFilter>();
            services.AddSingleton<IConsole, Console>();
        }
    }
}