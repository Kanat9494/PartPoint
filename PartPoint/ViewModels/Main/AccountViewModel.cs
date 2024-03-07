namespace PartPoint.ViewModels.Main;

public class AccountViewModel : BaseViewModel
{
    public AccountViewModel(IAuthService authService)
    {
        _authService = authService;
        SignOutCommand = new AsyncRelayCommand(OnSignOut);
    }

    private readonly IAuthService _authService;

    public ICommand SignOutCommand { get; set; }

    private async Task OnSignOut()
    {
        await _authService.SignOut("0");
        await Shell.Current.GoToAsync($"{nameof(AuthenticationPage)}");
    }
}
