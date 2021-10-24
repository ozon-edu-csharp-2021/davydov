using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MerchandiseService.Api.Infrastructure.Middlewares
{
    /// <summary>
    ///     Middleware для возврата состояния приложения
    /// </summary>
    public class ReadyMiddleware
    {
        /// <summary>
        ///     Создание объекта
        /// </summary>
        public ReadyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        private readonly RequestDelegate _next;

        /// <summary>
        ///     Вызов middleware
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.StatusCode = 200;
            await context.Response.WriteAsync("200 Ok");
        }
    }
}