using AkademiECommerce.Services.Basket.Dtos;
using AkademiECommerce.Shared.Dtos;
using System.Threading.Tasks;

namespace AkademiECommerce.Services.Basket.Services
{
    public class BasketService : IBasketService
    {
        public Task<ResponseDto<bool>> Delete(string Userid)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseDto<BasketDto>> GetBasket(string Userid)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseDto<bool>> SaveOrUpdate(BasketDto basket)
        {
            throw new System.NotImplementedException();
        }
    }
}
