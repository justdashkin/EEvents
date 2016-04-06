using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UsingEF.Startup))]
namespace UsingEF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
