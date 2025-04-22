using KnjiskiMoljac.Views;

namespace KnjiskiMoljac;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		RegisterForRoute<AddOrUpdateBookPage>();
	}

	protected static void RegisterForRoute<T>()
	{
		Routing.RegisterRoute(typeof(T).Name, typeof(T));
	}
}
