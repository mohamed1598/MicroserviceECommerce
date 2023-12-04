using AutoMapper;
using Basket.API.Entities;
using EventBusRabbitMQ.Events;

namespace Basket.API.Helpers
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<BasketCheckout, BasketCheckoutEvent>();
        }
    }
}
