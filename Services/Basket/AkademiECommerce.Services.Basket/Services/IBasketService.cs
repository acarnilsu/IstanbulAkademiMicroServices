using AkademiECommerce.Services.Basket.Dtos;
using AkademiECommerce.Shared.Dtos;
using System.Threading.Tasks;

namespace AkademiECommerce.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<ResponseDto<BasketDto>> GetBasket(string Userid);
        Task<ResponseDto<bool>> SaveOrUpdate(BasketDto basket);
        Task<ResponseDto<bool>> Delete(string Userid);
    }
}
