using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RegisterWebApp.Startup))]
namespace RegisterWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
