using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreWebAPI_Assignment.Models.Category;
using StoreWebAPI_Assignment.Models.Data;
using StoreWebAPI_Assignment.Models.Product;

namespace StoreWebAPI_Assignment.Services
{
    public interface IProductService
    {
        public Task<ProductModel> CreateProductAsync(ProductRequest request);
        public Task<IEnumerable<ProductModel>> GetProductsAsync();
        public Task<ProductModel> GetProductAsync(int articleNumber);
        public Task<ProductModel> UpdateProductAsync(int articleNr, ProductRequest request);
        public Task<bool> DeleteProductAsync(int articleNumber);
    }

    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductModel> CreateProductAsync(ProductRequest request)
        {
            if (!await _context.Products.AnyAsync(x => x.Name == request.Name))
            {
                var productEntity = _mapper.Map<ProductEntity>(request);

                var categoryEntity = await _context.Categories.FirstOrDefaultAsync(x => x.Name == request.CategoryName);
                if (categoryEntity == null)
                {
                    productEntity.Category = new CategoryEntity { Name = request.CategoryName };
                }
                else
                {
                    productEntity.CategoryId = categoryEntity.Id;
                }

                _context.Products.Add(productEntity);
                await _context.SaveChangesAsync();

                return _mapper.Map<ProductModel>(productEntity);
            }

            return null!;
        }

        public async Task<IEnumerable<ProductModel>> GetProductsAsync()
        {
            return _mapper.Map<IEnumerable<ProductModel>>(await _context.Products.Include(x => x.Category).ToListAsync());
        }

        public async Task<ProductModel> GetProductAsync(int articleNumber)
        {
            return _mapper.Map<ProductModel>(await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.ArticleNr == articleNumber));
        }

        public async Task<ProductModel> UpdateProductAsync(int articleNumber, ProductRequest request)
        {
            var productEntity = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.ArticleNr == articleNumber);
            if (productEntity != null)
            {
                if (productEntity.Name != request.Name && !string.IsNullOrEmpty(request.Name))
                    productEntity.Name = request.Name;

                if (productEntity.Description != request.Description && !string.IsNullOrEmpty(request.Description))
                    productEntity.Description = request.Description;

                if (productEntity.Price != request.Price && request.Price != 0)
                    productEntity.Price = request.Price;

                if (productEntity.Category.Name != request.CategoryName && !string.IsNullOrEmpty(request.CategoryName))
                    productEntity.Category.Name = request.CategoryName;

                _context.Entry(productEntity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return _mapper.Map<ProductModel>(productEntity);
            }

            return null!;
        }

        public async Task<bool> DeleteProductAsync(int articleNr)
        {
            var productEntity = await _context.Products.FindAsync(articleNr);
            if (productEntity != null)
            {
                _context.Products.Remove(productEntity);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
