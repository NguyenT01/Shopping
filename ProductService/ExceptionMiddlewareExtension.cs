namespace ProductServiceNamespace;

public static class ExceptionMiddlewareExtension
{/*
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
                    context.Response.StatusCode = contextFeatures.Error switch
                    {
                        IDInvalidException => StatusCodes.Status400BadRequest,
                        NotFoundException => StatusCodes.Status404NotFound,
                        _ => StatusCodes.Status500InternalServerError
                    };

                    await context.Response.WriteAsync(JsonSerializer.Serialize(new
                    {
                        Code = context.Response.StatusCode,
                        contextFeatures.Error.Message
                    }.ToString()));
                }
            });
        });
    }*/
}
