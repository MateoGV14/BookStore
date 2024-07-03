using AutoMapper;
using bookStore.Context;
using Microsoft.EntityFrameworkCore;

namespace bookStore.Category;

public class CategoryService : ICategoryService
{
    
    private readonly MyDbContext _dbContext;
    private readonly IMapper _mapper;

    public CategoryService(MyDbContext dbContext, IMapper mapper)
    {
      
        _dbContext = dbContext;
        _mapper = mapper;
    }


    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var categories = await _dbContext.Categories.ToListAsync();
        return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
    }

    public async Task<CategoryDTO> AddCategory(CategoryDTO categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync();
        return categoryDto;
    }

    public async Task<CategoryDTO> UpdateCategory(CategoryDTO categoryDto)
    {
        return categoryDto;
    }

    public async Task DeleteCategory(int id)
    {
        var category = await _dbContext.Categories.FindAsync(id);
         _dbContext.Remove(category);
         await _dbContext.SaveChangesAsync();
    }

    public async Task<CategoryDTO?> GetCategoryById(int id)
    {
        var category =  await _dbContext.Categories.FindAsync(id);
        return _mapper.Map<CategoryDTO>(category);

    }
}