using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BikeStoreWebApp.Startup))]
namespace BikeStoreWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
