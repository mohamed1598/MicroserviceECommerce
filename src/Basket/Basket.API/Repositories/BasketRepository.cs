using Basket.API.Data.Interfaces;
using Basket.API.Entities;
using Basket.API.Repositories.Interfaces;
using Newtonsoft.Json;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IBasketContext _context;
        public BasketRepository(IBasketContext context)
        {
            _context = context?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<bool> DeleteBasket(string userName)
        {
            return await _context.Redis.KeyDeleteAsync(userName);
        }

        public async Task<BasketCart?> GetBasket(string userName)
        {
            var basket = await _context.Redis.StringGetAsync(userName);
            if (basket.IsNullOrEmpty)
                return null;
            return JsonConvert.DeserializeObject<BasketCart>(basket!);
        }

        public async Task<BasketCart?> UpdateBasket(BasketCart cart)
        {
            var updated = await _context.Redis.StringSetAsync(cart.UserName, JsonConvert.SerializeObject(cart));
            if (!updated)
                return null;
            return await GetBasket(cart.UserName);
        }
    }
}
