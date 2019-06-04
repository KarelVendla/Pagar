namespace Pagar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tobool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pagaris", "Valmis", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Pagaris", "PaneTeele", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pagaris", "PaneTeele", c => c.Int(nullable: false));
            AlterColumn("dbo.Pagaris", "Valmis", c => c.Int(nullable: false));
        }
    }
}
