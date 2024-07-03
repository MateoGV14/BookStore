using bookStore.Model;

namespace bookStore.Books;

public interface IBookService
{
    public Task<IEnumerable<BookDTO>> GetBooks();

    public Task<BookDTO> AddBook(BookDTO book);
    
    public Task<BookDTO> UpdateBook(BookDTO book);

    public Task DeleteBook(int id);

    public Task<BookDTO?> GetBookById(int id);

   
}