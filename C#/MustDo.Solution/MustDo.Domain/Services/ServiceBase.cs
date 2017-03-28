using MustDo.Domain.Interfaces.Repositories;
using MustDo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace MustDo.Domain.Services
{
	public class ServiceBase<T> : IServiceBase<T> where T : class
	{
		private readonly IRepositoryBase<T> _repositoryBase;

		public ServiceBase(IRepositoryBase<T> repositoryBase)
		{
			_repositoryBase = repositoryBase;
		}

		public void Adicionar(T entity)
		{
			_repositoryBase.Adicionar(entity);
		}

		public void Alterar(T entity)
		{
			_repositoryBase.Alterar(entity);
		}

		public T ObterPorId(Guid? id)
		{
			return _repositoryBase.ObterPorId(id);
		}

		public IEnumerable<T> ObterTodos()
		{
			return _repositoryBase.ObterTodos();
		}

		public void Remover(Guid? id)
		{
			_repositoryBase.Remover(id);
		}

		public void Remover(T entity)
		{
			_repositoryBase.Remover(entity);
		}
	}
}
