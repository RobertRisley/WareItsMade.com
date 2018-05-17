using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WareItsMade.com.Startup))]
namespace WareItsMade.com
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
