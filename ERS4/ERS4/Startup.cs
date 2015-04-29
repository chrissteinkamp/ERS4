using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ERS4.Startup))]
namespace ERS4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
