using System.Text.Json;

namespace ApiSecondClass.Middleware
{
    public class ManageExeptionsMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        private readonly ILogger<RequestLogginMiddleware> _logger;

        private readonly IWebHostEnvironment _env;

        public ManageExeptionsMiddleware(RequestDelegate requestDelegate, ILogger<RequestLogginMiddleware> logger, IWebHostEnvironment env)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandledExceptionAsync(context, ex);
            }
        }

        private Task HandledExceptionAsync(HttpContext context, Exception ex)
        {
            _logger.LogError(ex.Message);

            var response = new
            {
                Statuscode = context.Response.StatusCode,
                Mensaje = "Error desde Api Carrito.",
                DetalleError = ex.Message
            };

            var json = JsonSerializer.Serialize(response);

            return context.Response.WriteAsync(json);
        }
    }
}
