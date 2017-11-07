namespace Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrigindoGrafia : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Mensagem", "Projeto_ProjetoId", "dbo.Projeto");
            DropIndex("dbo.Mensagem", new[] { "Projeto_ProjetoId" });
            RenameColumn(table: "dbo.Mensagem", name: "Projeto_ProjetoId", newName: "ProjetoId");
            AlterColumn("dbo.Mensagem", "ProjetoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Mensagem", "ProjetoId");
            AddForeignKey("dbo.Mensagem", "ProjetoId", "dbo.Projeto", "ProjetoId", cascadeDelete: true);
            DropColumn("dbo.Mensagem", "PorjetoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mensagem", "PorjetoId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Mensagem", "ProjetoId", "dbo.Projeto");
            DropIndex("dbo.Mensagem", new[] { "ProjetoId" });
            AlterColumn("dbo.Mensagem", "ProjetoId", c => c.Int());
            RenameColumn(table: "dbo.Mensagem", name: "ProjetoId", newName: "Projeto_ProjetoId");
            CreateIndex("dbo.Mensagem", "Projeto_ProjetoId");
            AddForeignKey("dbo.Mensagem", "Projeto_ProjetoId", "dbo.Projeto", "ProjetoId");
        }
    }
}
