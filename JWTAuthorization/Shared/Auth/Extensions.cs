namespace JWTAuthorization.Shared.Auth
{
    public static class Extensions
    {
        public static RouteHandlerBuilder RequireAuthorization(this RouteHandlerBuilder builder, string authenticationScheme, UserRoles roles)
            => builder.RequireAuthorization(
                new AuthorizeData() { 
                    AuthenticationSchemes = authenticationScheme, 
                    Roles = roles.ToString() 
                });
    }
}
