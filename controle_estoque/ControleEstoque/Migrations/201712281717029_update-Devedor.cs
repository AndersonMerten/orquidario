namespace ControleEstoque.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDevedor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devedors", "Contato", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devedors", "Contato");
        }
    }
}
