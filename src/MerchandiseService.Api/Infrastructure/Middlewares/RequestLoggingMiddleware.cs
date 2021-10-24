using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MerchandiseService.Api.Infrastructure.Middlewares
{
    /// <summary>
    ///     Middleware логирования входящих HTTP запросов
    /// </summary>
    public class RequestLoggingMiddleware
    {
        /// <summary>
        ///     Создание объекта
        /// </summary>
        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        /// <summary>
        ///     Вызов middleware
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            LogRequestInfo(context);
            await _next(context);
        }

        private void LogRequestInfo(HttpContext context)
        {
            using (_logger.BeginScope($"{DateTime.Now} {context.Request.Protocol} {context.Request.Method} request"))
            {
                _logger.LogInformation("----> HTTP request");
                _logger.LogInformation(context.Request.Path);
                var headersAsStrings = context.Request.Headers
                    .Select(x => $"{x.Key}: {x.Value}");
                _logger.LogInformation(string.Join(Environment.NewLine, headersAsStrings));
                _logger.LogInformation("<---- End of request");
            }
        }
    }
}