using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_My_Gmail_Contacts.Startup))]
namespace MVC_My_Gmail_Contacts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
