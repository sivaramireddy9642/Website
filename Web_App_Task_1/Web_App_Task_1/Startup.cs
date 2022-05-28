using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_App_Task_1.Startup))]
namespace Web_App_Task_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
