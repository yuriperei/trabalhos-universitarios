using System;
using System.Collections.Generic;

namespace MustDo.Domain.Entities
{
	public class Tag
	{
		public int TagId { get; set; }
		public string Nome { get; set; }
        public string UsuarioId { get; set; }
        public virtual ICollection<Tarefa> Tarefas { get; set; }
	}
}
