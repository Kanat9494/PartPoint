namespace PartPoint.ViewModels.Main;

public class MainViewModel : BaseViewModel
{
    public MainViewModel(IAuthService authService)
    {
        _authService = authService;
        _authService.IsUserAuthenticated();

        Task.Run(InitializeContent);
    }

    private readonly IAuthService _authService;

    private async Task InitializeContent()
    {
        IsBusy = true;
        await Task.Delay(3000);

        IsBusy = false;
    }
}
