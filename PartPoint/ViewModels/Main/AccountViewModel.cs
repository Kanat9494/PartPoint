namespace PartPoint.ViewModels.Main;

public class AccountViewModel : BaseViewModel
{
    public AccountViewModel(IAuthService authService)
    {
        _authService = authService;
    }

    private readonly IAuthService _authService;
}
