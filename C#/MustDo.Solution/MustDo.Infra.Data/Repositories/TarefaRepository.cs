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
				&& DateTime.Compare(f.DataFinalizacao, DateTime.Now) <= 0);
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

        //IEnumerable<Tarefa> ITarefaRepository.ObterTarefasPorTag(int id)
        //{
        //    //base.ObterTodos().Where(m => m.Tags.Contains(id).ToList());

        //    var tags = (from tag in _db.Set<Tag>()
        //               where tag.TagId == id
        //                select tag);

        //    (from tarefa in _db.Tarefas
        //     join tag in _db.Tags
        //     on tarefa.Tags.Contains(id)
             
          

        //    return tarefas;
        //}

        public override void Remover(int? id)
        {
            var entity = ObterPorId(id);
            if (entity.Tags.Any())
                Remover(entity);
        }
    }
}
