namespace ApiSecondClass.Middleware
{
    public class RequestLogginMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        private readonly ILogger<RequestLogginMiddleware> _logger;

        public RequestLogginMiddleware(RequestDelegate requestDelegate, ILogger<RequestLogginMiddleware> logger)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("Entro RequestLogginMiddleware");

            await _requestDelegate(context);
        }
    }
}
