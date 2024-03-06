namespace PartPoint.Views.Auth;

public partial class SignInPage : ContentPage
{
	public SignInPage(IAuthService authService)
	{
		InitializeComponent();

        _authService = authService;

        BindingContext = new SignInViewModel();
	}

    private readonly IAuthService _authService;

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        await _authService.IsUserAuthenticated();
    }
}