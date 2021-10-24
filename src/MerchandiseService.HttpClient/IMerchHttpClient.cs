using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.HttpModels.RequestModels;
using MerchandiseService.HttpModels.ResponseModels;

namespace MerchandiseService.HttpClient
{
    /// <summary>
    ///     Мерч HTTP клиент
    /// </summary>
    public interface IMerchHttpClient
    {
        /// <summary>
        ///     Запросить мерч
        /// </summary>
        Task<IssueMerchResponseModel> V1IssueById(IssueMerchRequestModel request, CancellationToken token);

        /// <summary>
        ///     Получить информацию о выдаче мерча
        /// </summary>
        Task<MerchDistributionInfoResponseModel> V1GetDistributionInfoById(MerchDistributionInfoRequestModel request,
            CancellationToken token);
    }
}