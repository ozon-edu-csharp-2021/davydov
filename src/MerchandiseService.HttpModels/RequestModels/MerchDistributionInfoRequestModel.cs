using System.Diagnostics.CodeAnalysis;

namespace MerchandiseService.HttpModels.RequestModels
{
    /// <summary>
    ///     Модель запроса информации о выдаче мерча
    /// </summary>
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class MerchDistributionInfoRequestModel
    {
        /// <summary>
        ///     Ид мерча
        /// </summary>
        public long MerchItemId { get; set; }
    }
}