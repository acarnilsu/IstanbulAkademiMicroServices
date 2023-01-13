using AkademiECommerce.Services.Catalog.Dtos;
using AkademiECommerce.Services.Catalog.Models;
using AkademiECommerce.Services.Catalog.Settings;
using AkademiECommerce.Shared.Dtos;
using AutoMapper;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademiECommerce.Services.Catalog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);

            _mapper = mapper;
        }

        public async Task<ResponseDto<CategoryDto>> CreateAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryCollection.InsertOneAsync(category);
            return ResponseDto<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }

        public Task<ResponseDto<CategoryDto>> DeleteAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResponseDto<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(category => true).ToListAsync();
            return ResponseDto<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);
        }

        public async Task<ResponseDto<CategoryDto>> GetByIdAsync(string id)
        {
            var category = await _categoryCollection.Find<Category>(x => x.Id == id).FirstOrDefaultAsync();
            if (category == null)
            {
                return ResponseDto<CategoryDto>.Fail("Kategori Bulunamadı", 404);
            }
            else
            {
                return ResponseDto<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
            }
        }

        public Task<ResponseDto<CategoryDto>> UpdateAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
