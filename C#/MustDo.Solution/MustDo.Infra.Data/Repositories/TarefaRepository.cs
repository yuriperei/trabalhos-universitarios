using MustDo.Domain.Entities;
using MustDo.Domain.ENUM;
using MustDo.Domain.Interfaces.Repositories;
using MustDo.Infra.Data.Contexts;
using System;
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

		public void FinalizarTarefasAtrasadas()
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

        public override void Remover(int? id)
        {
            var entity = ObterPorId(id);
            if (entity.Tags.Any())
                Remover(entity);
        }
    }
}
