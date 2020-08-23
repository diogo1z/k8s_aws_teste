using System;
using System.Linq;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace Api._Startup
{
    public static class HttpClient
    {
        public static void Add(IServiceCollection services, IConfiguration configuration)
        {
            var externalApps = configuration.GetSection("InternalCall").AsEnumerable();

            externalApps.ToList().ForEach(_ =>
            {
                if (_.Key != "InternalCall")
                {
                    services.AddHttpClient(_.Key.Replace("InternalCall:", ""), client =>
                     {
                         client.BaseAddress = new Uri(_.Value);
                         client.DefaultRequestHeaders.Add("Accept", "application/json");
                     })
                    .AddTransientHttpErrorPolicy(builder => builder.WaitAndRetryAsync(new[]
                    {
                        TimeSpan.FromSeconds(1),
                        TimeSpan.FromSeconds(2),
                        TimeSpan.FromSeconds(3)
                    }))
                    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                    {
                        ClientCertificateOptions = ClientCertificateOption.Manual,
                        ServerCertificateCustomValidationCallback =
                            (httpRequestMessage, cert, cetChain, policyErrors) =>
                            {
                                return true;
                            }
                    });
                }
            });
        }
    }
}