using MustDo.Domain.Entities;
using MustDo.Domain.Interfaces.Repositories;
using MustDo.Infra.Data.Contexts;

namespace MustDo.Infra.Data.Repositories
{
	public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
	{
		//private readonly MustDo4EntitiesDb _db;

		public CategoriaRepository(MustDo4EntitiesDb db) : base(db)
		{
			//_db = db;
		}
	}
}
