using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Counter.Startup))]
namespace Counter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
