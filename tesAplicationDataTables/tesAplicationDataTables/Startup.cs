using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(tesAplicationDataTables.Startup))]
namespace tesAplicationDataTables
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
