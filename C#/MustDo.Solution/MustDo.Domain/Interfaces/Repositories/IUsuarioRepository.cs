using System;
using System.Collections.Generic;
using MustDo.Domain.Entities;

namespace MustDo.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IDisposable
    {
        Usuario ObterPorId(string id);
        IEnumerable<Usuario> ObterTodos();
        void DesativarLock(string id);
    }
}