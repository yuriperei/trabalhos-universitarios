using MustDo.Domain.Entities;
using MustDo.Domain.Interfaces.Repositories;
using MustDo.Domain.Interfaces.Services;

namespace MustDo.Domain.Services
{
	public class CategoriaService : ServiceBase<Categoria>, ICategoriaService
	{
		//private readonly ICategoriaRepository _categoriaRepository;

		public CategoriaService(ICategoriaRepository categoriaRepository) : base(categoriaRepository)
		{
			//_categoriaRepository = categoriaRepository;
		}


	}
}
