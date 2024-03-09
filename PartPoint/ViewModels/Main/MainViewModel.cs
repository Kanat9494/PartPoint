namespace PartPoint.ViewModels.Main;

public class MainViewModel : BaseViewModel
{
    public MainViewModel(IAuthService authService)
    {
        _authService = authService;
        _authService.IsUserAuthenticated();
    }

    private readonly IAuthService _authService;
}
