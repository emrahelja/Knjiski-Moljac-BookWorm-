using KnjiskiMoljac.Data;
using KnjiskiMoljac.Services;
using KnjiskiMoljac.ViewModels;
using KnjiskiMoljac.Views;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace KnjiskiMoljac;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<BookStore>();
		builder.Services.AddScoped<IBookService, BookService>();

		builder.Services.AddSingleton<BooksListingViewModel>();
		builder.Services.AddTransient<AddOrUpdateBookViewModel>();

		builder.Services.AddSingleton<BooksListingPage>();
		builder.Services.AddTransient<AddOrUpdateBookPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
