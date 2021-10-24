namespace MerchandiseService.Api.Models
{
    /// <summary>
    ///     Модель единицы мерча
    /// </summary>
    public class MerchItem
    {
        /// <summary>
        ///     Создание модели
        /// </summary>
        public MerchItem(long id)
        {
            Id = id;
        }
        
        /// <summary>
        ///     Ид
        /// </summary>
        public long Id { get; }
    }
}