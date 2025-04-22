using KnjiskiMoljac.ViewModels;

namespace KnjiskiMoljac.Views;

public partial class AddOrUpdateBookPage : ContentPage
{
  public AddOrUpdateBookPage(AddOrUpdateBookViewModel bookViewModel)
  {
    InitializeComponent();
    BindingContext = bookViewModel;
  }
}