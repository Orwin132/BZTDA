namespace NardSmena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSprDet : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BRab_Korr", "Tabel_ExtNom", "dbo.Tabels");
            DropIndex("dbo.BRab_Korr", new[] { "Tabel_ExtNom" });
            RenameColumn(table: "dbo.BRab_Korr", name: "Tabel_ExtNom", newName: "ExtNom");
            AddColumn("dbo.Kernas", "NameOperation", c => c.String());
            AddColumn("dbo.UchDets", "NameDetal", c => c.String());
            AlterColumn("dbo.SprDets", "Selected", c => c.Boolean(nullable: false));
            AlterColumn("dbo.BRab_Korr", "ExtNom", c => c.Int(nullable: false));
            CreateIndex("dbo.BRab_Korr", "ExtNom");
            AddForeignKey("dbo.BRab_Korr", "ExtNom", "dbo.Tabels", "ExtNom", cascadeDelete: true);
            DropColumn("dbo.UchDets", "NameDeta");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UchDets", "NameDeta", c => c.String());
            DropForeignKey("dbo.BRab_Korr", "ExtNom", "dbo.Tabels");
            DropIndex("dbo.BRab_Korr", new[] { "ExtNom" });
            AlterColumn("dbo.BRab_Korr", "ExtNom", c => c.Int());
            AlterColumn("dbo.SprDets", "Selected", c => c.Byte(nullable: false));
            DropColumn("dbo.UchDets", "NameDetal");
            DropColumn("dbo.Kernas", "NameOperation");
            RenameColumn(table: "dbo.BRab_Korr", name: "ExtNom", newName: "Tabel_ExtNom");
            CreateIndex("dbo.BRab_Korr", "Tabel_ExtNom");
            AddForeignKey("dbo.BRab_Korr", "Tabel_ExtNom", "dbo.Tabels", "ExtNom");
        }
    }
}
