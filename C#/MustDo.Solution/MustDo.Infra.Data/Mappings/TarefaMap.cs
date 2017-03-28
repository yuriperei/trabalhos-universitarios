using MustDo.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MustDo.Infra.Data.Mappings
{
	public class TarefaMap : EntityTypeConfiguration<Tarefa>
	{
		public TarefaMap()
		{
			ToTable("Tarefas");

			HasKey(p => p.TarefaId);

			Property(p => p.Nome).IsRequired().HasMaxLength(50);
			Property(p => p.Descricao).IsOptional().HasMaxLength(250);
		}
	}
}
