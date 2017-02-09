using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GAP.Frederik.SuperZapatos.Startup))]
namespace GAP.Frederik.SuperZapatos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
