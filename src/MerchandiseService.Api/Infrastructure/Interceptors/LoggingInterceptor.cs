using System.Text.Json;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.Logging;

namespace MerchandiseService.Api.Infrastructure.Interceptors
{
    /// <summary>
    ///     Интерцептор для логирования unary запросов и ответов
    /// </summary>
    public class LoggingInterceptor : Interceptor
    {
        /// <inheritdoc />
        public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
        {
            _logger = logger;
        }

        private readonly ILogger<LoggingInterceptor> _logger;

        /// <inheritdoc />
        public override Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            var requestJson = JsonSerializer.Serialize(request);
            _logger.LogInformation(requestJson);
            
            var response = base.UnaryServerHandler(request, context, continuation);
            
            var responseJson = JsonSerializer.Serialize(response);
            _logger.LogInformation(responseJson);
            
            return response;
        }
    }
}