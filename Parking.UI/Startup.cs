using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Parking.UI.Startup))]
namespace Parking.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
