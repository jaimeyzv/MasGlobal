using MasGlobal.Business;
using MasGlobal.Business.Interfaces;
using MasGlobal.DataAccess;
using MasGlobal.DataAccess.Interfaces;
using MasGlobal.Insfrastucture;
using MasGlobal.Insfrastucture.Interfaces;
using Unity;

namespace MasGlobal.Injector
{
    public class BootStrapper
    {
        public IUnityContainer RegisterComponents()
        {
            var container = new UnityContainer();
            RegisterInsfrastructure(container);
            RegisterRepositories(container);
            RegisterBusiness(container);

            return container;
        }

        private void RegisterInsfrastructure(UnityContainer container)
        {
            container.RegisterType<IMapper, Mapper>();
        }

        private void RegisterRepositories(UnityContainer container)
        {
            container.RegisterType<IEmployeesRepository, EmployeesRepository>();
        }

        private void RegisterBusiness(UnityContainer container)
        {
            container.RegisterType<IEmployeeBusiness, EmployeeBusiness>();
        }
    }
}
