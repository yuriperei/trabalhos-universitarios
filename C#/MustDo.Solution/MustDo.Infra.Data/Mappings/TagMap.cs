using MustDo.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace MustDo.Infra.Data.Mappings
{
	public class TagMap : EntityTypeConfiguration<Tag>
	{
		public TagMap()
		{
			ToTable("Tags");

			HasKey(p => p.TagId);
			Property(p => p.Nome).IsRequired().HasMaxLength(50);
		}
	}
}
