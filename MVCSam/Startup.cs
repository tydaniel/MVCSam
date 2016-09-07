using Microsoft.Owin;
using MVCSam;
using Owin;

[assembly: OwinStartup(typeof (Startup))]

namespace MVCSam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}