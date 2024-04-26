namespace NardSmena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMigration_New : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Spropers", "KoefDV", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Spropers", "KoefDV");
        }
    }
}
