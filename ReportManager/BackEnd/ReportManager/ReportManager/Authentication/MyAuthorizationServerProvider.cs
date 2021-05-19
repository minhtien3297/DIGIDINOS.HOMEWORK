using Microsoft.Owin.Security.OAuth;
using ReportManager.DataAccess;
using ReportManager.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace webApiTokenAuthentication
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            Accounts account = new Accounts();
            AccountsAccessLayer objDB = new AccountsAccessLayer();

            account = objDB.SelectDataToLogin(context.UserName, context.Password);

            if (account != null)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", account.Username));
                identity.AddClaim(new Claim(ClaimTypes.Name, account.FirstName));
                context.Validated(identity);
            }
            else
            {
                context.SetError("Autorization Error", "The username or password is incorrect!");
                context.Response.Headers.Add("AuthorizationResponse", new[] { "Failed" });
            }
        }
    }
}