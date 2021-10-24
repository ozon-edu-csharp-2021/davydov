using System;
using MerchandiseService.Api.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace MerchandiseService.Api.Infrastructure.StartupFilters
{
    /// <summary>
    ///     Добавление терминальных middleware
    /// </summary>
    public class TerminalStartupFilter : IStartupFilter
    {
        /// <summary>
        ///     Регистрация middleware
        /// </summary>
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UseWhen(context => context.Request.Path.Value?.StartsWith("/v") ?? true, appBuilder =>
                {
                    appBuilder.UseMiddleware<RequestLoggingMiddleware>();
                    appBuilder.UseMiddleware<ResponseLoggingMiddleware>();
                });
                app.Map("/version", builder => builder.UseMiddleware<VersionMiddleware>());
                app.Map("/ready", builder => builder.UseMiddleware<ReadyMiddleware>());
                app.Map("/live", builder => builder.UseMiddleware<LiveMiddleware>());
                next(app);
            };
        }
    }
}