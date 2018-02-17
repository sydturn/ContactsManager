using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MijemApplication.Startup))]
namespace MijemApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
