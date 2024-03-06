namespace PartPoint.Services.Interfaces;

public interface IAuthService
{
    bool IsUserAuthenticated();
    Task SignIn(string authState, string userId);
    Task SignOut(string authState, string userId);
}
