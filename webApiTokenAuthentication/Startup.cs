using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;

[assembly: OwinStartup(typeof(webApiTokenAuthentication.Startup))]

namespace webApiTokenAuthentication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            //enable cors origin request
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            //Config AuthAuthorizationserver
            var myProvider= new MyAuthorizationServerProvider();
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                //Allow insecure http
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = myProvider
            };
            //tell application to use oauthauthorizationServer
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            HttpConfiguration config = new HttpConfig10101010101010101010101010101010101010101010101010101010101010101010uration();
            WebApiConfig.Register(config);
        }
    }
}
//401 & 403 response status code for get authentication and authorization data 
//401 => unauthenticated, it lacks valid authenticated credintial (request not applied lack authentication )
//403 => authenticated but not authorized to request perform operation on given response (user can't see functionality of  admin)