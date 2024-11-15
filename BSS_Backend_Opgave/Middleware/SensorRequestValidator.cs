using BSS_Backend_Opgave.Repositories.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using BSS_Backend_Opgave.Services.Service.Interfaces;

namespace BSS_Backend_Opgave.API
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SensorRequestValidator
    {
        private readonly RequestDelegate _next;

        public SensorRequestValidator(RequestDelegate next)
        {
            _next = next;
        }



        public async Task Invoke(HttpContext httpContext, IAuthenticationService authenticationService)
        {
            var routePath = httpContext.Request.Path;

            if(routePath.ToString().StartsWith("/api/sensors/"))
            {
                int.TryParse(routePath.ToString().AsSpan("/api/sensors/".Length), out var parsedSensorId);
                int.TryParse(httpContext.User.FindFirstValue("organisationId"), out var parsedOrganisationId);

                var ownedSensors = httpContext.User.FindFirstValue("ownedSensors");

                if(!await authenticationService.IsViewable(parsedSensorId, parsedOrganisationId))
                {
                    httpContext.Response.StatusCode = 401;
                    await httpContext.Response.WriteAsJsonAsync(

                        new ValidatorResponse
                        {
                            ErrorMessage = "Access Denied. This sensor exists outside your organisations scope!",
                            OwnedSensors = $"These sensors can be accessed by your organisation: {ownedSensors}"
                        }
                    );

                    return;
                }
            }
            
            await _next(httpContext);
        }
    }


    /// <summary>
    /// The class for the response object that is sent when an attempt of 
    /// </summary>
    public class ValidatorResponse
    {
        /// <summary>
        /// Error Message
        /// </summary>
        public string ErrorMessage { get; set; } = null!;

        /// <summary>
        /// A string with the Id's of all the sensors you are allowed to access
        /// </summary>
        public string OwnedSensors { get; set; } = null!;
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TestMiddlewareExtensions
    {
        public static IApplicationBuilder UseSensorRequestValidator(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SensorRequestValidator>();
        }
    }
}
