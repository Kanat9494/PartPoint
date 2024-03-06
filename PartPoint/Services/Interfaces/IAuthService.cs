namespace PartPoint.Services.Interfaces;

public interface IAuthService
{
    Task IsUserAuthenticated();
    Task SignIn(string authState, string userId);
    Task SignOut(string authState);
}
