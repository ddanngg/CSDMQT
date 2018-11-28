using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuyetTienWeb.Startup))]
namespace QuyetTienWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
