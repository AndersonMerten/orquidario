namespace ControleEstoque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatevendas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vendas", "Data", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vendas", "Data", c => c.String(nullable: false));
        }
    }
}
