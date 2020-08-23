using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Vidalink.Net.Api.Http.Models;
using Vidalink.Net.Logging;

namespace Api.Configurations
{
    public class GlobalExceptionHandlingFilter : IExceptionFilter
    {
        private readonly IConfiguration _configuration;
        private readonly IConsole _console;

        public GlobalExceptionHandlingFilter(IConfiguration configuration, IConsole console)
        {
            _console = console;
            _configuration = configuration;
        }

        public void OnException(ExceptionContext context)
        {
            var request = context.HttpContext.Request;

            _console.LogAsync(Severity.Error,
                         "API MOBILE",
                         _configuration["ASPNETCORE_ENVIRONMENT"]?.ToLower(),
                         $"HOST> '{request.Host}' - '{request.Method}: {request.Path}' - Error: {context.Exception.Message}",
                         true,
                         context.Exception.StackTrace);

            context.Result = ConfigureResponse(HttpStatusCode.InternalServerError, context.Exception.Message);
        }

        private static IActionResult ConfigureResponse(HttpStatusCode httpStatusCode, string message)
        {
            var jsonResult = new JsonResult(new Response<object>(httpStatusCode, message));
            jsonResult.StatusCode = (int)httpStatusCode;
            return jsonResult;
        }
    }
}