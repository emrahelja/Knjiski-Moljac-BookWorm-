using KnjiskiMoljac.Data;
using KnjiskiMoljac.Models;

namespace KnjiskiMoljac.Services;

public class BookService : IBookService
{
    private readonly BookStore _bookStore;

    public BookService(BookStore bookStore)
    {
        _bookStore = bookStore;
    }

    public Task CreateBook(Book book)
    {
        Task task = new(() =>
        {
            book.Id = _bookStore.Books.Count + 1;
            _bookStore.Books.Add(book);
        });
        task.Start();

        return task;
    }

    public Task DeleteBook(int id)
    {
        Task task = new(() =>
        {
            var book = _bookStore.Books.SingleOrDefault(b => b.Id == id);
            if (book is not null)
                _bookStore.Books.Remove(book);
        });

        task.Start();
        return task;
    }

    public Task<List<Book>> GetBooks()
    {
        return Task.FromResult(_bookStore.Books);
    }

    public Task UpdateBook(Book book)
    {
        Task task = new(() =>
        {
            var currentBook = _bookStore.Books.SingleOrDefault(b => b.Id == book.Id);
            if (currentBook is null)
                return;

            currentBook.Title = book.Title;
            currentBook.Author = book.Author;
            currentBook.ImageUrl = book.ImageUrl;
            currentBook.IsFinished = book.IsFinished;
        });

        task.Start();
        return task;
    }
}
