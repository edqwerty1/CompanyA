using HDdecisions.Services;
using HDdecisions.Services.Implementation;
using StructureMap.Configuration.DSL;
using StructureMap.Web;
namespace HDdecisions.StructureMapRegistries
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            For<IApplicationService>().HybridHttpOrThreadLocalScoped().Use<ApplicationService>();
        }
    }
}
