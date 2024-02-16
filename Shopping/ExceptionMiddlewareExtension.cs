using Grpc.Core;
using Microsoft.AspNetCore.Diagnostics;
using Shopping.API.ErrorModel;

namespace MasterDataService;

public static class ExceptionMiddlewareExtension
{
    public static void ConfigureExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "application/json";
                var contextFeatures = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeatures != null)
                {
                    //context.Response.StatusCode = contextFeatures.Error switch
                    //{
                    //    IDInvalidException => StatusCodes.Status400BadRequest,
                    //    NotFoundException => StatusCodes.Status404NotFound,
                    //    RpcException => StatusCodes.Status507InsufficientStorage,
                    //    _ => StatusCodes.Status500InternalServerError
                    //};
                    (int statusCode, string message) = contextFeatures.Error switch
                    {
                        RpcException => ((int)((RpcException)contextFeatures.Error).Status.StatusCode, ((RpcException)contextFeatures.Error).Status.Detail),
                        _ => (StatusCodes.Status500InternalServerError, contextFeatures.Error.Message)

                    };

                    await context.Response.WriteAsync(new ErrorDetails
                    {
                        StatusCode = statusCode,
                        Message = message
                    }.ToString());
                }
            });
        });
    }
}
