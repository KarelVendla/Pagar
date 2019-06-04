using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pagar.Startup))]
namespace Pagar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
