namespace PartPoint.Views.Main;

public partial class MainPage : ContentPage
{
	public MainPage(IAuthService authService)
	{
		InitializeComponent();

		BindingContext = new MainViewModel(authService);
	}
}