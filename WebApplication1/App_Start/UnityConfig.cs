using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WebApplication1.Repository;

namespace WebApplication1
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
                       
            container.RegisterType<IWebRepository, WebRepository>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}