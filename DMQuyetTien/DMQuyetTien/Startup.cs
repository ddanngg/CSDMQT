using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DMQuyetTien.Startup))]
namespace DMQuyetTien
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
