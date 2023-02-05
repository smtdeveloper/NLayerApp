using Microsoft.AspNetCore.Diagnostics;
using NLayer.Core.DTOs;
using NLayer.Core.DTOs.GenericDTO;
using NLayer.Service.Exceptions;
using System.Net.WebSockets;
using System.Text.Json;

namespace NLayer.API.Middilewares
{ 
    public static class UseCustomExceptionHandler 
    {
        public static void UseCustomException(this IApplicationBuilder app) 
        {
            app.UseExceptionHandler(config => 
            {
                config.Run(async context => 
                {
                    context.Response.ContentType= "application/json";
                    var exeptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = exeptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException=> 404,
                        _ => 500
                    };

                    context.Response.StatusCode = statusCode;

                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exeptionFeature.Error.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));


                });

            });
        }
    }
}
