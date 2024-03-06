namespace PartPoint.Services.Implementations;

public class AuthService : IAuthService
{
    public async Task IsUserAuthenticated()
    {
        var isUserAuthenticated = await SecureStorage.Default.GetAsync("authState") ?? "0";


        if (isUserAuthenticated.Equals("1"))
            await Shell.Current.GoToAsync("//MainPage");
    }

    public async Task SignIn(string authState, string userId)
    {
        await SecureStorage.Default.SetAsync("authState", authState);
        await SecureStorage.Default.SetAsync("userId", userId);

        await Shell.Current.GoToAsync("//MainPage");
    }

    public async Task SignOut(string authState)
    {
        await SecureStorage.Default.SetAsync("authState", authState);

        await Shell.Current.GoToAsync("//SignInPage");
    }
}
