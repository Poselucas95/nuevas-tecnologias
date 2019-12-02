using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RentnGo.Startup))]
namespace RentnGo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
