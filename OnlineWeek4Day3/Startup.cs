using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineWeek4Day3.Startup))]
namespace OnlineWeek4Day3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
