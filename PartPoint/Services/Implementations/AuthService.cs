using Org.Apache.Http.Authentication;

namespace PartPoint.Services.Implementations;

public class AuthService : IAuthService
{
    public string UserId { get; set; } = "0";
    public bool HasUserAuthenticated { get; set; } = false;
    public bool IsUserAuthenticated()
    {
        var isUserAuthenticated = "0";

        Task.Run(async () =>
        {
            isUserAuthenticated = await SecureStorage.Default.GetAsync("authState") ?? "0";
        }).Wait();


        if (isUserAuthenticated.Equals("1"))
        {
            HasUserAuthenticated = true;
            Task.Run(async () =>
            {
                UserId = await SecureStorage.Default.GetAsync("userId") ?? "0";
            }).Wait();

            return true;
        }

        return false;
    }

    public async Task<bool> SignIn(string userName, string password)
    {
        if (userName == "test" && password == "123")
        {
            await SecureStorage.Default.SetAsync("userName", userName);
            await SecureStorage.Default.SetAsync("userId", "2");
            await SecureStorage.Default.SetAsync("authState", "1");
            this.UserId = "2";
            HasUserAuthenticated = true;
            return true;
        }

        return false;
    }

    public async Task SignOut(string authState)
    {
        await SecureStorage.Default.SetAsync("authState", authState);
        HasUserAuthenticated = false;
        UserId = "0";
    }
}
