using AutoMapper;
using bookStore.Books;
using bookStore.Category;
using bookStore.Model;

namespace bookStore.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Book, BookDTO>();
        CreateMap<BookDTO, Book>();
        CreateMap<Category.Category, CategoryDTO>();
        CreateMap<CategoryDTO, Category.Category>();
    }
}