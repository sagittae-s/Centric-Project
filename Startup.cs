using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Centric_Project.Startup))]
namespace Centric_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
