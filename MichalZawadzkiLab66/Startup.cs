using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MichalZawadzkiLab66.Startup))]
namespace MichalZawadzkiLab66
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
