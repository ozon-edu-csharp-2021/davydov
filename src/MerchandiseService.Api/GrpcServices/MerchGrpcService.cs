using System.Threading.Tasks;
using Grpc.Core;
using MerchandiseService.Api.Services.Interfaces;
using MerchandiseService.Grpc;

namespace MerchandiseService.Api.GrpcServices
{
    /// <summary>
    ///     Мерч GRPC сервис
    /// </summary>
    public class MerchGrpcService : MerchandiseServiceGrpc.MerchandiseServiceGrpcBase
    {
        /// <inheritdoc />
        public MerchGrpcService(IMerchService merchService)
        {
            _merchService = merchService;
        }

        private readonly IMerchService _merchService;

        /// <summary>
        ///     Запросить мерч
        /// </summary>
        public override async Task<IssueMerchByIdResponse> IssueMerchById(
            IssueMerchByIdRequest request,
            ServerCallContext context)
        {
            var merchItem = await _merchService.IssueMerch(request.MerchItemId, context.CancellationToken);
            return new IssueMerchByIdResponse();
        }

        /// <summary>
        ///     Получить информацию о выдаче мерча
        /// </summary>
        public override async Task<MerchDistributionInfoResponse> MerchDistributionInfo(
            MerchDistributionInfoRequest request,
            ServerCallContext context)
        {
            var info = await _merchService.GetMerchDistributionInfo(request.MerchItemId, context.CancellationToken);
            return new MerchDistributionInfoResponse();
        }
    }
}