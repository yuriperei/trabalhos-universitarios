using System;
using System.Collections.Generic;

namespace MustDo.Domain.Entities
{
	public class Categoria
	{
		public int CategoriaId { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public virtual ICollection<Tarefa> Tarefas { get; set; }
	}
}