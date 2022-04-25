using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreWebAPI_Assignment.Models.Category;
using StoreWebAPI_Assignment.Models.Data;

namespace StoreWebAPI_Assignment.Services
{
    public interface ICategoryService
    {
        public Task<CategoryModel> CreateCategoryAsync(CategoryRequest request);
        public Task<IEnumerable<CategoryModel>> GetCategoriesAsync();
        public Task<CategoryModel> GetCategoryAsync(int id);
        public Task<CategoryModel> UpdateCategoryAsync(int id, CategoryRequest request);
        public Task<bool> DeleteCategoryAsync(int id);
    }

    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CategoryService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoryModel> CreateCategoryAsync(CategoryRequest request)
        {
            if (!await _context.Categories.AnyAsync(x => x.Name == request.Name))
            {
                var categoryEntity = _mapper.Map<CategoryEntity>(request);

                _context.Categories.Add(categoryEntity);
                await _context.SaveChangesAsync();

                return _mapper.Map<CategoryModel>(categoryEntity);
            }

            return null!;
        }

        public async Task<IEnumerable<CategoryModel>> GetCategoriesAsync()
        {
            return _mapper.Map<IEnumerable<CategoryModel>>(await _context.Categories.ToListAsync());
        }

        public async Task<CategoryModel> GetCategoryAsync(int id)
        {
            return _mapper.Map<CategoryModel>(await _context.Categories.FirstOrDefaultAsync(x => x.Id == id));

        }

        public async Task<CategoryModel> UpdateCategoryAsync(int id, CategoryRequest request)
        {
            var categoryEntity = await _context.Categories.FindAsync(id);
            if (categoryEntity != null)
            {
                if (categoryEntity.Name != request.Name && !string.IsNullOrEmpty(request.Name))
                    categoryEntity.Name = request.Name;

                _context.Entry(categoryEntity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return _mapper.Map<CategoryModel>(categoryEntity);
            }

            return null!;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var categoryEntity = await _context.Categories.FindAsync(id);
            if (categoryEntity != null)
            {
                _context.Categories.Remove(categoryEntity);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
