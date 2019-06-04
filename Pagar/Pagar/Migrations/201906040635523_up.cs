namespace Pagar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pagaris", "Valmis", c => c.Int(nullable: false));
            AddColumn("dbo.Pagaris", "PaneTeele", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pagaris", "PaneTeele");
            DropColumn("dbo.Pagaris", "Valmis");
        }
    }
}
