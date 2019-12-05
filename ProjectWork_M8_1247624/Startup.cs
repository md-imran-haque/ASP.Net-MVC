using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectWork_M8_1247624.Startup))]
namespace ProjectWork_M8_1247624
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
