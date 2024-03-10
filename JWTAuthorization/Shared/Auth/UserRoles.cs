namespace JWTAuthorization.Shared.Auth
{
    //This will not work for enums larger than 32.
    [Flags]
    public enum UserRoles
    {
        Regular = 1 << 0,
        Premium = 1 << 1,
        Admin = 1 << 2
    }
}
