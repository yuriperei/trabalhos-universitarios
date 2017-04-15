using MustDo.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MustDo.Infra.Data.Mappings
{
	public class CategoriaMap : EntityTypeConfiguration<Categoria>
	{
		public CategoriaMap()
		{
			ToTable("Categorias");

			HasKey(p => p.CategoriaId);

			Property(p => p.Nome).IsRequired().HasMaxLength(50);

		}
	}
}
