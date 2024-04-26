namespace NardSmena.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            CreateTable(
                "dbo.Bnards",
                c => new
                    {
                        ExtNom = c.Int(nullable: false, identity: true),
                        Moon = c.Short(nullable: false),
                        Selected = c.Byte(nullable: false),
                        NNariada = c.Short(nullable: false),
                        NameNariada = c.String(),
                        SummAll = c.Double(nullable: false),
                        TimeAll = c.Double(nullable: false),
                        KodOpl = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.ExtNom);
            
            CreateTable(
                "dbo.BnardStr_Sproper",
                c => new
                    {
                        BnardStr_SproperID = c.Int(nullable: false, identity: true),
                        BnardStr_NomStr = c.Int(nullable: false),
                        Sproper_NomStr = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BnardStr_SproperID)
                .ForeignKey("dbo.BnardStrs", t => t.BnardStr_NomStr, cascadeDelete: true)
                .ForeignKey("dbo.Spropers", t => t.Sproper_NomStr, cascadeDelete: true)
                .Index(t => t.BnardStr_NomStr)
                .Index(t => t.Sproper_NomStr);
            
            CreateTable(
                "dbo.BnardStrs",
                c => new
                    {
                        NomStr = c.Int(nullable: false, identity: true),
                        KodiOperation = c.String(),
                        Count = c.Double(nullable: false),
                        Rascenka = c.Double(nullable: false),
                        Time = c.Double(nullable: false),
                        Day = c.Short(nullable: false),
                        Days = c.DateTime(nullable: false),
                        ExtNom = c.Int(nullable: false),
                        ShifrDetal = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.NomStr)
                .ForeignKey("dbo.Bnards", t => t.ExtNom, cascadeDelete: true)
                .ForeignKey("dbo.ShifrDets", t => t.ShifrDetal)
                .Index(t => t.ExtNom)
                .Index(t => t.ShifrDetal);
            
            CreateTable(
                "dbo.ShifrDets",
                c => new
                    {
                        ShifrDetal = c.String(nullable: false, maxLength: 128),
                        KodDetal = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ShifrDetal)
                .ForeignKey("dbo.SprDets", t => t.KodDetal)
                .Index(t => t.KodDetal);
            
            CreateTable(
                "dbo.SprDets",
                c => new
                    {
                        KodDetal = c.String(nullable: false, maxLength: 128),
                        NameDetal = c.String(),
                        ShifrDetal = c.String(),
                        Selected = c.Byte(nullable: false),
                        PrDopPrem = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.KodDetal);
            
            CreateTable(
                "dbo.Spropers",
                c => new
                    {
                        NomStr = c.Int(nullable: false, identity: true),
                        KodDetal = c.String(maxLength: 128),
                        FlagObhoda = c.Short(nullable: false),
                        NameOperation = c.String(),
                        Razriad = c.Short(nullable: false),
                        TimeComput = c.Double(nullable: false),
                        TimeOperation = c.Double(nullable: false),
                        Vrednost = c.Double(nullable: false),
                        Procent = c.Double(nullable: false),
                        Rascenka = c.Double(nullable: false),
                        GrTarif = c.Short(nullable: false),
                        DpPrem = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.NomStr)
                .ForeignKey("dbo.SprDets", t => t.KodDetal)
                .ForeignKey("dbo.TARIFs", t => t.Razriad, cascadeDelete: true)
                .Index(t => t.KodDetal)
                .Index(t => t.Razriad);
            
            CreateTable(
                "dbo.TARIFs",
                c => new
                    {
                        Razriad = c.Short(nullable: false, identity: true),
                        Tarif1 = c.Double(nullable: false),
                        Tarif = c.Double(nullable: false),
                        Tarif3 = c.Double(nullable: false),
                        MTarif = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Razriad);
            
            CreateTable(
                "dbo.BRab_Korr",
                c => new
                    {
                        NomStr = c.Int(nullable: false, identity: true),
                        NNariada = c.Short(nullable: false),
                        Moon = c.Short(nullable: false),
                        TabNomer = c.Int(nullable: false),
                        KTU = c.Double(nullable: false),
                        SumAll = c.Double(nullable: false),
                        TimeAll = c.Double(nullable: false),
                        KodOpl = c.Short(nullable: false),
                        TabelId = c.Int(nullable: false),
                        Tabel_ExtNom = c.Int(),
                    })
                .PrimaryKey(t => t.NomStr)
                .ForeignKey("dbo.Tabels", t => t.Tabel_ExtNom)
                .Index(t => t.Tabel_ExtNom);
            
            CreateTable(
                "dbo.Tabels",
                c => new
                    {
                        ExtNom = c.Int(nullable: false, identity: true),
                        Moon = c.Short(nullable: false),
                        TabNomer = c.Int(nullable: false),
                        TimeFact = c.Short(nullable: false),
                        NormoVremia = c.Short(nullable: false),
                        SumAll = c.Double(nullable: false),
                        PrVip = c.Double(nullable: false),
                        KodOpl = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.ExtNom)
                .ForeignKey("dbo.SPRRABs", t => t.TabNomer, cascadeDelete: true)
                .Index(t => t.TabNomer);
            
            CreateTable(
                "dbo.SPRRABs",
                c => new
                    {
                        TabNomer = c.Int(nullable: false, identity: true),
                        Ceh = c.Short(nullable: false),
                        Uch = c.Short(nullable: false),
                        FIO = c.String(),
                        KodProfessii = c.Short(nullable: false),
                        Kategoria = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.TabNomer)
                .ForeignKey("dbo.PROFFs", t => t.KodProfessii, cascadeDelete: true)
                .Index(t => t.KodProfessii);
            
            CreateTable(
                "dbo.PROFFs",
                c => new
                    {
                        KodProf = c.Short(nullable: false, identity: true),
                        NameProf = c.String(),
                    })
                .PrimaryKey(t => t.KodProf);
            
            CreateTable(
                "dbo.Brabs",
                c => new
                    {
                        NomStr = c.Int(nullable: false, identity: true),
                        ExtNom = c.Int(nullable: false),
                        TabNomer = c.Int(nullable: false),
                        KTU = c.Double(nullable: false),
                        SumAll = c.Double(nullable: false),
                        TimeAll = c.Double(nullable: false),
                        KodOpl = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.NomStr)
                .ForeignKey("dbo.Bnards", t => t.ExtNom, cascadeDelete: true)
                .ForeignKey("dbo.SPRRABs", t => t.TabNomer, cascadeDelete: true)
                .Index(t => t.ExtNom)
                .Index(t => t.TabNomer);
            
            CreateTable(
                "dbo.Kernas",
                c => new
                    {
                        Empty = c.Int(nullable: false, identity: true),
                        TabNomer = c.Int(nullable: false),
                        KodOpl = c.Short(nullable: false),
                        KodDetal = c.String(maxLength: 128),
                        KodOperation = c.Short(nullable: false),
                        NameDetal = c.String(),
                        Count = c.Double(nullable: false),
                        Moon = c.Short(nullable: false),
                        Days = c.DateTime(nullable: false),
                        FIO = c.String(),
                        Uch = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.Empty)
                .ForeignKey("dbo.SprDets", t => t.KodDetal)
                .ForeignKey("dbo.SPRRABs", t => t.TabNomer, cascadeDelete: true)
                .Index(t => t.TabNomer)
                .Index(t => t.KodDetal);
            
            CreateTable(
                "dbo.KorUches",
                c => new
                    {
                        ExtNom = c.Int(nullable: false, identity: true),
                        TabNomer = c.Int(nullable: false),
                        KodOpl = c.Short(nullable: false),
                        KodDetal = c.String(maxLength: 128),
                        KodOperation = c.Short(nullable: false),
                        NameDetal = c.String(),
                        Count_old = c.Double(nullable: false),
                        CountN = c.Double(nullable: false),
                        Raznica = c.Double(nullable: false),
                        Days = c.DateTime(nullable: false),
                        SysDat = c.DateTime(nullable: false),
                        Moon = c.Short(nullable: false),
                        Komment = c.String(),
                    })
                .PrimaryKey(t => t.ExtNom)
                .ForeignKey("dbo.SprDets", t => t.KodDetal)
                .ForeignKey("dbo.SPRRABs", t => t.TabNomer, cascadeDelete: true)
                .Index(t => t.TabNomer)
                .Index(t => t.KodDetal);
            
            CreateTable(
                "dbo.MsFndVrs",
                c => new
                    {
                        PN = c.Int(nullable: false, identity: true),
                        Mesec = c.Short(nullable: false),
                        NaimMes = c.String(),
                        MFVrem = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PN);
            
            CreateTable(
                "dbo.Naches",
                c => new
                    {
                        POB = c.String(nullable: false, maxLength: 128),
                        TAB = c.Double(nullable: false),
                        KOD = c.Double(nullable: false),
                        DATEOPL = c.String(),
                        TIMEOPL = c.Double(nullable: false),
                        SUMMA = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.POB);
            
            CreateTable(
                "dbo.NardStr_Sproper",
                c => new
                    {
                        NardStr_SproperID = c.Int(nullable: false, identity: true),
                        NardStr_NomStr = c.Int(nullable: false),
                        Sproper_NomStr = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NardStr_SproperID)
                .ForeignKey("dbo.NardStrs", t => t.NardStr_NomStr, cascadeDelete: true)
                .ForeignKey("dbo.Spropers", t => t.Sproper_NomStr, cascadeDelete: true)
                .Index(t => t.NardStr_NomStr)
                .Index(t => t.Sproper_NomStr);
            
            CreateTable(
                "dbo.NardStrs",
                c => new
                    {
                        NomStr = c.Int(nullable: false, identity: true),
                        ExtNom = c.Int(nullable: false),
                        Day = c.Short(nullable: false),
                        ShifrDetal = c.String(maxLength: 128),
                        KodiOperation = c.String(),
                        Count = c.Double(nullable: false),
                        Rascenka = c.Double(nullable: false),
                        Time = c.Double(nullable: false),
                        Days = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NomStr)
                .ForeignKey("dbo.Nards", t => t.ExtNom, cascadeDelete: true)
                .ForeignKey("dbo.ShifrDets", t => t.ShifrDetal)
                .Index(t => t.ExtNom)
                .Index(t => t.ShifrDetal);
            
            CreateTable(
                "dbo.Nards",
                c => new
                    {
                        ExtNom = c.Int(nullable: false, identity: true),
                        Selected = c.Byte(nullable: false),
                        Moon = c.Short(nullable: false),
                        TabNomer = c.Int(nullable: false),
                        NameNariada = c.String(),
                        SumAll = c.Double(nullable: false),
                        TimeAll = c.Double(nullable: false),
                        KodOpl = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.ExtNom)
                .ForeignKey("dbo.SPRRABs", t => t.TabNomer, cascadeDelete: true)
                .Index(t => t.TabNomer);
            
            CreateTable(
                "dbo.OtpVreds",
                c => new
                    {
                        PN = c.Int(nullable: false, identity: true),
                        ProcDopl = c.Short(nullable: false),
                        GodOtpVr = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.PN);
            
            CreateTable(
                "dbo.RKalends",
                c => new
                    {
                        Npp = c.Int(nullable: false, identity: true),
                        DataR = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Npp);
            
            CreateTable(
                "dbo.SPRMETALs",
                c => new
                    {
                        NPP = c.Int(nullable: false, identity: true),
                        GR = c.String(),
                        PODGR = c.String(),
                        KMAT = c.String(),
                        PNMAT = c.String(),
                        UDVES = c.Double(nullable: false),
                        NMAT = c.String(),
                        EIZ = c.String(),
                        RAZMER = c.String(),
                        GOST = c.String(),
                        HAR = c.String(),
                        KODTN = c.String(),
                        VNORMA = c.Byte(),
                    })
                .PrimaryKey(t => t.NPP);
            
            CreateTable(
                "dbo.Sravnenies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KodDetal = c.String(maxLength: 128),
                        KodOperation = c.Short(nullable: false),
                        Razriad = c.Short(nullable: false),
                        Razriad_1 = c.Short(nullable: false),
                        GrTarif = c.Short(nullable: false),
                        GrTarif_1 = c.Short(nullable: false),
                        Vrednost = c.Double(nullable: false),
                        Vrednost_1 = c.Double(nullable: false),
                        TimeOperation = c.Double(nullable: false),
                        TimeOperation_1 = c.Double(nullable: false),
                        Rascenka = c.Double(nullable: false),
                        Rascenka_1 = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SprDets", t => t.KodDetal)
                .ForeignKey("dbo.TARIFs", t => t.Razriad, cascadeDelete: true)
                .Index(t => t.KodDetal)
                .Index(t => t.Razriad);
            
            CreateTable(
                "dbo.UchDets",
                c => new
                    {
                        ExtNom = c.Int(nullable: false, identity: true),
                        NomStr = c.Int(nullable: false),
                        KodOperation = c.Short(nullable: false),
                        NameOperation = c.String(),
                        KodDetal = c.String(maxLength: 128),
                        NameDeta = c.String(),
                        Count = c.Double(nullable: false),
                        TabNomer = c.Int(nullable: false),
                        KodOpl = c.Short(nullable: false),
                        Moon = c.Short(nullable: false),
                        Day = c.Short(nullable: false),
                        Days = c.DateTime(nullable: false),
                        FIO = c.String(),
                        Uch = c.Short(nullable: false),
                        Ceh = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.ExtNom)
                .ForeignKey("dbo.NardStrs", t => t.NomStr, cascadeDelete: true)
                .ForeignKey("dbo.SprDets", t => t.KodDetal)
                .Index(t => t.NomStr)
                .Index(t => t.KodDetal);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        FIO = c.String(),
                        Department = c.String(),
                        NormalizedUserName = c.String(),
                        Email = c.String(),
                        NormalizedEmail = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        ConcurrencyStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEnd = c.DateTimeOffset(precision: 7),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUserLogins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId });
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.UchDets", "KodDetal", "dbo.SprDets");
            DropForeignKey("dbo.UchDets", "NomStr", "dbo.NardStrs");
            DropForeignKey("dbo.Sravnenies", "Razriad", "dbo.TARIFs");
            DropForeignKey("dbo.Sravnenies", "KodDetal", "dbo.SprDets");
            DropForeignKey("dbo.NardStr_Sproper", "Sproper_NomStr", "dbo.Spropers");
            DropForeignKey("dbo.NardStr_Sproper", "NardStr_NomStr", "dbo.NardStrs");
            DropForeignKey("dbo.NardStrs", "ShifrDetal", "dbo.ShifrDets");
            DropForeignKey("dbo.NardStrs", "ExtNom", "dbo.Nards");
            DropForeignKey("dbo.Nards", "TabNomer", "dbo.SPRRABs");
            DropForeignKey("dbo.KorUches", "TabNomer", "dbo.SPRRABs");
            DropForeignKey("dbo.KorUches", "KodDetal", "dbo.SprDets");
            DropForeignKey("dbo.Kernas", "TabNomer", "dbo.SPRRABs");
            DropForeignKey("dbo.Kernas", "KodDetal", "dbo.SprDets");
            DropForeignKey("dbo.Brabs", "TabNomer", "dbo.SPRRABs");
            DropForeignKey("dbo.Brabs", "ExtNom", "dbo.Bnards");
            DropForeignKey("dbo.BRab_Korr", "Tabel_ExtNom", "dbo.Tabels");
            DropForeignKey("dbo.Tabels", "TabNomer", "dbo.SPRRABs");
            DropForeignKey("dbo.SPRRABs", "KodProfessii", "dbo.PROFFs");
            DropForeignKey("dbo.BnardStr_Sproper", "Sproper_NomStr", "dbo.Spropers");
            DropForeignKey("dbo.Spropers", "Razriad", "dbo.TARIFs");
            DropForeignKey("dbo.Spropers", "KodDetal", "dbo.SprDets");
            DropForeignKey("dbo.BnardStr_Sproper", "BnardStr_NomStr", "dbo.BnardStrs");
            DropForeignKey("dbo.BnardStrs", "ShifrDetal", "dbo.ShifrDets");
            DropForeignKey("dbo.ShifrDets", "KodDetal", "dbo.SprDets");
            DropForeignKey("dbo.BnardStrs", "ExtNom", "dbo.Bnards");
            DropIndex("dbo.UchDets", new[] { "KodDetal" });
            DropIndex("dbo.UchDets", new[] { "NomStr" });
            DropIndex("dbo.Sravnenies", new[] { "Razriad" });
            DropIndex("dbo.Sravnenies", new[] { "KodDetal" });
            DropIndex("dbo.Nards", new[] { "TabNomer" });
            DropIndex("dbo.NardStrs", new[] { "ShifrDetal" });
            DropIndex("dbo.NardStrs", new[] { "ExtNom" });
            DropIndex("dbo.NardStr_Sproper", new[] { "Sproper_NomStr" });
            DropIndex("dbo.NardStr_Sproper", new[] { "NardStr_NomStr" });
            DropIndex("dbo.KorUches", new[] { "KodDetal" });
            DropIndex("dbo.KorUches", new[] { "TabNomer" });
            DropIndex("dbo.Kernas", new[] { "KodDetal" });
            DropIndex("dbo.Kernas", new[] { "TabNomer" });
            DropIndex("dbo.Brabs", new[] { "TabNomer" });
            DropIndex("dbo.Brabs", new[] { "ExtNom" });
            DropIndex("dbo.SPRRABs", new[] { "KodProfessii" });
            DropIndex("dbo.Tabels", new[] { "TabNomer" });
            DropIndex("dbo.BRab_Korr", new[] { "Tabel_ExtNom" });
            DropIndex("dbo.Spropers", new[] { "Razriad" });
            DropIndex("dbo.Spropers", new[] { "KodDetal" });
            DropIndex("dbo.ShifrDets", new[] { "KodDetal" });
            DropIndex("dbo.BnardStrs", new[] { "ShifrDetal" });
            DropIndex("dbo.BnardStrs", new[] { "ExtNom" });
            DropIndex("dbo.BnardStr_Sproper", new[] { "Sproper_NomStr" });
            DropIndex("dbo.BnardStr_Sproper", new[] { "BnardStr_NomStr" });
            DropTable("dbo.Users");
            DropTable("dbo.UchDets");
            DropTable("dbo.Sravnenies");
            DropTable("dbo.SPRMETALs");
            DropTable("dbo.RKalends");
            DropTable("dbo.OtpVreds");
            DropTable("dbo.Nards");
            DropTable("dbo.NardStrs");
            DropTable("dbo.NardStr_Sproper");
            DropTable("dbo.Naches");
            DropTable("dbo.MsFndVrs");
            DropTable("dbo.KorUches");
            DropTable("dbo.Kernas");
            DropTable("dbo.Brabs");
            DropTable("dbo.PROFFs");
            DropTable("dbo.SPRRABs");
            DropTable("dbo.Tabels");
            DropTable("dbo.BRab_Korr");
            DropTable("dbo.TARIFs");
            DropTable("dbo.Spropers");
            DropTable("dbo.SprDets");
            DropTable("dbo.ShifrDets");
            DropTable("dbo.BnardStrs");
            DropTable("dbo.BnardStr_Sproper");
            DropTable("dbo.Bnards");
            CreateIndex("dbo.AspNetUserLogins", "UserId");
            CreateIndex("dbo.AspNetUserClaims", "UserId");
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.AspNetUserRoles", "RoleId");
            CreateIndex("dbo.AspNetUserRoles", "UserId");
            CreateIndex("dbo.AspNetRoles", "Name", unique: true, name: "RoleNameIndex");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
        }
    }
}
