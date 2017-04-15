using MustDo.Domain.Entities;
using MustDo.Domain.Interfaces.Repositories;
using MustDo.Domain.Interfaces.Services;

namespace MustDo.Domain.Services
{
	public class TagService : ServiceBase<Tag>, ITagService
	{
		public TagService(ITagRepository tagRepository) : base(tagRepository)
		{

		}
	}
}
