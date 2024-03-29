﻿using GloboTicket.Services.Discount.DbContexts;
using GloboTicket.Services.Discount.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.Services.Discount.Repositories
{
    public class CouponRepository : ICouponRepository
    {
        private readonly DiscountDbContext _discountDbContext;

        public CouponRepository(DiscountDbContext discountDbContext)
        {
            _discountDbContext = discountDbContext;
        }

        public async Task<Coupon> GetCouponByCode(string couponCode)
        {
            var coupon = await _discountDbContext.Coupons.Where(x => x.Code == couponCode).FirstOrDefaultAsync();

            return coupon;
        }

        public async Task UseCoupon(Guid couponId)
        {
            var couponToUpdate =
                await _discountDbContext.Coupons.Where(x => x.CouponId == couponId).FirstOrDefaultAsync();

            if (couponToUpdate == null)
                throw new Exception();//TODO custom exception

            couponToUpdate.AlreadyUsed = true;
            await _discountDbContext.SaveChangesAsync();
        }

        public async Task<Coupon> GetCouponById(Guid couponId)
        {
            return await _discountDbContext.Coupons.Where(x => x.CouponId == couponId).FirstOrDefaultAsync();
        }
    }
}
