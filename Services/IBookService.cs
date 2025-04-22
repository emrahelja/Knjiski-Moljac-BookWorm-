using KnjiskiMoljac.Models;

namespace KnjiskiMoljac.Services;

public interface IBookService
{
    Task<List<Book>> GetBooks();
    Task CreateBook(Book book);
    Task UpdateBook(Book book);
    Task DeleteBook(int id);
}
