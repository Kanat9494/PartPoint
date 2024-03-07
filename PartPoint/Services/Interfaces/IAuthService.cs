namespace PartPoint.Services.Interfaces;

public interface IAuthService
{
    public bool HasUserAuthenticated { get; set; }
    public string UserId { get; set; }
    bool IsUserAuthenticated();
    Task<bool> SignIn(string userName, string password);
    Task SignOut(string authState);
}
