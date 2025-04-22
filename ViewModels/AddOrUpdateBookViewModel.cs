using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KnjiskiMoljac.Models;
using KnjiskiMoljac.Services;

namespace KnjiskiMoljac.ViewModels;

[QueryProperty(nameof(CurrentBook), "BookObject")]
public partial class AddOrUpdateBookViewModel : ObservableObject
{
  private readonly IBookService _bookService;

  [ObservableProperty]
  private Book _currentBook;

  [ObservableProperty]
  [NotifyCanExecuteChangedFor(nameof(SaveBookCommand))]
  private string _bookTitle;

  [ObservableProperty]
  [NotifyCanExecuteChangedFor(nameof(SaveBookCommand))]
  private string _bookAuthor;

  [ObservableProperty]
  private string _bookImageUrl;

  [ObservableProperty]
  private bool _bookIsFinished;

  [ObservableProperty]
  private bool _titleIsNotValid;

  [ObservableProperty]
  private bool _authorIsNotValid;

  public AddOrUpdateBookViewModel(IBookService bookService)
  {
    _bookService = bookService;
  }

  [RelayCommand(CanExecute = nameof(CanSaveBook))]
  private async Task SaveBook()
  {
    Book book = new()
    {
      Title = BookTitle,
      Author = BookAuthor,
      ImageUrl = BookImageUrl,
      IsFinished = BookIsFinished
    };

    if (CurrentBook is null)
    {
      await _bookService.CreateBook(book);
    }
    else
    {
      book.Id = CurrentBook.Id;
      await _bookService.UpdateBook(book);
    }

    await Shell.Current.GoToAsync("..");
  }

  partial void OnCurrentBookChanged(Book book)
  {
    BookAuthor = book.Author;
    BookTitle = book.Title;
    BookImageUrl = book.ImageUrl;
    BookIsFinished = book.IsFinished;
  }

  private bool CanSaveBook()
  {
    return !string.IsNullOrEmpty(BookTitle) && !string.IsNullOrEmpty(BookAuthor);
  }
}
