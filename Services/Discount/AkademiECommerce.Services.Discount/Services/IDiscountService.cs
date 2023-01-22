using AkademiECommerce.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademiECommerce.Services.Discount.Services
{
    public interface IDiscountService
    {
        Task<ResponseDto<List<Models.Discount>>> GetAll();
        Task<ResponseDto<Models.Discount>> GetById(int id);
        Task<ResponseDto<NoContent>> Insert(Models.Discount discount);
        Task<ResponseDto<NoContent>> Update(Models.Discount discount);
        Task<ResponseDto<NoContent>> Delete(int id);
        Task<ResponseDto<Models.Discount>> GetByCodeUser(string code, string id);
    }
}
