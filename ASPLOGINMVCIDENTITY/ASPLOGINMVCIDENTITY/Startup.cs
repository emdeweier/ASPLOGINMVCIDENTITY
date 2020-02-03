using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPLOGINMVCIDENTITY.Startup))]
namespace ASPLOGINMVCIDENTITY
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
