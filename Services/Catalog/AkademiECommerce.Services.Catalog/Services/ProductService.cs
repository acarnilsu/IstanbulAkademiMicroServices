using AkademiECommerce.Services.Catalog.Dtos;
using AkademiECommerce.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademiECommerce.Services.Catalog.Services
{
    public class ProductService : IProductService
    {
        public Task<ResponseDto<ProductDto>> CreateAsync(ProductCreateDto productCreateDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseDto<ProductDto>> DeleteAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseDto<List<ProductDto>>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseDto<ProductDto>> GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseDto<ProductDto>> UpdateAsync(ProductCreateDto productCreateDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
