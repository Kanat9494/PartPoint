namespace PartPoint.Views.Auth;

public partial class SignInPage : ContentPage
{
	public SignInPage(IAuthService authService)
	{
		InitializeComponent();

        _authService = authService;

        activityBorder.BackgroundColor = Color.FromRgba(0, 0, 0, 160);

        BindingContext = new SignInViewModel(authService);
	}

    private readonly IAuthService _authService;

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        await _authService.IsUserAuthenticated();
    }
}