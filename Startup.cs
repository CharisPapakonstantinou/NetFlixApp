using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NetflixApp.Startup))]
namespace NetflixApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
