using AkademiECommerce.Services.Basket.Dtos;
using AkademiECommerce.Shared.Dtos;
using System.Text.Json;
using System.Threading.Tasks;

namespace AkademiECommerce.Services.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;



        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }



        public async Task<ResponseDto<bool>> Delete(string Userid)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(Userid);
            return status ? ResponseDto<bool>.Success(204) : ResponseDto<bool>.Fail("Sepet bulunamadı.", 404);
        }



        public async Task<ResponseDto<BasketDto>> GetBasket(string Userid)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(Userid);
            if (string.IsNullOrEmpty(existBasket))
            {
                return ResponseDto<BasketDto>.Fail("Sepet bulunamadı.", 404);
            }
            return ResponseDto<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(existBasket), 200);
        }


        public async Task<ResponseDto<bool>> SaveOrUpdate(BasketDto basket)
        {
            var status = await _redisService.GetDb().StringSetAsync(basket.UserId, JsonSerializer.Serialize(basket));
            return status ? ResponseDto<bool>.Success(204) : ResponseDto<bool>.Fail("Bir hata oluştu.", 500);
        }
    }
}
