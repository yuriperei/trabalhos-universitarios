using MustDo.Domain.Entities;
using MustDo.Domain.Interfaces.Repositories;
using MustDo.Domain.Interfaces.Services;
using System.Collections.Generic;

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

        IEnumerable<Tarefa> ITarefaService.ObterTarefasPorCategoria(int id)
        {
           return _tarefaRepository.ObterTarefasPorCategoria(id);
        }

        //IEnumerable<Tarefa> ITarefaService.ObterTarefasPorTag(int id)
        //{
        //    return _tarefaRepository.ObterTarefasPorTag(id);
        //}

    }
}
