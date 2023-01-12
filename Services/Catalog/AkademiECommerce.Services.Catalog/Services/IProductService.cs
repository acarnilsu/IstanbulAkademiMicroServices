using AkademiECommerce.Services.Catalog.Dtos;
using AkademiECommerce.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademiECommerce.Services.Catalog.Services
{
    public interface IProductService
    {
        Task<ResponseDto<List<ProductDto>>> GetAllAsync();
        Task<ResponseDto<ProductDto>> CreateAsync(ProductCreateDto productCreateDto);
        Task<ResponseDto<ProductDto>> GetByIdAsync(string id);
        Task<ResponseDto<ProductDto>> DeleteAsync(string id);
        Task<ResponseDto<ProductDto>> UpdateAsync(ProductCreateDto productCreateDto);
    }
}
