using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversityAdmissionApplicationProcessingSystem.Startup))]
namespace UniversityAdmissionApplicationProcessingSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
