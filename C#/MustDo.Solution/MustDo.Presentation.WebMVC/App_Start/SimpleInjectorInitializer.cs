using MustDo.Infra.CrossCutting.IoC;
using MustDo.Presentation.WebMVC.App_Start;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;
using WebActivatorEx;

[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitializer), "Initialize")]
namespace MustDo.Presentation.WebMVC.App_Start
{
	public static class SimpleInjectorInitializer
	{
		public static void Initialize()
		{
			var container = new Container();

			container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

			// Chamada dos módulos do Simple Injector 

			InitializeContainer(container);

			container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

			container.Verify();

			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
		}

		private static void InitializeContainer(Container container)
		{
			StartupIoC.RegisterIoC(container);
		}
	}
}