using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MarketPlaces.Startup))]
namespace MarketPlaces
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
