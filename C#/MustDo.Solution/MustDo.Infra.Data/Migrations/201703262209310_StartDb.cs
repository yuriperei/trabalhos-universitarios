namespace MustDo.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StartDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Comentario",
                c => new
                    {
                        ComentarioId = c.Guid(nullable: false),
                        Mensagem = c.String(maxLength: 8000, unicode: false),
                        Data = c.DateTime(nullable: false),
                        Hora = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ComentarioId);
            
            CreateTable(
                "dbo.Tarefa",
                c => new
                    {
                        TarefaId = c.Guid(nullable: false),
                        Nome = c.String(maxLength: 8000, unicode: false),
                        Descricao = c.String(maxLength: 8000, unicode: false),
                        Concluida = c.Boolean(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Hora = c.DateTime(nullable: false),
                        Categoria_CategoriaId = c.Guid(),
                    })
                .PrimaryKey(t => t.TarefaId)
                .ForeignKey("dbo.Categorias", t => t.Categoria_CategoriaId)
                .Index(t => t.Categoria_CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarefa", "Categoria_CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Tarefa", new[] { "Categoria_CategoriaId" });
            DropTable("dbo.Tarefa");
            DropTable("dbo.Comentario");
            DropTable("dbo.Categorias");
        }
    }
}
