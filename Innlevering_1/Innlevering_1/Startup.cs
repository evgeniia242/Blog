using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Innlevering_1.Startup))]
namespace Innlevering_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
