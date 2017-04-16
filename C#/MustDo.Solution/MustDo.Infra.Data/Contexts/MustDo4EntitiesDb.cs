using MustDo.Domain.Entities;
using MustDo.Infra.Data.Mappings;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MustDo.Infra.Data.Contexts
{
	public class MustDo4EntitiesDb : DbContext
	{
        public MustDo4EntitiesDb() : base("MustDo4EntitiesDb")
        {

        }
		public DbSet<Categoria> Categorias { get; set; }
		public DbSet<Tarefa> Tarefas { get; set; }
		public DbSet<Tag> Tags { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // General Custom Context Properties
            //modelBuilder.Properties()
            //    .Configure(p => p.HasDatabaseGeneratedOption
            //    (DatabaseGeneratedOption.None));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));


            AddConfigMap(modelBuilder);
        }

        private void AddConfigMap(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoriaMap());
            modelBuilder.Configurations.Add(new TarefaMap());
            modelBuilder.Configurations.Add(new TagMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
        }

    }
}
