using Test.IntegrationTests.Configuration;
using System.Threading.Tasks;
using Xunit;
using Api.Dtos;

namespace Test.IntegrationsTests.Api.Controllers.V1
{
    public class TokenControllerTest : BaseIntegrationTest
    {
        public TokenControllerTest(BaseTestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task TokenCounter_Test()
        {
            var response = await Server
                .CreateRequest($"v1/mobile/token/counter")
                .GetAsync();

            var result = await AssertResponse<TokenDisplayTimeDto>(response, 200, true);

            Assert.Equal("12:00:00", result.Data.DisplayTime);
        }
    }
}