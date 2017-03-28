using System;

namespace MustDo.Domain.Entities
{
	public class Comentario
	{
		public Guid ComentarioId { get; set; } = Guid.NewGuid();
		public string Mensagem { get; set; }
		public DateTime Data { get; set; }
		public DateTime Hora { get; set; }
	}
}