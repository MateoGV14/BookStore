namespace bookStore.Category;

public interface ICategoryService
{
    public Task<IEnumerable<CategoryDTO>> GetCategories();

    public Task<CategoryDTO> AddCategory(CategoryDTO categoryDto);
    
    public Task<CategoryDTO> UpdateCategory(CategoryDTO categoryDto);

    public Task DeleteCategory(int id);

    public Task<CategoryDTO?> GetCategoryById(int id);

  
}
