﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MustDo.Domain.Interfaces.Repositories;
using MustDo.Domain.Interfaces.Services;
using MustDo.Domain.Services;
using MustDo.Infra.CrossCutting.SecurityIdentity.Configurations;
using MustDo.Infra.CrossCutting.SecurityIdentity.Contexts;
using MustDo.Infra.CrossCutting.SecurityIdentity.Models;
using MustDo.Infra.Data.Contexts;
using MustDo.Infra.Data.Repositories;
using SimpleInjector;

namespace MustDo.Infra.CrossCutting.IoC
{
	public class StartupIoC
	{
		public static void RegisterIoC(Container container)
		{
			// Domain
			container.Register<ICategoriaService, CategoriaService>(Lifestyle.Scoped);
			container.Register<ITarefaService, TarefaService>(Lifestyle.Scoped);
			container.Register<ITagService, TagService>(Lifestyle.Scoped);
			//container.Register(typeof(IServiceBase<>), typeof(ServiceBase<>), Lifestyle.Scoped);


			// Infra.Data -> Repositories
			container.Register<ICategoriaRepository, CategoriaRepository>(Lifestyle.Scoped);
			container.Register<ITarefaRepository, TarefaRepository>(Lifestyle.Scoped);
			container.Register<ITagRepository, TagRepository>(Lifestyle.Scoped);
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            //container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>), Lifestyle.Scoped);

			container.Register<MustDo4EntitiesDb, MustDo4EntitiesDb>(Lifestyle.Scoped);      
        }
	}
}
