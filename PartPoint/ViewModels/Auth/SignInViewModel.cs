namespace PartPoint.ViewModels.Auth;

public class SignInViewModel : BaseViewModel
{
    public SignInViewModel(IAuthService authService)
    {
        SignInCommand = new AsyncRelayCommand(OnSignIn);
        _authService = authService;
    }

    private readonly IAuthService _authService;

    public ICommand SignInCommand { get; }

    private ulong? _userId;
    public ulong? UserId
    {
        get => _userId;
        set => SetProperty(ref _userId, value);
    }

    private async Task OnSignIn()
    {
        IsBusy = true;
        await Task.Delay(2000);

        if (UserId == null || UserId == 0)
        {
            IsBusy = false;
            return;
        }

        await _authService.SignIn("1", UserId?.ToString() ?? "0");
        IsBusy = false;
    }
}
