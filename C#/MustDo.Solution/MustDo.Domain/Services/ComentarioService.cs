using MustDo.Domain.Entities;
using MustDo.Domain.Interfaces.Repositories;
using MustDo.Domain.Interfaces.Services;

namespace MustDo.Domain.Services
{
	public class ComentarioService : ServiceBase<Comentario>, IComentarioService
	{
		public ComentarioService(IComentarioRepository comentarioRepository) : base(comentarioRepository)
		{

		}
	}
}
