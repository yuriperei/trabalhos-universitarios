using MustDo.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MustDo.Infra.Data.Mappings
{
	public class ComentarioMap : EntityTypeConfiguration<Comentario>
	{
		public ComentarioMap()
		{
			ToTable("Comentarios");

			HasKey(p => p.ComentarioId);

			Property(p => p.Mensagem).IsRequired().HasMaxLength(250);
			Property(p => p.Data).IsRequired();
			Property(p => p.Hora).IsRequired();
		}
	}
}
