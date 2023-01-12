using AkademiECommerce.Services.Catalog.Dtos;
using AkademiECommerce.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademiECommerce.Services.Catalog.Services
{
    public class CategoryService : ICategoryService
    {
        public Task<ResponseDto<CategoryDto>> CreateAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseDto<CategoryDto>> DeleteAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseDto<List<CategoryDto>>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseDto<CategoryDto>> GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseDto<CategoryDto>> UpdateAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
