namespace PartPoint.ViewModels.Auth;

public class AuthenticationViewModel : BaseViewModel
{
    public AuthenticationViewModel(IAuthService authService)
    {
        SignInCommand = new AsyncRelayCommand(OnSignIn);
        _authService = authService;
        AuthTabs = new ObservableCollection<string>
        {
            "Вход",
            "Регистрация",
        };
    }

    private readonly IAuthService _authService;

    public ObservableCollection<string> AuthTabs { get; set; }

    public ICommand SignInCommand { get; }

    private ulong? _userId;
    public ulong? UserId
    {
        get => _userId;
        set => SetProperty(ref _userId, value);
    }
    private string _userName;
    public string UserName
    {
        get => _userName;
        set => SetProperty(ref _userName, value);
    }
    public string _password;
    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    private async Task OnSignIn()
    {
        IsBusy = true;
        await Task.Delay(2000);

        if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
        {
            IsBusy = false;
            return;
        }

        var isSignedIn = await _authService.SignIn(UserName, Password);
        if (isSignedIn)
        {
            IsBusy = false;


            await Shell.Current.GoToAsync("//AccountPage");
        }
    }
}
