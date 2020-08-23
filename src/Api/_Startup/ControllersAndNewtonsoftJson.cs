using System.Globalization;
using Api.Configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Api._Startup
{
    public static class ControllersAndNewtonsoftJson
    {
        public static void Add(IServiceCollection services)
        {
            services
                .AddControllers(options =>
                {
                    options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                    options.Filters.Add(new ServiceFilterAttribute(typeof(GlobalExceptionHandlingFilter)));
                })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.Culture = new CultureInfo("pt-BR");
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });
        }
    }
}