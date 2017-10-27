using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cinema.Startup))]
namespace Cinema
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
