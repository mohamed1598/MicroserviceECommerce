using Basket.API.Entities;

namespace Basket.API.Repositories.Interfaces
{
    public interface IBasketRepository
    {
        Task<BasketCart?> GetBasket(string userName);
        Task<BasketCart?> UpdateBasket(BasketCart cart);
        Task<bool> DeleteBasket(string userName);
    }
}
