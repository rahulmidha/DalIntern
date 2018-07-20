using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DalIntern.Startup))]
namespace DalIntern
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
