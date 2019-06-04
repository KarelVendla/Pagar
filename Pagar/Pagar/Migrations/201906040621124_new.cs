namespace Pagar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pagaris",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Kogus = c.Int(nullable: false),
                        Toode = c.Int(nullable: false),
                        Tähtaeg = c.DateTime(nullable: false),
                        Lisa = c.String(),
                        TuleJärgi = c.Boolean(nullable: false),
                        Aadress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pagaris");
        }
    }
}
