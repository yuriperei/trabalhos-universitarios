using MustDo.Infra.CrossCutting.IoC;
using MustDo.Service.WebApi.App_Start;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebActivatorEx;

[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]
namespace MustDo.Service.WebApi.App_Start
{
	public static class SimpleInjectorInitializer
	{
		public static void Initialize()
		{
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

		private static void InitializeContainer(Container container)
		{
			StartupIoC.RegisterIoC(container);
		}
	}
}