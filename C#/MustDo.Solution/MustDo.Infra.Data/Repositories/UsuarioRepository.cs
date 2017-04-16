using System;
using System.Collections.Generic;
using System.Linq;
using MustDo.Infra.Data.Contexts;
using MustDo.Domain.Interfaces.Repositories;
using MustDo.Domain.Entities;

namespace MustDo.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        private readonly MustDo4EntitiesDb _db;

        public UsuarioRepository(MustDo4EntitiesDb db) : base(db)
		{
            _db = db;
        }

        public void DesativarLock(string id)
        {
            _db.Usuarios.Find(id).LockoutEnabled = false;
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
            GC.SuppressFinalize(this);
        }

        public Usuario ObterPorId(string id)
        {
            return _db.Usuarios.Find(id);
        }
    }
}