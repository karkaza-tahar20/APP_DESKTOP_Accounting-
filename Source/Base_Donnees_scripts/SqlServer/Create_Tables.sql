USE [SharpComptaBase]

GO
CREATE TABLE [dbo].[Dossier](
	[IDDossier] [int] NOT NULL,
	[RaisonSocial] [nvarchar](50) NULL,
	[Annee] [int] NULL,
 CONSTRAINT [PK_Dossier] PRIMARY KEY CLUSTERED 
(
	[IDDossier] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ecritures](
	[IdEcriture] [bigint] IDENTITY(1,1) NOT NULL,
	[iDate] [int] NULL,
	[Compte] [int] NULL,
	[ContrePartie] [int] NULL,
	[N_Ordre] [bigint] NULL,
	[Libelle] [nvarchar](50) NULL,
	[Debit] [bit] NULL,
	[Montant] [float] NULL,
	[CodeJournal] [int] NULL,
	[Annee] [nvarchar](50) NULL,
	[JourMois] [nvarchar](50) NULL,
	[CodeLibelleAutomatique] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEcriture] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comptes]    Script Date: 09/15/2016 09:47:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comptes](
	[Compte] [int] NOT NULL,
	[Intitule] [nvarchar](50) NULL,
	[Niveau] [tinyint] NULL,
	[MouvementDebit] [float] NULL,
	[MouvementCredit] [float] NULL,
	[CompteResultat] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Compte] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Journaux]    Script Date: 09/15/2016 09:47:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Journaux](
	[Code] [int] NOT NULL,
	[Intitule] [nvarchar](50) NULL,
	[Compte] [int] NULL,
	[Cpa] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LibellesAutomatiques]    Script Date: 09/15/2016 09:47:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LibellesAutomatiques](
	[Code] [int] NOT NULL,
	[Intitule] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
