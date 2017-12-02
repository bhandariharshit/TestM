using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestM.Startup))]
namespace TestM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
