using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PharmacySystem.Startup))]
namespace PharmacySystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
