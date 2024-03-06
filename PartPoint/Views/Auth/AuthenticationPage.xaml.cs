namespace PartPoint.Views.Auth;

public partial class AuthenticationPage : ContentPage
{
	public AuthenticationPage(IAuthService authService)
	{
		InitializeComponent();

        _authService = authService;

        //activityBorder.BackgroundColor = Color.FromRgba(0, 0, 0, 160);

        BindingContext = new AuthenticationViewModel(authService);
    }

    private readonly IAuthService _authService;

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        Task.Run(_authService.IsUserAuthenticated).Wait();
    }
}