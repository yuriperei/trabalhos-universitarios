using System;
using System.Collections.Generic;

namespace MustDo.Domain.Interfaces.Repositories
{
	public interface IRepositoryBase<T> where T : class
	{
		IEnumerable<T> ObterTodos();

		T ObterPorId(int? id);

		void Adicionar(T entity);

		void Alterar(T entity);

		void Remover(T entity);

		void Remover(int? id);

        void ObterIdUsuario(string id);
	}
}
