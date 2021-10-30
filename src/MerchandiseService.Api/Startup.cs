using MerchandiseService.Api.GrpcServices;
using MerchandiseService.Api.Services;
using MerchandiseService.Api.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MerchandiseService.Api
{
    /// <summary>
    ///     Startup сервиса
    /// </summary>
    public class Startup
    {
        /// <summary>
        ///     Создание Startup
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }
        
        /// <summary>
        ///     Автоматически вызывает Asp.Net Core
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMerchService, MerchService>();
        }

        /// <summary>
        ///     Вызывается в рантайме
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<MerchGrpcService>();
                endpoints.MapControllers();
            });
        }
    }
}