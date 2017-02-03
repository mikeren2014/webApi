using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Owin.Security;

namespace SportsStore.Infrastructure.Identity
{
    public class StoreAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            StoreUserManager storeUsermgr = context.OwinContext.Get<StoreUserManager>("AspNet.Identity.Owin:" + typeof(StoreUserManager).AssemblyQualifiedName);
            StoreUser user = await storeUsermgr.FindAsync(context.UserName, context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant", "The username or password is incorrect");
            }
            else
            {
                ClaimsIdentity ident = await storeUsermgr.CreateIdentityAsync(user, "Custom");
                AuthenticationTicket ticket = new AuthenticationTicket(ident, new AuthenticationProperties());
                context.Validated(ticket);
                context.Request.Context.Authentication.SignIn(ident);
            }
            //return base.GrantResourceOwnerCredentials(context);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

    }
}