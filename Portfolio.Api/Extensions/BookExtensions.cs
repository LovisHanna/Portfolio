using Portfolio.Api.DTOs;

namespace Portfolio.Api.Extensions;


public static class BookExtensions
{
    public static BookDto ToDto(this Book book)
    {
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            ISBN = book.ISBN,
            Publisher = book.Publisher,
            IsAvailable = book.IsAvailable,
            Genre = book.Genre
        };
    }

    public static Book FromDto(this BookDto bookDto)
    {
        return new Book
        {
            Id = bookDto.Id,
            Title = bookDto.Title,
            Author = bookDto.Author,
            ISBN = bookDto.ISBN,
            Publisher = bookDto.Publisher,
            IsAvailable = bookDto.IsAvailable,
            Genre = bookDto.Genre
        };
    }
}
