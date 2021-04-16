using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Avia8r.Startup))]
namespace Avia8r
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
