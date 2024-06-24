namespace RealEstate.Middlewares
{
    using Newtonsoft.Json;
    using Models;
    public class GlobalExceptionHandler : IMiddleware
    {
        private ILogger<GlobalExceptionHandler> _logger;
        private const int INTERNAL_SERVER_ERROR_CODE = 500;
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                context.Response.StatusCode = INTERNAL_SERVER_ERROR_CODE;
                context.Response.ContentType = "application/json";
                _logger.LogError($"Exception details: {message}");

                var response = new ExceptionDetails(INTERNAL_SERVER_ERROR_CODE, message);
                await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
        }
    }
}
