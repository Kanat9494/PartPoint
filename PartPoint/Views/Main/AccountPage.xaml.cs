namespace PartPoint.Views.Main;

public partial class AccountPage : ContentPage
{
	public AccountPage(IAuthService authService)
	{
		InitializeComponent();

		_authService = authService;

        BindingContext = new AccountViewModel(authService);
	}

    private readonly IAuthService _authService;

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        //Task.Run(_authService.IsUserAuthenticated).Wait();
        if (_authService.HasUserAuthenticated)
        {

        }
        else
        {
            await Shell.Current.GoToAsync($"{nameof(AuthenticationPage)}");
        }
    }
}