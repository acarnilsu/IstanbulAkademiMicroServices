using AkademiECommerce.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademiECommerce.Services.Discount.Services
{
    public class DiscountService : IDiscountService
    {

        public async Task<ResponseDto<NoContent>> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResponseDto<List<Models.Discount>>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResponseDto<Models.Discount>> GetByCodeUser(string code, string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResponseDto<Models.Discount>> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResponseDto<NoContent>> Insert(Models.Discount discount)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResponseDto<NoContent>> Update(Models.Discount discount)
        {
            throw new System.NotImplementedException();
        }
    }
}
