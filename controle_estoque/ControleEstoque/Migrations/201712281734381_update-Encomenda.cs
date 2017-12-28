namespace ControleEstoque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateEncomenda : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Encomendas", "Valor", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Encomendas", "Valor");
        }
    }
}
