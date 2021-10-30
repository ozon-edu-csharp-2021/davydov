using System;
using System.IO;
using System.Reflection;
using MerchandiseService.Api.Infrastructure.Filters;
using MerchandiseService.Api.Infrastructure.Interceptors;
using MerchandiseService.Api.Infrastructure.StartupFilters;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace MerchandiseService.Api.Infrastructure.Extensions
{
    /// <summary>
    ///     Расширения для <see cref="IHostBuilder"/>
    /// </summary>
    public static class HostBuilderExtensions
    {
        /// <summary>
        ///     Добавление инфраструктурных сервисов
        /// </summary>
        public static IHostBuilder AddInfrastructure(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
                services.AddGrpc(options => options.Interceptors.Add<LoggingInterceptor>());
                services.AddSingleton<IStartupFilter, TerminalStartupFilter>();
                services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();

                services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo {Title = "MerchandiseService.Api", Version = "v1"});
                    var xmlFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                    var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                    options.IncludeXmlComments(xmlFilePath);
                });
            });
            return builder;
        }
    }
}