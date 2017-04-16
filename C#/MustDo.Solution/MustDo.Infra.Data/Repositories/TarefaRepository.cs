using MustDo.Domain.Entities;
using MustDo.Domain.ENUM;
using MustDo.Domain.Interfaces.Repositories;
using MustDo.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MustDo.Infra.Data.Repositories
{
	public class TarefaRepository : RepositoryBase<Tarefa>, ITarefaRepository
	{

		private readonly MustDo4EntitiesDb _db;

		public TarefaRepository(MustDo4EntitiesDb db) : base(db)
		{
			_db = db;
		}

		void ITarefaRepository.FinalizarTarefasAtrasadas()
		{
			var tarefasAtrasadas = _db.Set<Tarefa>().ToList().Where(
				f => f.Situacao == SituacaoTarefaEnum.Progresso
				&& DateTime.Compare(f.DataFinalizacao, DateTime.Now) <= 0
                && f.UsuarioId == _usuarioId);
			tarefasAtrasadas.ToList().ForEach(f =>
			{
				f.Situacao = SituacaoTarefaEnum.Atrasada;
				_db.Entry(f).State = EntityState.Modified;
			});
			_db.SaveChanges();
		}

        IEnumerable<Tarefa> ITarefaRepository.ObterTarefasPorCategoria(int id)
        {
            var tarefas = (from tarefa in _db.Set<Tarefa>()
             join categoria in _db.Set<Categoria>()
             on tarefa.CategoriaId equals id
             select tarefa).Distinct().ToList();

            return tarefas;
        }

        public override IEnumerable<Tarefa> ObterTodos()
        {
            //Serviço
            if(_usuarioId != null && !_usuarioId.Equals(""))
            {
                return base.ObterTodos().Where(m => m.UsuarioId.Equals(_usuarioId));
            }
            return base.ObterTodos();
        }

        public override void Remover(int? id)
        {
            var entity = ObterPorId(id);
            if (entity.Tags.Any())
                Remover(entity);
        }
    }
}
