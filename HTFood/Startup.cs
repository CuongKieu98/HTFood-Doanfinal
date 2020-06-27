using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HTFood.Startup))]
namespace HTFood
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
