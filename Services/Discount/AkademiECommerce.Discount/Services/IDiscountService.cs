using AkademiECommerce.Discount.Dtos;

namespace AkademiECommerce.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetResultCouponsAsync();
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task DeleteCouponAsync(int id);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task<ResultCouponDto> GetCouponById(int id);
    }
}
