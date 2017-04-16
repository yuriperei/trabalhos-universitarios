using MustDo.Domain.Entities;
using MustDo.Domain.Interfaces.Repositories;
using MustDo.Infra.Data.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace MustDo.Infra.Data.Repositories
{
	public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
	{
		private readonly MustDo4EntitiesDb _db;

		public CategoriaRepository(MustDo4EntitiesDb db) : base(db)
		{
			_db = db;
		}

        public override IEnumerable<Categoria> ObterTodos()
        {
            //Serviço
            if (_usuarioId != null && !_usuarioId.Equals(""))
            {
                return base.ObterTodos().Where(m => m.UsuarioId.Equals(_usuarioId));
            }
            return base.ObterTodos();
        }
    }
}
