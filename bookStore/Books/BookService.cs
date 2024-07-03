using AutoMapper;
using bookStore.Context;
using bookStore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bookStore.Books;

public class BookService : IBookService
{
    private readonly MyDbContext _dbContext;
    private readonly IMapper _mapper;

    public BookService(MyDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }


    public async Task<IEnumerable<BookDTO>> GetBooks()
    {
        var books = await _dbContext.Books.ToListAsync();
        return _mapper.Map<IEnumerable<BookDTO>>(books);
    }

    public async Task<BookDTO> AddBook(BookDTO book)
    {
        var modelBook = _mapper.Map<Book>(book);
        await _dbContext.Books.AddAsync(modelBook);
        await _dbContext.SaveChangesAsync();
        return book;
    }

    public async Task<BookDTO> UpdateBook(BookDTO bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        _dbContext.Books.Update(book);
        await _dbContext.SaveChangesAsync();
        return bookDto;
    }

    public async Task DeleteBook(int id)
    {
        var book = await _dbContext.Books.FindAsync(id);
        if (book != null) _dbContext.Books.Remove(book);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<BookDTO?> GetBookById(int id)
    {
        var book = await _dbContext.Books.FindAsync(id);
        return _mapper.Map<BookDTO>(book);
    }

   
}