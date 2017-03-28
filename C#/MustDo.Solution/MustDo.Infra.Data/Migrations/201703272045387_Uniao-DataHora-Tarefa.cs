namespace MustDo.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniaoDataHoraTarefa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tarefa", "DataHora", c => c.DateTime(nullable: false));
            DropColumn("dbo.Tarefa", "Data");
            DropColumn("dbo.Tarefa", "Hora");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tarefa", "Hora", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tarefa", "Data", c => c.DateTime(nullable: false));
            DropColumn("dbo.Tarefa", "DataHora");
        }
    }
}
