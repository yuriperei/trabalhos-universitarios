namespace MustDo.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0002 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Tarefas", new[] { "Categoria_CategoriaId" });
            DropColumn("dbo.Tarefas", "CategoriaId");
            RenameColumn(table: "dbo.Tarefas", name: "Categoria_CategoriaId", newName: "CategoriaId");
            AlterColumn("dbo.Tarefas", "CategoriaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tarefas", "CategoriaId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Tarefas", new[] { "CategoriaId" });
            AlterColumn("dbo.Tarefas", "CategoriaId", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.Tarefas", name: "CategoriaId", newName: "Categoria_CategoriaId");
            AddColumn("dbo.Tarefas", "CategoriaId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Tarefas", "Categoria_CategoriaId");
        }
    }
}
