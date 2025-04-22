using KnjiskiMoljac.ViewModels;

namespace KnjiskiMoljac.Views;

public partial class BooksListingPage : ContentPage
{
  public BooksListingPage(BooksListingViewModel booksListingViewModel)
  {
    InitializeComponent();
    BindingContext = booksListingViewModel;
  }
}
