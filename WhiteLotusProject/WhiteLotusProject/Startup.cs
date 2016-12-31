using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WhiteLotusProject.Startup))]
namespace WhiteLotusProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
