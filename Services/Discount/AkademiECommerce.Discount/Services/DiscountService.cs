using AkademiECommerce.Discount.Context;
using AkademiECommerce.Discount.Dtos;
using AkademiECommerce.Discount.Models;
using AutoMapper;
using Dapper;

namespace AkademiECommerce.Discount.Services
{
    public class DiscountService:IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code, @rate, @isActive, @validDate)";
            var paramaters = new DynamicParameters();
            paramaters.Add("@code", createCouponDto.Code);
            paramaters.Add("@rate", createCouponDto.Rate);
            paramaters.Add("@isActive", true);
            paramaters.Add("@validDate", DateTime.Now.AddDays(10));
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "Delete from Coupons Where CouponID=@couponID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@couponID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }

        }

        public async Task<ResultCouponDto> GetCouponById(int id)
        {
            string query = "Select * from Coupons where CouponID = @couponID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@couponID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<ResultCouponDto>(query, paramaters);
                return values;
            }
        }

        public async Task<List<ResultCouponDto>> GetResultCouponsAsync()
        {
            string query  = "Select * From Coupons ";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCouponDto>(query);
                return values.ToList();
            }

        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set Code = @code, Rate=@rate, IsActive=@isActive, ValidDate=@validDate where CouponID = @couponID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@code", updateCouponDto.Code);
            paramaters.Add("@rate", updateCouponDto.Rate);
            paramaters.Add("@isActive", updateCouponDto.IsActive);
            paramaters.Add("@validDate", updateCouponDto.ValidDate);
            paramaters.Add("@couponID", updateCouponDto.CouponID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }
    }
}
