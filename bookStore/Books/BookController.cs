

using bookStore.Model;
using Microsoft.AspNetCore.Mvc;


namespace bookStore.Books;

[Route("api/[controller]")]
[ApiController]
public class BooksController : Controller
{
    private readonly IBookService _bookService;
   
    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
       
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
    {

        var books = await _bookService.GetBooks();
        return Ok(books);

    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<BookDTO>> GetBookById(int id)
    {

        var book = await _bookService.GetBookById(id);
        if (book== null)
        {
            return NotFound();
        }

        return Ok(book);

    }

    [HttpPost]
    public async Task<ActionResult<BookDTO>> AddBook(BookDTO book)
    {
        var addedBook = await _bookService.AddBook(book);
        return CreatedAtAction(nameof(GetBookById), new { id = addedBook.BookId }, addedBook);
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteById(int id)
    {
        await _bookService.DeleteBook(id);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BookDTO>> UpdateBook(BookDTO bookDto)
    {
        await _bookService.UpdateBook(bookDto);
        return Ok(bookDto);
    }
    
    
    
    

 
    
   
}