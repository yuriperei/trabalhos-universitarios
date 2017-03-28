using MustDo.Domain.Entities;
using MustDo.Domain.Interfaces.Repositories;
using MustDo.Infra.Data.Contexts;

namespace MustDo.Infra.Data.Repositories
{
	public class ComentarioRepository : RepositoryBase<Comentario>, IComentarioRepository
	{
		public ComentarioRepository(MustDo4EntitiesDb db) : base(db)
		{

		}
	}
}
