using HDdecisions.Domain.Concrete.EntityFramework;
using StructureMap.Configuration.DSL;
using StructureMap.Web;
using System.Data.Entity;

namespace HDdecisions.StructureMapRegistries
{
    public class DomainRegistry : Registry
    {
        public DomainRegistry()
        {
            For<DbContext>().HybridHttpOrThreadLocalScoped().Use<DataContext>();
        }
    }
}
