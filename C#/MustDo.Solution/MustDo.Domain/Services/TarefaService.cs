using MustDo.Domain.Entities;
using MustDo.Domain.Interfaces.Repositories;
using MustDo.Domain.Interfaces.Services;

namespace MustDo.Domain.Services
{
	public class TarefaService : ServiceBase<Tarefa>, ITarefaService
	{
		public TarefaService(ITarefaRepository tarefaRepository) : base(tarefaRepository)
		{

		}
	}
}
