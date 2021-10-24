using System.Diagnostics.CodeAnalysis;

namespace MerchandiseService.HttpModels.RequestModels
{
    /// <summary>
    ///     Модель запроса для выдачи мерча
    /// </summary>
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class IssueMerchRequestModel
    {
        /// <summary>
        ///     Ид мерча
        /// </summary>
        public long MerchItemId { get; set; }
    }
}