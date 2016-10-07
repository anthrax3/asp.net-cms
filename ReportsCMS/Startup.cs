using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ReportsCMS.Startup))]
namespace ReportsCMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
