using System;

namespace MustDo.Domain.Entities
{
	public class Categoria
	{
		public Guid CategoriaId { get; set; } = Guid.NewGuid();
		public string Nome { get; set; }
	}
}