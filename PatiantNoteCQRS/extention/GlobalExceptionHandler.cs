using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;


namespace PatiantNoteCQRS.extention
{
    public static class GlobalExceptionHandler
    {

        public static void HandlerException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(o =>
            o.Run(async context =>
            {
                var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                var exception = errorFeature.Error;
                if(!(exception is FluentValidation.ValidationException ValidationException))
                    throw exception;    
                var response =ValidationException.Errors.Select  (x => new 
                {
                    PropertyName = x.PropertyName, ErrorMessage = x.ErrorMessage 
                });

                var erorrcontent=JsonSerializer.Serialize(response);
                context.Response.StatusCode=(int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(erorrcontent);

            }
            )
            );
        }
    }
}
