USE [master]
GO
/****** Object:  Database [Interage]    Script Date: 04/08/2017 20:15:00 ******/
CREATE DATABASE [Interage]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Interage', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Interage.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Interage_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Interage_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Interage] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Interage].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Interage] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Interage] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Interage] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Interage] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Interage] SET ARITHABORT OFF 
GO
ALTER DATABASE [Interage] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Interage] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Interage] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Interage] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Interage] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Interage] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Interage] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Interage] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Interage] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Interage] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Interage] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Interage] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Interage] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Interage] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Interage] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Interage] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Interage] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Interage] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Interage] SET  MULTI_USER 
GO
ALTER DATABASE [Interage] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Interage] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Interage] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Interage] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Interage] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Interage]
GO
/****** Object:  Table [dbo].[AreaInteresse]    Script Date: 04/08/2017 20:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AreaInteresse](
	[Codigo] [int] NOT NULL,
	[Interesse] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Atividade]    Script Date: 04/08/2017 20:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Atividade](
	[Codigo] [int] NOT NULL,
	[CodEvento] [int] NOT NULL,
	[DescricaoAtividade] [varchar](255) NULL,
	[HorarioAtividade] [datetime] NOT NULL,
	[Endereco] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Evento]    Script Date: 04/08/2017 20:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Evento](
	[Codigo] [int] NOT NULL,
	[Nome] [varchar](45) NULL,
	[CodUsuario] [int] NOT NULL,
	[CPFUsuarioPromotor] [varchar](11) NOT NULL,
	[CodAreaInteresse] [int] NULL,
	[LocalizacaoLatitude] [decimal](18, 0) NULL,
	[LocalizacaoLogitude] [decimal](18, 0) NULL,
	[DataInicio] [datetime] NULL,
	[DataFim] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ExpositorAtividade]    Script Date: 04/08/2017 20:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ExpositorAtividade](
	[CodUsuario] [int] NOT NULL,
	[CPFExpositor] [varchar](11) NOT NULL,
	[CodAtividade] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CodUsuario] ASC,
	[CPFExpositor] ASC,
	[CodAtividade] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 04/08/2017 20:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Feedback](
	[CodEvento] [int] NOT NULL,
	[CodUsuario] [int] NOT NULL,
	[TipoFeedback] [varchar](45) NOT NULL,
	[Feedback] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CodEvento] ASC,
	[CodUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SalaDiscussao]    Script Date: 04/08/2017 20:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SalaDiscussao](
	[Codigo] [int] NOT NULL,
	[CodAtividade] [int] NOT NULL,
	[CodExpectador] [int] NOT NULL,
	[CPFExpectador] [varchar](11) NOT NULL,
	[Fechada] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 04/08/2017 20:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[Codigo] [int] NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Senha] [varchar](100) NOT NULL,
	[Email] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioExpectador]    Script Date: 04/08/2017 20:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UsuarioExpectador](
	[CodUsuario] [int] NOT NULL,
	[CPF] [varchar](11) NOT NULL,
	[PermiteInteragir] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[CodUsuario] ASC,
	[CPF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioExpositor]    Script Date: 04/08/2017 20:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UsuarioExpositor](
	[CodUsuario] [int] NOT NULL,
	[CPF] [varchar](11) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CodUsuario] ASC,
	[CPF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioInteresse]    Script Date: 04/08/2017 20:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UsuarioInteresse](
	[CodUsuario] [int] NOT NULL,
	[CPFUsuario] [varchar](11) NOT NULL,
	[CodInteresse] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CodUsuario] ASC,
	[CPFUsuario] ASC,
	[CodInteresse] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioPadrao]    Script Date: 04/08/2017 20:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UsuarioPadrao](
	[CodUsuario] [int] NOT NULL,
	[CPF] [varchar](11) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CodUsuario] ASC,
	[CPF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UsuarioPromotor]    Script Date: 04/08/2017 20:15:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UsuarioPromotor](
	[CodUsuario] [int] NOT NULL,
	[CPF] [varchar](11) NOT NULL,
	[Endereco] [varchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[CodUsuario] ASC,
	[CPF] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[AreaInteresse] ([Codigo], [Interesse]) VALUES (1, N'Area 1')
INSERT [dbo].[Evento] ([Codigo], [Nome], [CodUsuario], [CPFUsuarioPromotor], [CodAreaInteresse], [LocalizacaoLatitude], [LocalizacaoLogitude], [DataInicio], [DataFim]) VALUES (1, N'Evento 1', 1, N'1235645699', 1, CAST(5454 AS Decimal(18, 0)), CAST(7656 AS Decimal(18, 0)), CAST(N'2017-01-12 00:00:00.000' AS DateTime), CAST(N'2017-01-13 00:00:00.000' AS DateTime))
INSERT [dbo].[Feedback] ([CodEvento], [CodUsuario], [TipoFeedback], [Feedback]) VALUES (1, 1, N'Tipo 1', N'FEEDBACK PARA O EVENTO')
INSERT [dbo].[Usuario] ([Codigo], [Nome], [Senha], [Email]) VALUES (1, N'Usuario 1', N'senha', N'usuario@email.com')
INSERT [dbo].[UsuarioPromotor] ([CodUsuario], [CPF], [Endereco]) VALUES (1, N'1235645699', N'Endereço')
ALTER TABLE [dbo].[Atividade]  WITH CHECK ADD  CONSTRAINT [atividade_evento_fk] FOREIGN KEY([CodEvento])
REFERENCES [dbo].[Evento] ([Codigo])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Atividade] CHECK CONSTRAINT [atividade_evento_fk]
GO
ALTER TABLE [dbo].[Evento]  WITH CHECK ADD  CONSTRAINT [evento_areainteress_fk] FOREIGN KEY([CodAreaInteresse])
REFERENCES [dbo].[AreaInteresse] ([Codigo])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Evento] CHECK CONSTRAINT [evento_areainteress_fk]
GO
ALTER TABLE [dbo].[Evento]  WITH CHECK ADD  CONSTRAINT [evento_usuariopromotor_fk] FOREIGN KEY([CodUsuario], [CPFUsuarioPromotor])
REFERENCES [dbo].[UsuarioPromotor] ([CodUsuario], [CPF])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Evento] CHECK CONSTRAINT [evento_usuariopromotor_fk]
GO
ALTER TABLE [dbo].[ExpositorAtividade]  WITH CHECK ADD  CONSTRAINT [expositoratividade_atividade_fk] FOREIGN KEY([CodAtividade])
REFERENCES [dbo].[Atividade] ([Codigo])
GO
ALTER TABLE [dbo].[ExpositorAtividade] CHECK CONSTRAINT [expositoratividade_atividade_fk]
GO
ALTER TABLE [dbo].[ExpositorAtividade]  WITH CHECK ADD  CONSTRAINT [expositoratividade_usuarioexpositor_fk] FOREIGN KEY([CodUsuario], [CPFExpositor])
REFERENCES [dbo].[UsuarioExpositor] ([CodUsuario], [CPF])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[ExpositorAtividade] CHECK CONSTRAINT [expositoratividade_usuarioexpositor_fk]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [feedback_evento_fk] FOREIGN KEY([CodEvento])
REFERENCES [dbo].[Evento] ([Codigo])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [feedback_evento_fk]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [feedback_usuario_fk] FOREIGN KEY([CodUsuario])
REFERENCES [dbo].[Usuario] ([Codigo])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [feedback_usuario_fk]
GO
ALTER TABLE [dbo].[SalaDiscussao]  WITH CHECK ADD  CONSTRAINT [saladiscussao_atividade_fk] FOREIGN KEY([CodAtividade])
REFERENCES [dbo].[Atividade] ([Codigo])
GO
ALTER TABLE [dbo].[SalaDiscussao] CHECK CONSTRAINT [saladiscussao_atividade_fk]
GO
ALTER TABLE [dbo].[SalaDiscussao]  WITH CHECK ADD  CONSTRAINT [saladiscussao_usuarioexpectador_fk] FOREIGN KEY([CodExpectador], [CPFExpectador])
REFERENCES [dbo].[UsuarioExpectador] ([CodUsuario], [CPF])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[SalaDiscussao] CHECK CONSTRAINT [saladiscussao_usuarioexpectador_fk]
GO
ALTER TABLE [dbo].[UsuarioExpectador]  WITH CHECK ADD  CONSTRAINT [usuarioexpectador_usuariopadrao_fk] FOREIGN KEY([CodUsuario], [CPF])
REFERENCES [dbo].[UsuarioPadrao] ([CodUsuario], [CPF])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[UsuarioExpectador] CHECK CONSTRAINT [usuarioexpectador_usuariopadrao_fk]
GO
ALTER TABLE [dbo].[UsuarioExpositor]  WITH CHECK ADD  CONSTRAINT [usuarioexpositor_usuariopadrao_fk] FOREIGN KEY([CodUsuario], [CPF])
REFERENCES [dbo].[UsuarioPadrao] ([CodUsuario], [CPF])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[UsuarioExpositor] CHECK CONSTRAINT [usuarioexpositor_usuariopadrao_fk]
GO
ALTER TABLE [dbo].[UsuarioInteresse]  WITH CHECK ADD  CONSTRAINT [usuariointeresse_areainteresse_fk] FOREIGN KEY([CodInteresse])
REFERENCES [dbo].[AreaInteresse] ([Codigo])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[UsuarioInteresse] CHECK CONSTRAINT [usuariointeresse_areainteresse_fk]
GO
ALTER TABLE [dbo].[UsuarioInteresse]  WITH CHECK ADD  CONSTRAINT [usuariointeresse_usuariopadrao_fk] FOREIGN KEY([CodUsuario], [CPFUsuario])
REFERENCES [dbo].[UsuarioPadrao] ([CodUsuario], [CPF])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[UsuarioInteresse] CHECK CONSTRAINT [usuariointeresse_usuariopadrao_fk]
GO
ALTER TABLE [dbo].[UsuarioPadrao]  WITH CHECK ADD  CONSTRAINT [usuariopadrao_usuario_fk] FOREIGN KEY([CodUsuario])
REFERENCES [dbo].[Usuario] ([Codigo])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[UsuarioPadrao] CHECK CONSTRAINT [usuariopadrao_usuario_fk]
GO
ALTER TABLE [dbo].[UsuarioPromotor]  WITH CHECK ADD  CONSTRAINT [usuariopromotor_usuario_fk] FOREIGN KEY([CodUsuario])
REFERENCES [dbo].[Usuario] ([Codigo])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[UsuarioPromotor] CHECK CONSTRAINT [usuariopromotor_usuario_fk]
GO
USE [master]
GO
ALTER DATABASE [Interage] SET  READ_WRITE 
GO
