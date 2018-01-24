using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FacebookTestingApp.Startup))]
namespace FacebookTestingApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
