namespace Pagar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Pagaris", "Aadress");
            DropColumn("dbo.Pagaris", "PaneTeele");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pagaris", "PaneTeele", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pagaris", "Aadress", c => c.String());
        }
    }
}
