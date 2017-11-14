using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Security.Claims;

namespace webApiTokenAuthentication
{
     //static data
    //Inherit OAuthAuthorizationService Provider
    public class MyAuthorizationServerProvider: OAuthAuthorizationServerProvider
    {


        //Override method from OAuthAuthorizationServerProvider
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            //Validated the client
            context.Validated();         
        }



        //Validate Credentials of user if valid generate sign token user can authorize access of server
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            if( context.UserName == "admin" && context.Password ==   "admin")
            {
                 //If user n password is admin
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identity.AddClaim(new Claim("username", "admin"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Manisha Pandey"));
                context.Validated(identity);
            }
            else if(context.UserName== "user" && context.Password== "user")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                identity.AddClaim(new Claim("username", "user"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Sapna Pandey"));
                context.Validated(identity);
            }
            else
            {
                //set error if condition is false
                context.SetError("invalid_grant", "Provided name is Incorrect");
                return;
            }
        }
    }
}