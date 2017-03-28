using System;
using System.Collections.Generic;

namespace MustDo.Domain.Entities
{
	public class Tarefa
	{
		public Guid TarefaId { get; set; } = Guid.NewGuid();
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public bool Concluida { get; set; }
		public DateTime DataHora { get; set; }
		public Categoria Categoria { get; set; }
		public IEnumerable<Comentario> Comentarios { get; set; }
	}
}
