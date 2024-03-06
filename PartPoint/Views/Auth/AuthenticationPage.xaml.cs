namespace PartPoint.Views.Auth;

public partial class AuthenticationPage : ContentPage
{
	public AuthenticationPage(IAuthService authService)
	{
		InitializeComponent();

        _authService = authService;

        firstTab.BackgroundColor = Color.FromArgb("#00cc00");
        secondTab.BackgroundColor = Colors.Transparent;
        firstTabTitle.TextColor = Color.FromArgb("#00cc00");
        secondTabTitle.TextColor = Colors.Black;

        BindingContext = new AuthenticationViewModel(authService);
    }

    private readonly IAuthService _authService;

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        Task.Run(_authService.IsUserAuthenticated).Wait();
    }

    void OnPositionChanged(object sender, PositionChangedEventArgs e)
    {
        int currentItemPosition = e.CurrentPosition;

        if (currentItemPosition == 0)
        {
            firstTab.Background = Color.FromArgb("00cc00");
            secondTab.Background = Colors.Transparent;
            firstTabTitle.TextColor = Color.FromArgb("00cc00");
            secondTabTitle.TextColor = Colors.Black;
        }
        else
        {
            firstTab.Background = Colors.Transparent;
            secondTab.Background = Color.FromArgb("00cc00");
            firstTabTitle.TextColor = Colors.Black;
            secondTabTitle.TextColor = Color.FromArgb("00cc00");
        }
    }
}