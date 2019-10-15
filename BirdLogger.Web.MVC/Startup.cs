using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BirdLogger.Web.MVC.Startup))]
namespace BirdLogger.Web.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
