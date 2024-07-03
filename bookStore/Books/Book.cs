using System.ComponentModel.DataAnnotations;

namespace bookStore.Books;

public class Book
{
    [Key]
    public int BookId { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    
    [Required]
    public int Quantity { get; set; }
    
    public decimal Price { get; set; }
    
    [Required]
    public string Author { get; set; }
    
    
}