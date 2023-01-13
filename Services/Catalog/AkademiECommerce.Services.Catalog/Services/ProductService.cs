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
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public ProductService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<ResponseDto<ProductDto>> CreateAsync(ProductCreateDto productCreateDto)
        {
            var product = _mapper.Map<Product>(productCreateDto);
            await _productCollection.InsertOneAsync(product);
            return ResponseDto<ProductDto>.Success(_mapper.Map<ProductDto>(product), 200);
        }

        public async Task<ResponseDto<NoContent>> DeleteAsync(string id)
        {
            var result = await _productCollection.DeleteOneAsync(x => x.Id == id);
            if (result.DeletedCount > 0)
            {
                return ResponseDto<NoContent>.Success(204);
            }
            else
            {
                return ResponseDto<NoContent>.Fail("Ürün Bulunamadı", 404);
            }
        }

        public async Task<ResponseDto<List<ProductDto>>> GetAllAsync()
        {
            var products = await _productCollection.Find(product => true).ToListAsync();
            return ResponseDto<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(products), 200);
        }

        public async Task<ResponseDto<ProductDto>> GetByIdAsync(string id)
        {
            var product = await _productCollection.Find<Product>(x => x.Id == id).FirstOrDefaultAsync();
            if (product == null)
            {
                return ResponseDto<ProductDto>.Fail("Ürün bulunamadı", 404);
            }
            else
            {
                return ResponseDto<ProductDto>.Success(_mapper.Map<ProductDto>(product), 200);
            }
        }

        public async Task<ResponseDto<NoContent>> UpdateAsync(ProductUpdateDto productUpdateDto)
        {
            var updatedProduct = _mapper.Map<Product>(productUpdateDto);
            var result = await _productCollection.FindOneAndReplaceAsync(x => x.Id == productUpdateDto.Id, updatedProduct);
            if (result == null)
            {
                return ResponseDto<NoContent>.Fail("Ürün Bulunamadı", 404);
            }
            else
            {
                return ResponseDto<NoContent>.Success(204);
            }
        }
    }
}
