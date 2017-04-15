using MustDo.Domain.Entities;
using System.Collections.Generic;

namespace MustDo.Domain.Interfaces.Services
{
	public interface ITarefaService : IServiceBase<Tarefa>
	{
		void FinalizarTarefasAtrasadas();
        IEnumerable<Tarefa> ObterTarefasPorCategoria(int id);
        //IEnumerable<Tarefa> ObterTarefasPorTag(int id);
    }
}
