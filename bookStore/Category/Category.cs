using System.ComponentModel.DataAnnotations;

namespace bookStore.Category;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    
    [Required]
    public string Title { get; set; }

}