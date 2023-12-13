using AutoMapper;
using Discount.GRPC.Entities;
using Discount.GRPC.Protos;

namespace Discount.GRPC.Mapping
{
    public class DiscountProfile:Profile
    {
        public DiscountProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}
