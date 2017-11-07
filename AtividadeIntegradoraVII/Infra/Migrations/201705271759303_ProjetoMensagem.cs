namespace Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjetoMensagem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mensagem", "PorjetoId", c => c.Int(nullable: false));
            AddColumn("dbo.Mensagem", "Projeto_ProjetoId", c => c.Int());
            CreateIndex("dbo.Mensagem", "Projeto_ProjetoId");
            AddForeignKey("dbo.Mensagem", "Projeto_ProjetoId", "dbo.Projeto", "ProjetoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mensagem", "Projeto_ProjetoId", "dbo.Projeto");
            DropIndex("dbo.Mensagem", new[] { "Projeto_ProjetoId" });
            DropColumn("dbo.Mensagem", "Projeto_ProjetoId");
            DropColumn("dbo.Mensagem", "PorjetoId");
        }
    }
}
