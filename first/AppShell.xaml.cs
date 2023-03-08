namespace first;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(Views.ProfileView), typeof(Views.ProfileView));
		Routing.RegisterRoute(nameof(Views.ProfileEdit), typeof(Views.ProfileEdit));
    }
}
