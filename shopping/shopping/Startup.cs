using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(shopping.Startup))]
namespace shopping
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
