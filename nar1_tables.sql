USE [Nar_1]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[FIO] [nvarchar](max) NOT NULL,
	[Department] [nvarchar](max) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bnard]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bnard](
	[ExtNom] [int] IDENTITY(1,1) NOT NULL,
	[Moon] [smallint] NULL,
	[Selected] [bit] NULL,
	[NNariada] [smallint] NULL,
	[NameNariada] [varchar](16) NULL,
	[SumAll] [float] NULL,
	[TimeAll] [float] NULL,
	[KodOpl] [smallint] NULL,
 CONSTRAINT [PK_Bnard] PRIMARY KEY CLUSTERED 
(
	[ExtNom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bnardstr]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bnardstr](
	[NomStr] [int] IDENTITY(1,1) NOT NULL,
	[ExtNom] [int] NULL,
	[ShifrDetal] [varchar](17) NULL,
	[KodiOperation] [varchar](64) NULL,
	[Count] [float] NULL,
	[Rascenka] [float] NOT NULL,
	[Time] [float] NULL,
	[Day] [smallint] NULL,
	[Days] [date] NULL,
 CONSTRAINT [PK_Bnardstr] PRIMARY KEY CLUSTERED 
(
	[NomStr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BnardStr_Sproper]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BnardStr_Sproper](
	[BnardStr_NomStr] [int] NULL,
	[Sproper_NomStr] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brab]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brab](
	[NomStr] [int] IDENTITY(1,1) NOT NULL,
	[ExtNom] [int] NULL,
	[TabNomer] [int] NULL,
	[KTU] [float] NULL,
	[SumAll] [float] NULL,
	[TimeAll] [float] NULL,
	[KodOpl] [smallint] NULL,
 CONSTRAINT [PK_Brad] PRIMARY KEY CLUSTERED 
(
	[NomStr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BRab_Korr]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BRab_Korr](
	[NomStr] [int] IDENTITY(1,1) NOT NULL,
	[ExtNom] [int] NULL,
	[NNariada] [smallint] NULL,
	[Moon] [smallint] NULL,
	[TabNomer] [int] NULL,
	[KTU] [float] NULL,
	[SumAll] [float] NULL,
	[TimeAll] [float] NULL,
	[KodOpl] [smallint] NULL,
 CONSTRAINT [PK_BRab_Korr] PRIMARY KEY CLUSTERED 
(
	[NomStr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kerna]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kerna](
	[Empty] [int] IDENTITY(1,1) NOT NULL,
	[TabNomer] [int] NULL,
	[KodOpl] [smallint] NULL,
	[KodDetal] [varchar](25) NULL,
	[KodOperation] [smallint] NULL,
	[NameDetal] [varchar](25) NULL,
	[NameOperation] [varchar](25) NULL,
	[Count] [float] NULL,
	[Moon] [smallint] NULL,
	[Days] [date] NULL,
	[FIO] [varchar](20) NULL,
	[Uch] [smallint] NULL,
 CONSTRAINT [PK_Kerna] PRIMARY KEY CLUSTERED 
(
	[Empty] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KorUch]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KorUch](
	[ExtNom] [int] IDENTITY(1,1) NOT NULL,
	[TabNomer] [int] NULL,
	[KodOpl] [smallint] NULL,
	[KodDetal] [varchar](25) NULL,
	[KodOperation] [smallint] NULL,
	[NameDetal] [varchar](25) NULL,
	[Count_old] [float] NULL,
	[CountN] [float] NULL,
	[Raznica] [float] NULL,
	[Days] [date] NULL,
	[SysDat] [date] NULL,
	[Moon] [smallint] NULL,
	[Komment] [varchar](20) NULL,
 CONSTRAINT [PK_KorUch] PRIMARY KEY CLUSTERED 
(
	[ExtNom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MsFndVr]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MsFndVr](
	[PN] [int] IDENTITY(1,1) NOT NULL,
	[Mesec] [smallint] NULL,
	[NaimMes] [varchar](15) NULL,
	[MFVrem] [int] NULL,
 CONSTRAINT [PK_MsFndVr] PRIMARY KEY CLUSTERED 
(
	[PN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nard]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nard](
	[ExtNom] [int] IDENTITY(1,1) NOT NULL,
	[Selected] [bit] NULL,
	[Moon] [smallint] NULL,
	[TabNomer] [int] NULL,
	[NameNariada] [varchar](16) NULL,
	[SumAll] [float] NULL,
	[TimeAll] [float] NULL,
	[KodOpl] [smallint] NULL,
 CONSTRAINT [PK_Nard] PRIMARY KEY CLUSTERED 
(
	[ExtNom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nardstr]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nardstr](
	[NomStr] [int] IDENTITY(1,1) NOT NULL,
	[ExtNom] [int] NULL,
	[Day] [smallint] NULL,
	[ShifrDetal] [varchar](17) NULL,
	[KodiOperation] [varchar](64) NULL,
	[Count] [float] NULL,
	[Rascenka] [float] NULL,
	[Time] [float] NULL,
	[Days] [date] NULL,
 CONSTRAINT [PK_Nardstr] PRIMARY KEY CLUSTERED 
(
	[NomStr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NardStr_Sproper]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NardStr_Sproper](
	[NardStr_NomStr] [int] NULL,
	[Sproper_NomStr] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OtpVred]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OtpVred](
	[PN] [int] IDENTITY(1,1) NOT NULL,
	[ProcDopl] [smallint] NULL,
	[GodOtpVr] [smallint] NULL,
 CONSTRAINT [PK_OtpVred] PRIMARY KEY CLUSTERED 
(
	[PN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PROFF]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PROFF](
	[KodProf] [smallint] NOT NULL,
	[NameProf] [varchar](70) NULL,
 CONSTRAINT [PK_PROFF] PRIMARY KEY CLUSTERED 
(
	[KodProf] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RKalend]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RKalend](
	[Npp] [int] IDENTITY(1,1) NOT NULL,
	[DataR] [date] NULL,
 CONSTRAINT [PK_RKalend] PRIMARY KEY CLUSTERED 
(
	[Npp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleAssignments]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleAssignments](
	[RoleAssignmentId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[SelectedRole] [nvarchar](100) NULL,
	[FIO] [nvarchar](150) NULL,
	[Department] [nvarchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleAssignmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShifrDet]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShifrDet](
	[ShifrDetal] [varchar](17) NOT NULL,
	[KodDetal] [varchar](25) NULL,
 CONSTRAINT [PK_ShifrDet] PRIMARY KEY CLUSTERED 
(
	[ShifrDetal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sprdet]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sprdet](
	[KodDetal] [varchar](25) NOT NULL,
	[NameDetal] [varchar](25) NULL,
	[ShifrDetal] [varchar](17) NULL,
	[Selected] [bit] NULL,
	[PrDopPrem] [smallint] NULL,
 CONSTRAINT [PK_Sprdet] PRIMARY KEY CLUSTERED 
(
	[KodDetal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SPRMETAL]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SPRMETAL](
	[NPP] [int] IDENTITY(1,1) NOT NULL,
	[GR] [varchar](4) NULL,
	[PODGR] [varchar](2) NULL,
	[KMAT] [varchar](25) NULL,
	[PNMAT] [varchar](45) NULL,
	[UDVES] [float] NULL,
	[NMAT] [varchar](40) NULL,
	[EIZ] [varchar](2) NULL,
	[RAZMER] [varchar](9) NULL,
	[GOST] [varchar](30) NULL,
	[HAR] [varchar](50) NULL,
	[KODTN] [varchar](4) NULL,
	[VNORMA] [bit] NULL,
 CONSTRAINT [PK_SPRMETAL] PRIMARY KEY CLUSTERED 
(
	[NPP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sproper]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sproper](
	[NomStr] [int] IDENTITY(1,1) NOT NULL,
	[KodDetal] [varchar](25) NULL,
	[FlagObhoda] [smallint] NULL,
	[KodOperation] [smallint] NULL,
	[NameOperation] [varchar](25) NULL,
	[Razriad] [smallint] NULL,
	[TimeComput] [float] NULL,
	[TimeOperation] [float] NULL,
	[Vrednost] [float] NULL,
	[Procent] [float] NULL,
	[Rascenka] [float] NULL,
	[GrTarif] [smallint] NULL,
	[DpPrem] [smallint] NULL,
	[KoefDV] [float] NULL,
 CONSTRAINT [PK_Sproper] PRIMARY KEY CLUSTERED 
(
	[NomStr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SPRRAB]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SPRRAB](
	[TabNomer] [int] NOT NULL,
	[Ceh] [smallint] NULL,
	[Uch] [smallint] NULL,
	[FIO] [varchar](50) NULL,
	[KodProfessii] [smallint] NULL,
	[Kategoria] [smallint] NULL,
 CONSTRAINT [PK_SPRRAB] PRIMARY KEY CLUSTERED 
(
	[TabNomer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sravnenie]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sravnenie](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[KodDetal] [varchar](25) NULL,
	[KodOperation] [smallint] NULL,
	[Razriad] [smallint] NULL,
	[Razriad_1] [smallint] NULL,
	[GrTarif] [smallint] NULL,
	[GrTarif_1] [smallint] NULL,
	[Vrednost] [float] NULL,
	[Vrednost_1] [float] NULL,
	[TimeOperation] [float] NULL,
	[TimeOperation_1] [float] NULL,
	[Rascenka] [float] NULL,
	[Rascenka_1] [float] NULL,
 CONSTRAINT [PK_Sravnenie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tabel]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tabel](
	[ExtNom] [int] IDENTITY(1,1) NOT NULL,
	[Moon] [smallint] NULL,
	[TabNomer] [int] NULL,
	[TimeFact] [smallint] NULL,
	[NormoVremia] [smallint] NULL,
	[SumAll] [float] NULL,
	[PrVip] [float] NULL,
	[KodOpl] [smallint] NULL,
 CONSTRAINT [PK_Tabel] PRIMARY KEY CLUSTERED 
(
	[ExtNom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TARIF]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TARIF](
	[Razriad] [smallint] NOT NULL,
	[Tarif1] [float] NULL,
	[Tarif] [float] NULL,
	[Tarif3] [float] NULL,
	[MTarif] [float] NULL,
 CONSTRAINT [PK_TARIF] PRIMARY KEY CLUSTERED 
(
	[Razriad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UchDet]    Script Date: 26.04.2024 15:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UchDet](
	[ExtNom] [int] IDENTITY(1,1) NOT NULL,
	[NomStr] [int] NULL,
	[KodOperation] [smallint] NULL,
	[NameOperation] [varchar](25) NULL,
	[KodDetal] [varchar](25) NULL,
	[NameDetal] [varchar](25) NULL,
	[Count] [float] NULL,
	[TabNomer] [int] NULL,
	[KodOpl] [smallint] NULL,
	[Moon] [smallint] NULL,
	[Day] [smallint] NULL,
	[Days] [date] NULL,
	[FIO] [varchar](25) NULL,
	[Uch] [smallint] NULL,
	[Ceh] [smallint] NULL,
 CONSTRAINT [PK_UchDet] PRIMARY KEY CLUSTERED 
(
	[ExtNom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Bnardstr]  WITH CHECK ADD  CONSTRAINT [FK_Bnardstr_Bnard] FOREIGN KEY([ExtNom])
REFERENCES [dbo].[Bnard] ([ExtNom])
GO
ALTER TABLE [dbo].[Bnardstr] CHECK CONSTRAINT [FK_Bnardstr_Bnard]
GO
ALTER TABLE [dbo].[Bnardstr]  WITH CHECK ADD  CONSTRAINT [FK_Bnardstr_ShifrDet] FOREIGN KEY([ShifrDetal])
REFERENCES [dbo].[ShifrDet] ([ShifrDetal])
GO
ALTER TABLE [dbo].[Bnardstr] CHECK CONSTRAINT [FK_Bnardstr_ShifrDet]
GO
ALTER TABLE [dbo].[BnardStr_Sproper]  WITH CHECK ADD  CONSTRAINT [FK_BnardStr_Sproper_Bnardstr] FOREIGN KEY([BnardStr_NomStr])
REFERENCES [dbo].[Bnardstr] ([NomStr])
GO
ALTER TABLE [dbo].[BnardStr_Sproper] CHECK CONSTRAINT [FK_BnardStr_Sproper_Bnardstr]
GO
ALTER TABLE [dbo].[BnardStr_Sproper]  WITH CHECK ADD  CONSTRAINT [FK_BnardStr_Sproper_Sproper] FOREIGN KEY([Sproper_NomStr])
REFERENCES [dbo].[Sproper] ([NomStr])
GO
ALTER TABLE [dbo].[BnardStr_Sproper] CHECK CONSTRAINT [FK_BnardStr_Sproper_Sproper]
GO
ALTER TABLE [dbo].[Brab]  WITH CHECK ADD  CONSTRAINT [FK_Brab_Bnard] FOREIGN KEY([ExtNom])
REFERENCES [dbo].[Bnard] ([ExtNom])
GO
ALTER TABLE [dbo].[Brab] CHECK CONSTRAINT [FK_Brab_Bnard]
GO
ALTER TABLE [dbo].[Brab]  WITH CHECK ADD  CONSTRAINT [FK_Brab_SPRRAB] FOREIGN KEY([TabNomer])
REFERENCES [dbo].[SPRRAB] ([TabNomer])
GO
ALTER TABLE [dbo].[Brab] CHECK CONSTRAINT [FK_Brab_SPRRAB]
GO
ALTER TABLE [dbo].[BRab_Korr]  WITH CHECK ADD  CONSTRAINT [FK_BRab_Korr_Tabel] FOREIGN KEY([ExtNom])
REFERENCES [dbo].[Tabel] ([ExtNom])
GO
ALTER TABLE [dbo].[BRab_Korr] CHECK CONSTRAINT [FK_BRab_Korr_Tabel]
GO
ALTER TABLE [dbo].[Kerna]  WITH CHECK ADD  CONSTRAINT [FK_Kerna_Sprdet] FOREIGN KEY([KodDetal])
REFERENCES [dbo].[Sprdet] ([KodDetal])
GO
ALTER TABLE [dbo].[Kerna] CHECK CONSTRAINT [FK_Kerna_Sprdet]
GO
ALTER TABLE [dbo].[Kerna]  WITH CHECK ADD  CONSTRAINT [FK_Kerna_SPRRAB] FOREIGN KEY([TabNomer])
REFERENCES [dbo].[SPRRAB] ([TabNomer])
GO
ALTER TABLE [dbo].[Kerna] CHECK CONSTRAINT [FK_Kerna_SPRRAB]
GO
ALTER TABLE [dbo].[KorUch]  WITH CHECK ADD  CONSTRAINT [FK_KorUch_Sprdet] FOREIGN KEY([KodDetal])
REFERENCES [dbo].[Sprdet] ([KodDetal])
GO
ALTER TABLE [dbo].[KorUch] CHECK CONSTRAINT [FK_KorUch_Sprdet]
GO
ALTER TABLE [dbo].[KorUch]  WITH CHECK ADD  CONSTRAINT [FK_KorUch_SPRRAB] FOREIGN KEY([TabNomer])
REFERENCES [dbo].[SPRRAB] ([TabNomer])
GO
ALTER TABLE [dbo].[KorUch] CHECK CONSTRAINT [FK_KorUch_SPRRAB]
GO
ALTER TABLE [dbo].[Nard]  WITH CHECK ADD  CONSTRAINT [FK_Nard_SPRRAB] FOREIGN KEY([TabNomer])
REFERENCES [dbo].[SPRRAB] ([TabNomer])
GO
ALTER TABLE [dbo].[Nard] CHECK CONSTRAINT [FK_Nard_SPRRAB]
GO
ALTER TABLE [dbo].[Nardstr]  WITH CHECK ADD  CONSTRAINT [FK_Nardstr_Nard] FOREIGN KEY([ExtNom])
REFERENCES [dbo].[Nard] ([ExtNom])
GO
ALTER TABLE [dbo].[Nardstr] CHECK CONSTRAINT [FK_Nardstr_Nard]
GO
ALTER TABLE [dbo].[Nardstr]  WITH CHECK ADD  CONSTRAINT [FK_Nardstr_ShifrDet] FOREIGN KEY([ShifrDetal])
REFERENCES [dbo].[ShifrDet] ([ShifrDetal])
GO
ALTER TABLE [dbo].[Nardstr] CHECK CONSTRAINT [FK_Nardstr_ShifrDet]
GO
ALTER TABLE [dbo].[NardStr_Sproper]  WITH CHECK ADD  CONSTRAINT [FK_NardStr_Sproper_Nardstr] FOREIGN KEY([NardStr_NomStr])
REFERENCES [dbo].[Nardstr] ([NomStr])
GO
ALTER TABLE [dbo].[NardStr_Sproper] CHECK CONSTRAINT [FK_NardStr_Sproper_Nardstr]
GO
ALTER TABLE [dbo].[NardStr_Sproper]  WITH CHECK ADD  CONSTRAINT [FK_NardStr_Sproper_Sproper] FOREIGN KEY([Sproper_NomStr])
REFERENCES [dbo].[Sproper] ([NomStr])
GO
ALTER TABLE [dbo].[NardStr_Sproper] CHECK CONSTRAINT [FK_NardStr_Sproper_Sproper]
GO
ALTER TABLE [dbo].[RoleAssignments]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ShifrDet]  WITH CHECK ADD  CONSTRAINT [FK_ShifrDet_Sprdet] FOREIGN KEY([KodDetal])
REFERENCES [dbo].[Sprdet] ([KodDetal])
GO
ALTER TABLE [dbo].[ShifrDet] CHECK CONSTRAINT [FK_ShifrDet_Sprdet]
GO
ALTER TABLE [dbo].[Sproper]  WITH CHECK ADD  CONSTRAINT [FK_Sproper_Sprdet] FOREIGN KEY([KodDetal])
REFERENCES [dbo].[Sprdet] ([KodDetal])
GO
ALTER TABLE [dbo].[Sproper] CHECK CONSTRAINT [FK_Sproper_Sprdet]
GO
ALTER TABLE [dbo].[Sproper]  WITH CHECK ADD  CONSTRAINT [FK_Sproper_TARIF] FOREIGN KEY([Razriad])
REFERENCES [dbo].[TARIF] ([Razriad])
GO
ALTER TABLE [dbo].[Sproper] CHECK CONSTRAINT [FK_Sproper_TARIF]
GO
ALTER TABLE [dbo].[SPRRAB]  WITH CHECK ADD  CONSTRAINT [FK_SPRRAB_PROFF] FOREIGN KEY([KodProfessii])
REFERENCES [dbo].[PROFF] ([KodProf])
GO
ALTER TABLE [dbo].[SPRRAB] CHECK CONSTRAINT [FK_SPRRAB_PROFF]
GO
ALTER TABLE [dbo].[Sravnenie]  WITH CHECK ADD  CONSTRAINT [FK_Sravnenie_Sprdet] FOREIGN KEY([KodDetal])
REFERENCES [dbo].[Sprdet] ([KodDetal])
GO
ALTER TABLE [dbo].[Sravnenie] CHECK CONSTRAINT [FK_Sravnenie_Sprdet]
GO
ALTER TABLE [dbo].[Sravnenie]  WITH CHECK ADD  CONSTRAINT [FK_Sravnenie_TARIF] FOREIGN KEY([Razriad])
REFERENCES [dbo].[TARIF] ([Razriad])
GO
ALTER TABLE [dbo].[Sravnenie] CHECK CONSTRAINT [FK_Sravnenie_TARIF]
GO
ALTER TABLE [dbo].[Tabel]  WITH CHECK ADD  CONSTRAINT [FK_Tabel_SPRRAB] FOREIGN KEY([TabNomer])
REFERENCES [dbo].[SPRRAB] ([TabNomer])
GO
ALTER TABLE [dbo].[Tabel] CHECK CONSTRAINT [FK_Tabel_SPRRAB]
GO
ALTER TABLE [dbo].[UchDet]  WITH CHECK ADD  CONSTRAINT [FK_UchDet_Nardstr] FOREIGN KEY([NomStr])
REFERENCES [dbo].[Nardstr] ([NomStr])
GO
ALTER TABLE [dbo].[UchDet] CHECK CONSTRAINT [FK_UchDet_Nardstr]
GO
ALTER TABLE [dbo].[UchDet]  WITH CHECK ADD  CONSTRAINT [FK_UchDet_Sprdet] FOREIGN KEY([KodDetal])
REFERENCES [dbo].[Sprdet] ([KodDetal])
GO
ALTER TABLE [dbo].[UchDet] CHECK CONSTRAINT [FK_UchDet_Sprdet]
GO
