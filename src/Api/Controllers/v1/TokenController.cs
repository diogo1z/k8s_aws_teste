using System;
using Api.Controllers;
using Api.Dtos;
using Microsoft.AspNetCore.Mvc;
using Vidalink.Net.Api.Http;
using Vidalink.Net.Api.Http.Models;

namespace Mobile.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    public class TokenController : MobileControllerBase
    {
        /// <summary>
        /// Get the time that counter should be shown on card screen
        /// </summary>
        /// <response code="200">If the time is gotten successfully</response>
        /// <response code="500">If any error occurs while processing the request</response>
        [HttpGet("token/counter")]
        [ProducesResponseType(typeof(Response<TokenDisplayTimeDto>), 200)]
        [ProducesResponseType(typeof(Response<TokenDisplayTimeDto>), 500)]
        public ActionResult<Response<TokenDisplayTimeDto>> GetCounterInformation()
        {
            return this.CreateResponse200OK("Counter information", new TokenDisplayTimeDto(720));
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("general-exception-test")]
        public ActionResult<Response<object>> TestException()
        {
            throw new ArgumentException("Success! You got your general error");
        }
    }
}