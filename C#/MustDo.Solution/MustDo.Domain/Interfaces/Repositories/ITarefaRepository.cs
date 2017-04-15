using MustDo.Domain.Entities;
using System.Collections;
using System.Collections.Generic;

namespace MustDo.Domain.Interfaces.Repositories
{
	public interface ITarefaRepository : IRepositoryBase<Tarefa>
	{
		void FinalizarTarefasAtrasadas();
        IEnumerable<Tarefa> ObterTarefasPorCategoria(int id);
        //IEnumerable<Tarefa> ObterTarefasPorTag(int id);
	}
}
