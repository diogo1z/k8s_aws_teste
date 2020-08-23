using System.Threading.Tasks;
using Newtonsoft.Json;
using Test.IntegrationTests.Configuration;
using Vidalink.Net.Api.Http.Models;
using Xunit;

namespace Test.IntegrationsTests.Api.Controllers
{
    public class GlobalExceptionHandlerTest : BaseIntegrationTest
    {
        public GlobalExceptionHandlerTest(BaseTestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task GeneralExceptionThrown_Test()
        {
            var response = await Server
                .CreateRequest("v1/mobile/general-exception-test")
                .GetAsync();

             Assert.Equal(500, (int)response.StatusCode);

            var resultResponseModel = JsonConvert.DeserializeObject<Response<object>>(await response.Content.ReadAsStringAsync());
            Assert.Null(resultResponseModel.Data);
            Assert.Equal("Success! You got your general error", resultResponseModel.Message);
        }
    }

}