namespace NardSmena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Spropers", "KodOperation", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Spropers", "KodOperation");
        }
    }
}
