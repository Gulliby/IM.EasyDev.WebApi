using Microsoft.Owin;
using Owin;
using System.Web.Http;
using IM.EasyDev.Web.Rest.Extensions;

[assembly: OwinStartup(typeof(IM.EasyDev.Web.Rest.Startup))]

namespace IM.EasyDev.Web.Rest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            config.ConfigWith(WebApiConfig.Register);
            ConfigureAuth(app);
            app.UseWebApi(config);    
        }
    }
}
