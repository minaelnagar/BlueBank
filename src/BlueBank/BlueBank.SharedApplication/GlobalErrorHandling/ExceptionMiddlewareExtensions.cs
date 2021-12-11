using BlueBank.SharedApplication.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Serilog;
using System.Net;

namespace BlueBank.SharedApplication.GlobalErrorHandling
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        string errorMessage = $@"Unhandled exception when processing request
                            Request Path: {context.Request.Path}
                            Request Headers: {context.Request.Headers.AllHeadersToString()}
                            Request Query String: {context.Request.QueryString}
                            Request Body: {context.Request.BodyToString()}";
                        Log.Error(contextFeature.Error, errorMessage);

                        await context.Response.WriteAsync(new
                        {
                            context.Response.StatusCode,
                            contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });
        }
    }
}
