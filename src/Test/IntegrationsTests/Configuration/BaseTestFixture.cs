using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

namespace Test.IntegrationTests.Configuration
{
    public class BaseTestFixture : IDisposable
    {
        public readonly TestServer Server;
        public readonly HttpClient Client;
        public readonly IConfiguration Configuration;
        public BaseTestFixture()
        {
            Server = new TestServer(
                        new WebHostBuilder()
                            .UseEnvironment("testing")
                            .UseStartup<Mobile.Startup>());            

            Configuration = Server.Host.Services.GetService(typeof(IConfiguration)) as IConfiguration;
            Client = Server.CreateClient();
        }

        public void Dispose()
        {
            Client.Dispose();
            Server.Dispose();
        }
    }
}