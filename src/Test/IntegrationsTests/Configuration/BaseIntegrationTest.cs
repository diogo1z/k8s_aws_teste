using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Vidalink.Net.Api.Http.Models;
using Xunit;

namespace Test.IntegrationTests.Configuration
{
    [Collection("Base collection")]
    public class BaseIntegrationTest : IDisposable
    {
        public readonly TestServer Server;
        protected readonly HttpClient Client;
        private readonly IConfiguration _configuration;
        protected BaseTestFixture Fixture { get; }

        protected BaseIntegrationTest(BaseTestFixture fixture)
        {
            Fixture = fixture;
            Server = fixture.Server;
            Client = fixture.Client;
            _configuration = Server.Host.Services.GetService(typeof(IConfiguration)) as IConfiguration;
        }

        protected StringContent BuildRequestContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

        protected async Task<Response<T>> AssertResponse<T>(HttpResponseMessage response, int expectedStatusCode, bool expectedData)
        {
            var result = JsonConvert.DeserializeObject<Response<T>>(await response.Content.ReadAsStringAsync());

            if ((int)response.StatusCode == 500)
                throw new Xunit.Sdk.AssertActualExpectedException(expectedStatusCode, 500, result.Message);

            Assert.Equal(expectedStatusCode, (int)response.StatusCode);

            if (expectedData)
                Assert.NotNull(result.Data);

            return result;
        }

        public void Dispose()
        {
        }
    }
}