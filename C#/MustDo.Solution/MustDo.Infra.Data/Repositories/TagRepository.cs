using MustDo.Domain.Entities;
using MustDo.Domain.Interfaces.Repositories;
using MustDo.Infra.Data.Contexts;

namespace MustDo.Infra.Data.Repositories
{
	public class TagRepository : RepositoryBase<Tag>, ITagRepository
	{
		public TagRepository(MustDo4EntitiesDb db) : base(db)
		{

		}
	}
}
