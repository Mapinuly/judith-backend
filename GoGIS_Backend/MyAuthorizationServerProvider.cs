using GoGIS_Services.AuthService;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GoGIS_Backend
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private IAuthService _authService = new AuthService();

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (_authService == null)
            {
                context.SetError("invalid_grant", "Authentication service is not configured.");
                return;
            }

            var user = _authService.Login(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "Provided username and password are incorrect");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.name));
            identity.AddClaim(new Claim("Email", user.email));

            context.Validated(identity);
        }
    }
}