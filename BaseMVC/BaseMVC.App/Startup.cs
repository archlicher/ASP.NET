using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BaseMVC.App.Startup))]
namespace BaseMVC.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
