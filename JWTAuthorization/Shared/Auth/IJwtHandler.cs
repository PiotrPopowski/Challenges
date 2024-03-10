namespace JWTAuthorization.Shared.Auth
{
    public interface IJwtHandler
    {
        string GenerateToken(string username, string role);
    }
}
