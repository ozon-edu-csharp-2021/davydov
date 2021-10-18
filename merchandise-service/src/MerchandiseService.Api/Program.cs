using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MerchandiseService.Api
{
    /// <summary>
    ///     Хост
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///     Точка входа
        /// </summary>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        ///     Создание билдера хоста
        /// </summary>
        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}