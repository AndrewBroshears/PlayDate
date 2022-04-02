using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlayDate.WebMVC.Startup))]
namespace PlayDate.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
