using System.Net;
using mailSender_api.Model;
using Newtonsoft.Json;

namespace mailSender_api.Middleware
{
    public class ErrorMiddleware
    {
        
        private readonly RequestDelegate next;

        public ErrorMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
    
            ErrorResponse ErrorResponse;
            int statusCode = context.Response.StatusCode;

            if (statusCode >= 200 && statusCode < 301)
            {
                statusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            
            ErrorResponse = new ErrorResponse(statusCode.ToString(),
                                                  $"{ex.Message}{ex?.InnerException?.Message}");
             

            var result = JsonConvert.SerializeObject(ErrorResponse);
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}