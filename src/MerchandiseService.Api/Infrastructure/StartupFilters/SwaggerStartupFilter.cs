using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace MerchandiseService.Api.Infrastructure.StartupFilters
{
    /// <summary>
    ///     Middleware компонент настройки Swagger
    /// </summary>
    public class SwaggerStartupFilter : IStartupFilter
    {
        /// <inheritdoc />
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MerchandiseService.Api v1"));
                next(app);
            };
        }
    }
}