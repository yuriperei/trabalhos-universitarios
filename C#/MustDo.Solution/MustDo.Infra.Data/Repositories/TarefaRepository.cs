using MustDo.Domain.Entities;
using MustDo.Domain.Interfaces.Repositories;
using MustDo.Infra.Data.Contexts;

namespace MustDo.Infra.Data.Repositories
{
	public class TarefaRepository : RepositoryBase<Tarefa>, ITarefaRepository
	{
		public TarefaRepository(MustDo4EntitiesDb db) : base(db)
		{

		}
	}
}
