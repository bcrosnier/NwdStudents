using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nwd.Web.Startup))]
namespace Nwd.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
