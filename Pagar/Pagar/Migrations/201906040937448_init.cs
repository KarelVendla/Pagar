namespace Pagar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pagaris", "Ühik", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pagaris", "Ühik");
        }
    }
}
