using Microsoft.AspNetCore.Mvc;

namespace bookStore.Category;


[Route("api/[controller]")]
[ApiController]
public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
    {

        var categories = await _categoryService.GetCategories();
        return Ok(categories);

    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id)
    {

        var category = await _categoryService.GetCategoryById(id);
        if (category== null)
        {
            return NotFound();
        }

        return Ok(category);

    }

    [HttpPost]
    public async Task<ActionResult<CategoryDTO>> AddBook(CategoryDTO categoryDto)
    {
        var addedCategory = await _categoryService.AddCategory(categoryDto);
        return CreatedAtAction(nameof(GetCategoryById), new { id = addedCategory.id }, addedCategory);
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteById(int id)
    {
        await _categoryService.DeleteCategory(id);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CategoryDTO>> UpdateBook(CategoryDTO categoryDto)
    {
        await _categoryService.UpdateCategory(categoryDto);
        return Ok(categoryDto);
    }


}