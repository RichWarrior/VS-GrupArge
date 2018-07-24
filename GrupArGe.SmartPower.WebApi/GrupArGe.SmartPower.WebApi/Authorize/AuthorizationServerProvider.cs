using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace GrupArGe.SmartPower.WebApi.Authorize
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(context.Password, "MD5")
            DbInteraction.DbContext dbContext = new DbInteraction.DbContext();
            DbInteraction.Entities.User user = dbContext.SelectQuery<DbInteraction.Entities.User>("select * from user where email = @email and password = @password",new { email = context.UserName, password = context.Password }).FirstOrDefault();
           
            if (user !=null)
            {                
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("UserID", user.Id.ToString()));
                identity.AddClaim(new Claim("Password", user.Password));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Kullanıcı adınız veya şifreniz yanlış");
                return;
            }
        }
    }
}
