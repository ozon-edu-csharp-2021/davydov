using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Api.Models;


namespace MerchandiseService.Api.Services.Interfaces
{
    /// <summary>
    ///     Сервис выдачи мерча
    /// </summary>
    public interface IMerchService
    {
        /// <summary>
        ///     Запросить мерч
        /// </summary>
        Task<MerchItem?> IssueMerch(long merchItemId, CancellationToken token);

        /// <summary>
        ///     Получить информацию о выдаче мерча
        /// </summary>
        Task<MerchDistributionInfo?> GetMerchDistributionInfo(long merchItemId, CancellationToken token);
    }
}