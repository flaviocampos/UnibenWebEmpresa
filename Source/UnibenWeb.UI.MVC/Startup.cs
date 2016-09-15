using Microsoft.Owin;
using Owin;
using UnibenWeb.UI.MVC;

[assembly: OwinStartup(typeof(Startup))]
namespace UnibenWeb.UI.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
