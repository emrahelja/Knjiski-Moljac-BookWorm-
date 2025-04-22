using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnjiskiMoljac.Models;
using KnjiskiMoljac.Services;

namespace KnjiskiMoljac.ViewModels;

public partial class BooksListingViewModel : ObservableObject
{
  private readonly IBookService _bookService;

  public ObservableCollection<Book> Books { get; set; } = new();

  public BooksListingViewModel(IBookService bookService)
  {
    _bookService = bookService;
  }

  [RelayCommand]
  public async Task GetBooks()
  {
    Books.Clear();

    try
    {
      var books = await _bookService.GetBooks();
      foreach (var book in books)
        Books.Add(book);
    }
    catch (Exception ex)
    {
      await Shell.Current.DisplayAlert("Greška", ex.Message, "OK");
    }
  }

  [RelayCommand]
  private async Task AddBook() => await Shell.Current.GoToAsync("AddOrUpdateBookPage");

  [RelayCommand]
  private async Task UpdateBook(Book book) => await Shell.Current.GoToAsync("AddOrUpdateBookPage", new Dictionary<string, object>
  {
    {"BookObject", book}
  });

  [RelayCommand]
  private async Task DeleteBook(Book book)
  {
    var result = await Shell.Current.DisplayAlert("Brisanje", $"Da li si zaista siguran da želiš izbrisati {book.Title}?", "Da", "Ne");

    if (result is true)
    {
      await _bookService.DeleteBook(book.Id);
      await GetBooks();
    }
  }
}
