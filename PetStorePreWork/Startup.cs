using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetStorePreWork.Startup))]
namespace PetStorePreWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
