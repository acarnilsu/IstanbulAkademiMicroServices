using AkademiECommerce.Services.Catalog.Dtos;
using AkademiECommerce.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademiECommerce.Services.Catalog.Services
{
    public interface ICategoryService
    {
        Task<ResponseDto<List<CategoryDto>>> GetAllAsync();
        Task<ResponseDto<CategoryDto>> CreateAsync(CategoryDto categoryDto);
        Task<ResponseDto<CategoryDto>> GetByIdAsync(string id);
        Task<ResponseDto<CategoryDto>> DeleteAsync(string id);
        Task<ResponseDto<CategoryDto>> UpdateAsync(string id);
    }
}
