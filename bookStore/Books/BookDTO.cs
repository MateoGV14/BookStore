using System.ComponentModel.DataAnnotations;

namespace bookStore.Books;

public record BookDTO(int BookId, string Title, [Range(1 , 999)]decimal Price, string Author);
