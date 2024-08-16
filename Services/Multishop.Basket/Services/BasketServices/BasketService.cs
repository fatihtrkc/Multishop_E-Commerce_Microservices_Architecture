﻿using Multishop.Basket.Dtos.BasketDtos;
using Multishop.Basket.Services.RedisServices;
using System.Text.Json;

namespace Multishop.Basket.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly IRedisService redisService;
        public BasketService(IRedisService redisService)
        {
            this.redisService = redisService;
        }

        public async Task<bool> DeleteAsync(string userId)
        {
            return await redisService.GetDatabase().KeyDeleteAsync(userId);
        }

        public async Task<bool> SaveChangesAsync(BasketDto basketDto)
        {
            return await redisService.GetDatabase().StringSetAsync(basketDto.UserId, JsonSerializer.Serialize(basketDto));
        }

        public async Task<BasketDto> GetByAsync(string userId)
        {
            var basket = await redisService.GetDatabase().StringGetAsync(userId);
            return JsonSerializer.Deserialize<BasketDto>(basket);
        }
    }
}