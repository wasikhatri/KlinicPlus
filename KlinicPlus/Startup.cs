using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KlinicPlus.Startup))]
namespace KlinicPlus
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
