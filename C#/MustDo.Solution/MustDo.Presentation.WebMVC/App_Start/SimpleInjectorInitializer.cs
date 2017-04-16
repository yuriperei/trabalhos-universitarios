using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MustDo.Infra.CrossCutting.IoC;
using MustDo.Infra.CrossCutting.SecurityIdentity.Configurations;
using MustDo.Infra.CrossCutting.SecurityIdentity.Contexts;
using MustDo.Infra.CrossCutting.SecurityIdentity.Models;
using MustDo.Presentation.WebMVC.App_Start;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web;
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

            // Necessário para registrar o ambiente do Owin que é dependência do Identity
            // Feito fora da camada de IoC para não levar o System.Web para fora
            container.Register(() =>
            {
                if (HttpContext.Current != null && HttpContext.Current.Items["owin.Environment"] == null && container.IsVerifying)
                {
                    return new OwinContext().Authentication;
                }
                return HttpContext.Current.GetOwinContext().Authentication;

            }, Lifestyle.Scoped);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

			container.Verify();

			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
		}

		private static void InitializeContainer(Container container)
		{
			StartupIoC.RegisterIoC(container);

            // Identity
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()), Lifestyle.Scoped);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);
        }
	}
}