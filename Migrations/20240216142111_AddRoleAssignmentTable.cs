using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NardSmena.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleAssignmentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "dbo");

            migrationBuilder.CreateTable(
                name: "Bnard",
                schema: "dbo",
                columns: table => new
                {
                    ExtNom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Moon = table.Column<short>(type: "smallint", nullable: false),
                    Selected = table.Column<byte>(type: "tinyint", nullable: false),
                    NNariada = table.Column<short>(type: "smallint", nullable: false),
                    NameNariada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SummAll = table.Column<double>(type: "float", nullable: false),
                    TimeAll = table.Column<double>(type: "float", nullable: false),
                    KodOpl = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bnard", x => x.ExtNom);
                });

            migrationBuilder.CreateTable(
                name: "MsFndVr",
                schema: "dbo",
                columns: table => new
                {
                    PN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mesec = table.Column<short>(type: "smallint", nullable: false),
                    NaimMes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MFVrem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MsFndVr", x => x.PN);
                });

            migrationBuilder.CreateTable(
                name: "Nach",
                schema: "dbo",
                columns: table => new
                {
                    POB = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TAB = table.Column<double>(type: "float", nullable: false),
                    KOD = table.Column<double>(type: "float", nullable: false),
                    DATEOPL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TIMEOPL = table.Column<double>(type: "float", nullable: false),
                    SUMMA = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nach", x => x.POB);
                });

            migrationBuilder.CreateTable(
                name: "OtpVred",
                schema: "dbo",
                columns: table => new
                {
                    PN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProcDopl = table.Column<short>(type: "smallint", nullable: false),
                    GodOtpVr = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpVred", x => x.PN);
                });

            migrationBuilder.CreateTable(
                name: "PROFF",
                schema: "dbo",
                columns: table => new
                {
                    KodProf = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameProf = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROFF", x => x.KodProf);
                });

            migrationBuilder.CreateTable(
                name: "RKalend",
                schema: "dbo",
                columns: table => new
                {
                    Npp = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataR = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RKalend", x => x.Npp);
                });

            migrationBuilder.CreateTable(
                name: "SprDet",
                schema: "dbo",
                columns: table => new
                {
                    KodDetal = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameDetal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShifrDetal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Selected = table.Column<bool>(type: "bit", nullable: false),
                    PrDopPrem = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SprDet", x => x.KodDetal);
                });

            migrationBuilder.CreateTable(
                name: "SPRMETAL",
                schema: "dbo",
                columns: table => new
                {
                    NPP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PODGR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KMAT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PNMAT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UDVES = table.Column<double>(type: "float", nullable: false),
                    NMAT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EIZ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RAZMER = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GOST = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HAR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KODTN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VNORMA = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPRMETAL", x => x.NPP);
                });

            migrationBuilder.CreateTable(
                name: "TARIF",
                schema: "dbo",
                columns: table => new
                {
                    Razriad = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarif1 = table.Column<double>(type: "float", nullable: false),
                    Tarif = table.Column<double>(type: "float", nullable: false),
                    Tarif3 = table.Column<double>(type: "float", nullable: false),
                    MTarif = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TARIF", x => x.Razriad);
                });

            migrationBuilder.CreateTable(
                name: "SPRRAB",
                schema: "dbo",
                columns: table => new
                {
                    TabNomer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ceh = table.Column<short>(type: "smallint", nullable: false),
                    Uch = table.Column<short>(type: "smallint", nullable: false),
                    FIO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodProfessii = table.Column<short>(type: "smallint", nullable: false),
                    Kategoria = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SPRRAB", x => x.TabNomer);
                    table.ForeignKey(
                        name: "FK_SPRRAB_PROFF_KodProfessii",
                        column: x => x.KodProfessii,
                        principalSchema: "dbo",
                        principalTable: "PROFF",
                        principalColumn: "KodProf",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShifrDet",
                schema: "dbo",
                columns: table => new
                {
                    ShifrDetal = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KodDetal = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShifrDet", x => x.ShifrDetal);
                    table.ForeignKey(
                        name: "FK_ShifrDet_SprDet_KodDetal",
                        column: x => x.KodDetal,
                        principalSchema: "dbo",
                        principalTable: "SprDet",
                        principalColumn: "KodDetal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sproper",
                schema: "dbo",
                columns: table => new
                {
                    NomStr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KodDetal = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FlagObhoda = table.Column<short>(type: "smallint", nullable: false),
                    KodOperation = table.Column<short>(type: "smallint", nullable: false),
                    NameOperation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Razriad = table.Column<short>(type: "smallint", nullable: false),
                    TimeComput = table.Column<double>(type: "float", nullable: false),
                    TimeOperation = table.Column<double>(type: "float", nullable: false),
                    Vrednost = table.Column<double>(type: "float", nullable: false),
                    Procent = table.Column<double>(type: "float", nullable: false),
                    Rascenka = table.Column<double>(type: "float", nullable: false),
                    GrTarif = table.Column<short>(type: "smallint", nullable: false),
                    DpPrem = table.Column<short>(type: "smallint", nullable: false),
                    KoefDV = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sproper", x => x.NomStr);
                    table.ForeignKey(
                        name: "FK_Sproper_SprDet_KodDetal",
                        column: x => x.KodDetal,
                        principalSchema: "dbo",
                        principalTable: "SprDet",
                        principalColumn: "KodDetal");
                    table.ForeignKey(
                        name: "FK_Sproper_TARIF_Razriad",
                        column: x => x.Razriad,
                        principalSchema: "dbo",
                        principalTable: "TARIF",
                        principalColumn: "Razriad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sravnenie",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KodDetal = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KodOperation = table.Column<short>(type: "smallint", nullable: false),
                    Razriad = table.Column<short>(type: "smallint", nullable: false),
                    Razriad_1 = table.Column<short>(type: "smallint", nullable: false),
                    GrTarif = table.Column<short>(type: "smallint", nullable: false),
                    GrTarif_1 = table.Column<short>(type: "smallint", nullable: false),
                    Vrednost = table.Column<double>(type: "float", nullable: false),
                    Vrednost_1 = table.Column<double>(type: "float", nullable: false),
                    TimeOperation = table.Column<double>(type: "float", nullable: false),
                    TimeOperation_1 = table.Column<double>(type: "float", nullable: false),
                    Rascenka = table.Column<double>(type: "float", nullable: false),
                    Rascenka_1 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sravnenie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sravnenie_SprDet_KodDetal",
                        column: x => x.KodDetal,
                        principalSchema: "dbo",
                        principalTable: "SprDet",
                        principalColumn: "KodDetal");
                    table.ForeignKey(
                        name: "FK_Sravnenie_TARIF_Razriad",
                        column: x => x.Razriad,
                        principalSchema: "dbo",
                        principalTable: "TARIF",
                        principalColumn: "Razriad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Brab",
                schema: "dbo",
                columns: table => new
                {
                    NomStr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtNom = table.Column<int>(type: "int", nullable: false),
                    TabNomer = table.Column<int>(type: "int", nullable: false),
                    KTU = table.Column<double>(type: "float", nullable: false),
                    SumAll = table.Column<double>(type: "float", nullable: false),
                    TimeAll = table.Column<double>(type: "float", nullable: false),
                    KodOpl = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brab", x => x.NomStr);
                    table.ForeignKey(
                        name: "FK_Brab_Bnard_ExtNom",
                        column: x => x.ExtNom,
                        principalSchema: "dbo",
                        principalTable: "Bnard",
                        principalColumn: "ExtNom",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Brab_SPRRAB_TabNomer",
                        column: x => x.TabNomer,
                        principalSchema: "dbo",
                        principalTable: "SPRRAB",
                        principalColumn: "TabNomer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kerna",
                schema: "dbo",
                columns: table => new
                {
                    Empty = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TabNomer = table.Column<int>(type: "int", nullable: false),
                    KodOpl = table.Column<short>(type: "smallint", nullable: false),
                    KodDetal = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KodOperation = table.Column<short>(type: "smallint", nullable: false),
                    NameDetal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOperation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<double>(type: "float", nullable: false),
                    Moon = table.Column<short>(type: "smallint", nullable: false),
                    Days = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FIO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uch = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kerna", x => x.Empty);
                    table.ForeignKey(
                        name: "FK_Kerna_SPRRAB_TabNomer",
                        column: x => x.TabNomer,
                        principalSchema: "dbo",
                        principalTable: "SPRRAB",
                        principalColumn: "TabNomer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kerna_SprDet_KodDetal",
                        column: x => x.KodDetal,
                        principalSchema: "dbo",
                        principalTable: "SprDet",
                        principalColumn: "KodDetal");
                });

            migrationBuilder.CreateTable(
                name: "KorUch",
                schema: "dbo",
                columns: table => new
                {
                    ExtNom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TabNomer = table.Column<int>(type: "int", nullable: false),
                    KodOpl = table.Column<short>(type: "smallint", nullable: false),
                    KodDetal = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KodOperation = table.Column<short>(type: "smallint", nullable: false),
                    NameDetal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count_old = table.Column<double>(type: "float", nullable: false),
                    CountN = table.Column<double>(type: "float", nullable: false),
                    Raznica = table.Column<double>(type: "float", nullable: false),
                    Days = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SysDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Moon = table.Column<short>(type: "smallint", nullable: false),
                    Komment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorUch", x => x.ExtNom);
                    table.ForeignKey(
                        name: "FK_KorUch_SPRRAB_TabNomer",
                        column: x => x.TabNomer,
                        principalSchema: "dbo",
                        principalTable: "SPRRAB",
                        principalColumn: "TabNomer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KorUch_SprDet_KodDetal",
                        column: x => x.KodDetal,
                        principalSchema: "dbo",
                        principalTable: "SprDet",
                        principalColumn: "KodDetal");
                });

            migrationBuilder.CreateTable(
                name: "Nard",
                schema: "dbo",
                columns: table => new
                {
                    ExtNom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Selected = table.Column<byte>(type: "tinyint", nullable: false),
                    Moon = table.Column<short>(type: "smallint", nullable: false),
                    TabNomer = table.Column<int>(type: "int", nullable: false),
                    NameNariada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SumAll = table.Column<double>(type: "float", nullable: false),
                    TimeAll = table.Column<double>(type: "float", nullable: false),
                    KodOpl = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nard", x => x.ExtNom);
                    table.ForeignKey(
                        name: "FK_Nard_SPRRAB_TabNomer",
                        column: x => x.TabNomer,
                        principalSchema: "dbo",
                        principalTable: "SPRRAB",
                        principalColumn: "TabNomer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tabel",
                schema: "dbo",
                columns: table => new
                {
                    ExtNom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Moon = table.Column<short>(type: "smallint", nullable: false),
                    TabNomer = table.Column<int>(type: "int", nullable: false),
                    TimeFact = table.Column<short>(type: "smallint", nullable: false),
                    NormoVremia = table.Column<short>(type: "smallint", nullable: false),
                    SumAll = table.Column<double>(type: "float", nullable: false),
                    PrVip = table.Column<double>(type: "float", nullable: false),
                    KodOpl = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabel", x => x.ExtNom);
                    table.ForeignKey(
                        name: "FK_Tabel_SPRRAB_TabNomer",
                        column: x => x.TabNomer,
                        principalSchema: "dbo",
                        principalTable: "SPRRAB",
                        principalColumn: "TabNomer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BnardStr",
                schema: "dbo",
                columns: table => new
                {
                    NomStr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KodiOperation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<double>(type: "float", nullable: false),
                    Rascenka = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<double>(type: "float", nullable: false),
                    Day = table.Column<short>(type: "smallint", nullable: false),
                    Days = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExtNom = table.Column<int>(type: "int", nullable: false),
                    ShifrDetal = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BnardStr", x => x.NomStr);
                    table.ForeignKey(
                        name: "FK_BnardStr_Bnard_ExtNom",
                        column: x => x.ExtNom,
                        principalSchema: "dbo",
                        principalTable: "Bnard",
                        principalColumn: "ExtNom",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BnardStr_ShifrDet_ShifrDetal",
                        column: x => x.ShifrDetal,
                        principalSchema: "dbo",
                        principalTable: "ShifrDet",
                        principalColumn: "ShifrDetal");
                });

            migrationBuilder.CreateTable(
                name: "NardStr",
                schema: "dbo",
                columns: table => new
                {
                    NomStr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtNom = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<short>(type: "smallint", nullable: false),
                    ShifrDetal = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KodiOperation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<double>(type: "float", nullable: false),
                    Rascenka = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<double>(type: "float", nullable: false),
                    Days = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NardStr", x => x.NomStr);
                    table.ForeignKey(
                        name: "FK_NardStr_Nard_ExtNom",
                        column: x => x.ExtNom,
                        principalSchema: "dbo",
                        principalTable: "Nard",
                        principalColumn: "ExtNom",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NardStr_ShifrDet_ShifrDetal",
                        column: x => x.ShifrDetal,
                        principalSchema: "dbo",
                        principalTable: "ShifrDet",
                        principalColumn: "ShifrDetal");
                });

            migrationBuilder.CreateTable(
                name: "BRab_Korr",
                schema: "dbo",
                columns: table => new
                {
                    NomStr = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtNom = table.Column<int>(type: "int", nullable: false),
                    NNariada = table.Column<short>(type: "smallint", nullable: false),
                    Moon = table.Column<short>(type: "smallint", nullable: false),
                    TabNomer = table.Column<int>(type: "int", nullable: false),
                    KTU = table.Column<double>(type: "float", nullable: false),
                    SumAll = table.Column<double>(type: "float", nullable: false),
                    TimeAll = table.Column<double>(type: "float", nullable: false),
                    KodOpl = table.Column<short>(type: "smallint", nullable: false),
                    TabelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BRab_Korr", x => x.NomStr);
                    table.ForeignKey(
                        name: "FK_BRab_Korr_Tabel_ExtNom",
                        column: x => x.ExtNom,
                        principalSchema: "dbo",
                        principalTable: "Tabel",
                        principalColumn: "ExtNom",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BnardStr_Sproper",
                schema: "dbo",
                columns: table => new
                {
                    BnardStr_SproperID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BnardStr_NomStr = table.Column<int>(type: "int", nullable: false),
                    Sproper_NomStr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BnardStr_Sproper", x => x.BnardStr_SproperID);
                    table.ForeignKey(
                        name: "FK_BnardStr_Sproper_BnardStr_BnardStr_NomStr",
                        column: x => x.BnardStr_NomStr,
                        principalSchema: "dbo",
                        principalTable: "BnardStr",
                        principalColumn: "NomStr",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BnardStr_Sproper_Sproper_Sproper_NomStr",
                        column: x => x.Sproper_NomStr,
                        principalSchema: "dbo",
                        principalTable: "Sproper",
                        principalColumn: "NomStr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NardStr_Sproper",
                schema: "dbo",
                columns: table => new
                {
                    NardStr_SproperID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NardStr_NomStr = table.Column<int>(type: "int", nullable: false),
                    Sproper_NomStr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NardStr_Sproper", x => x.NardStr_SproperID);
                    table.ForeignKey(
                        name: "FK_NardStr_Sproper_NardStr_NardStr_NomStr",
                        column: x => x.NardStr_NomStr,
                        principalSchema: "dbo",
                        principalTable: "NardStr",
                        principalColumn: "NomStr",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NardStr_Sproper_Sproper_Sproper_NomStr",
                        column: x => x.Sproper_NomStr,
                        principalSchema: "dbo",
                        principalTable: "Sproper",
                        principalColumn: "NomStr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UchDet",
                schema: "dbo",
                columns: table => new
                {
                    ExtNom = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomStr = table.Column<int>(type: "int", nullable: false),
                    KodOperation = table.Column<short>(type: "smallint", nullable: false),
                    NameOperation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodDetal = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NameDetal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<double>(type: "float", nullable: false),
                    TabNomer = table.Column<int>(type: "int", nullable: false),
                    KodOpl = table.Column<short>(type: "smallint", nullable: false),
                    Moon = table.Column<short>(type: "smallint", nullable: false),
                    Day = table.Column<short>(type: "smallint", nullable: false),
                    Days = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FIO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uch = table.Column<short>(type: "smallint", nullable: false),
                    Ceh = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UchDet", x => x.ExtNom);
                    table.ForeignKey(
                        name: "FK_UchDet_NardStr_NomStr",
                        column: x => x.NomStr,
                        principalSchema: "dbo",
                        principalTable: "NardStr",
                        principalColumn: "NomStr",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UchDet_SprDet_KodDetal",
                        column: x => x.KodDetal,
                        principalSchema: "dbo",
                        principalTable: "SprDet",
                        principalColumn: "KodDetal");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BnardStr_ExtNom",
                schema: "dbo",
                table: "BnardStr",
                column: "ExtNom");

            migrationBuilder.CreateIndex(
                name: "IX_BnardStr_ShifrDetal",
                schema: "dbo",
                table: "BnardStr",
                column: "ShifrDetal");

            migrationBuilder.CreateIndex(
                name: "IX_BnardStr_Sproper_BnardStr_NomStr",
                schema: "dbo",
                table: "BnardStr_Sproper",
                column: "BnardStr_NomStr");

            migrationBuilder.CreateIndex(
                name: "IX_BnardStr_Sproper_Sproper_NomStr",
                schema: "dbo",
                table: "BnardStr_Sproper",
                column: "Sproper_NomStr");

            migrationBuilder.CreateIndex(
                name: "IX_Brab_ExtNom",
                schema: "dbo",
                table: "Brab",
                column: "ExtNom");

            migrationBuilder.CreateIndex(
                name: "IX_Brab_TabNomer",
                schema: "dbo",
                table: "Brab",
                column: "TabNomer");

            migrationBuilder.CreateIndex(
                name: "IX_BRab_Korr_ExtNom",
                schema: "dbo",
                table: "BRab_Korr",
                column: "ExtNom");

            migrationBuilder.CreateIndex(
                name: "IX_Kerna_KodDetal",
                schema: "dbo",
                table: "Kerna",
                column: "KodDetal");

            migrationBuilder.CreateIndex(
                name: "IX_Kerna_TabNomer",
                schema: "dbo",
                table: "Kerna",
                column: "TabNomer");

            migrationBuilder.CreateIndex(
                name: "IX_KorUch_KodDetal",
                schema: "dbo",
                table: "KorUch",
                column: "KodDetal");

            migrationBuilder.CreateIndex(
                name: "IX_KorUch_TabNomer",
                schema: "dbo",
                table: "KorUch",
                column: "TabNomer");

            migrationBuilder.CreateIndex(
                name: "IX_Nard_TabNomer",
                schema: "dbo",
                table: "Nard",
                column: "TabNomer");

            migrationBuilder.CreateIndex(
                name: "IX_NardStr_ExtNom",
                schema: "dbo",
                table: "NardStr",
                column: "ExtNom");

            migrationBuilder.CreateIndex(
                name: "IX_NardStr_ShifrDetal",
                schema: "dbo",
                table: "NardStr",
                column: "ShifrDetal");

            migrationBuilder.CreateIndex(
                name: "IX_NardStr_Sproper_NardStr_NomStr",
                schema: "dbo",
                table: "NardStr_Sproper",
                column: "NardStr_NomStr");

            migrationBuilder.CreateIndex(
                name: "IX_NardStr_Sproper_Sproper_NomStr",
                schema: "dbo",
                table: "NardStr_Sproper",
                column: "Sproper_NomStr");

            migrationBuilder.CreateIndex(
                name: "IX_ShifrDet_KodDetal",
                schema: "dbo",
                table: "ShifrDet",
                column: "KodDetal");

            migrationBuilder.CreateIndex(
                name: "IX_Sproper_KodDetal",
                schema: "dbo",
                table: "Sproper",
                column: "KodDetal");

            migrationBuilder.CreateIndex(
                name: "IX_Sproper_Razriad",
                schema: "dbo",
                table: "Sproper",
                column: "Razriad");

            migrationBuilder.CreateIndex(
                name: "IX_SPRRAB_KodProfessii",
                schema: "dbo",
                table: "SPRRAB",
                column: "KodProfessii");

            migrationBuilder.CreateIndex(
                name: "IX_Sravnenie_KodDetal",
                schema: "dbo",
                table: "Sravnenie",
                column: "KodDetal");

            migrationBuilder.CreateIndex(
                name: "IX_Sravnenie_Razriad",
                schema: "dbo",
                table: "Sravnenie",
                column: "Razriad");

            migrationBuilder.CreateIndex(
                name: "IX_Tabel_TabNomer",
                schema: "dbo",
                table: "Tabel",
                column: "TabNomer");

            migrationBuilder.CreateIndex(
                name: "IX_UchDet_KodDetal",
                schema: "dbo",
                table: "UchDet",
                column: "KodDetal");

            migrationBuilder.CreateIndex(
                name: "IX_UchDet_NomStr",
                schema: "dbo",
                table: "UchDet",
                column: "NomStr");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BnardStr_Sproper",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Brab",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BRab_Korr",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Kerna",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "KorUch",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MsFndVr",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Nach",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "NardStr_Sproper",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OtpVred",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RKalend",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SPRMETAL",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Sravnenie",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UchDet",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BnardStr",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Tabel",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Sproper",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "NardStr",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Bnard",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TARIF",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Nard",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ShifrDet",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SPRRAB",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SprDet",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PROFF",
                schema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "dbo",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "dbo",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "dbo",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "dbo",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "dbo",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "dbo",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "dbo",
                newName: "AspNetRoleClaims");
        }
    }
}
