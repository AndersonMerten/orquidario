namespace ControleEstoque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orquidarioinitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devedors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cliente = c.String(nullable: false),
                        ValorDevido = c.Single(nullable: false),
                        Observacoes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Encomendas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Produto = c.String(nullable: false),
                        Cliente = c.String(nullable: false),
                        Contato = c.String(nullable: false),
                        Foto = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valor = c.Single(nullable: false),
                        Data = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vendas");
            DropTable("dbo.Encomendas");
            DropTable("dbo.Devedors");
        }
    }
}
