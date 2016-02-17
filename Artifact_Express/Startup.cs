using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Artifact_Express.Startup))]
namespace Artifact_Express
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
