using MasGlobal.Injector;
using System.Web.Mvc;
using Unity.Mvc5;

namespace MasGlobal.Mvc
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new BootStrapper();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container.RegisterComponents()));
        }
    }
}