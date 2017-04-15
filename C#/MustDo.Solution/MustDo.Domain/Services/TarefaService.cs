using MustDo.Domain.Entities;
using MustDo.Domain.Interfaces.Repositories;
using MustDo.Domain.Interfaces.Services;

namespace MustDo.Domain.Services
{
	public class TarefaService : ServiceBase<Tarefa>, ITarefaService
	{
		private readonly ITarefaRepository _tarefaRepository;
		public TarefaService(ITarefaRepository tarefaRepository) : base(tarefaRepository)
		{
			_tarefaRepository = tarefaRepository;
		}

		void ITarefaService.FinalizarTarefasAtrasadas()
		{
			_tarefaRepository.FinalizarTarefasAtrasadas();
		}
	}
}
