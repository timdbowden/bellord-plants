using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BellordPlants.mvc.Startup))]
namespace BellordPlants.mvc
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
