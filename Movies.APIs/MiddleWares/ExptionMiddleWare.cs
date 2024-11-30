using Movies.PL.APIs.Errors;
using System.Text.Json;

namespace Movies.PL.APIs.MiddleWares
{
    public class ExptionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExptionMiddleWare> _logger;
        private readonly IHostEnvironment _env;

        public ExptionMiddleWare(RequestDelegate next, ILogger<ExptionMiddleWare> logger,IHostEnvironment env)
        {
            this._next = next;
            this._logger = logger;
            this._env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
              await  _next.Invoke(context);
            }
            catch (Exception ex)
            {
                //log the error 

                _logger.LogError(ex, ex.Message);
                var errorResponse = _env.IsDevelopment() ?
                    new ApiExecptionResponse(500, ex.Message, ex.StackTrace)
                    : new ApiExecptionResponse(500, ex.Message);

                //write the error  into response 


                var JsonOptions = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var serlizedErrorResponse = JsonSerializer.Serialize(errorResponse,JsonOptions);
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";



              await   context.Response.WriteAsync(serlizedErrorResponse);


                
            }

        }


    }
}
