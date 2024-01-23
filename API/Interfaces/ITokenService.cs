namespace API.Interfaces
{
    public interface ITokenService
    {
        string createToken(AppUser user);
    }
}
