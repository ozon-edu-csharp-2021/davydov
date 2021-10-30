using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Api.Models;
using MerchandiseService.Api.Services.Interfaces;

namespace MerchandiseService.Api.Services
{
    /// <inheritdoc />
    public class MerchService : IMerchService
    {
        /// <inheritdoc />
        public Task<MerchItem?> IssueMerch(long merchItemId, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public Task<MerchDistributionInfo?> GetMerchDistributionInfo(long merchItemId, CancellationToken token)
        {
            throw new System.NotImplementedException();
        }
    }
}