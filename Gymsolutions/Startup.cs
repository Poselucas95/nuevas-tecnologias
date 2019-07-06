using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GymSolutions.Startup))]
namespace GymSolutions
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
