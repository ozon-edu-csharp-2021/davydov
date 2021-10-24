using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MerchandiseService.Api.Infrastructure.Middlewares
{
    /// <summary>
    ///     Middleware логирования ответов на входящие HTTP запросы
    /// </summary>
    public class ResponseLoggingMiddleware
    {
        /// <summary>
        ///     Создание объекта
        /// </summary>
        public ResponseLoggingMiddleware(RequestDelegate next, ILogger<ResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        private readonly RequestDelegate _next;
        private readonly ILogger<ResponseLoggingMiddleware> _logger;

        /// <summary>
        ///     Вызов middleware
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
            LogResponseInfo(context);
        }

        private void LogResponseInfo(HttpContext context)
        {
            using (_logger.BeginScope($"{DateTime.Now} response"))
            {
                _logger.LogInformation("----> HTTP response");
                _logger.LogInformation(context.Request.Path);
                var headersAsStrings = context.Response.Headers
                    .Select(x => $"{x.Key}: {x.Value}");
                _logger.LogInformation(string.Join(Environment.NewLine, headersAsStrings));
                _logger.LogInformation("<---- End of response");
            }
        }
    }
}