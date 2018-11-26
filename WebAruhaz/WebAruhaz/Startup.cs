using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAruhaz.Startup))]
namespace WebAruhaz
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
