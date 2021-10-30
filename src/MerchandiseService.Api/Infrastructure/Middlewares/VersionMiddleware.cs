using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MerchandiseService.Api.Infrastructure.Middlewares
{
    /// <summary>
    ///     Middleware для возвращения версии приложения
    /// </summary>
    public class VersionMiddleware
    {
        /// <summary>
        ///     Создание объекта
        /// </summary>
        public VersionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private readonly RequestDelegate _next;

        /// <summary>
        ///     Вызов middleware
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "no version";
            var serviceName = Assembly.GetExecutingAssembly().GetName().Name ?? "no name";
            var responseBody = new Dictionary<string, string>
            {
                {"version", version},
                {"serviceName", serviceName}
            };
            await context.Response.WriteAsJsonAsync(responseBody);
        }
    }
}