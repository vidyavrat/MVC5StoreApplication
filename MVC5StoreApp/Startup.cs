using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5StoreApp.Startup))]
namespace MVC5StoreApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
