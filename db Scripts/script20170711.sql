USE [master]
GO
/****** Object:  Database [MusicFarmer]    Script Date: 2017/07/11 8:03:51 PM ******/
CREATE DATABASE [MusicFarmer]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MusicFarmer', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\MusicFarmer.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MusicFarmer_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\MusicFarmer_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MusicFarmer] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MusicFarmer].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MusicFarmer] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MusicFarmer] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MusicFarmer] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MusicFarmer] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MusicFarmer] SET ARITHABORT OFF 
GO
ALTER DATABASE [MusicFarmer] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MusicFarmer] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MusicFarmer] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MusicFarmer] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MusicFarmer] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MusicFarmer] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MusicFarmer] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MusicFarmer] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MusicFarmer] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MusicFarmer] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MusicFarmer] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MusicFarmer] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MusicFarmer] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MusicFarmer] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MusicFarmer] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MusicFarmer] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MusicFarmer] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MusicFarmer] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MusicFarmer] SET  MULTI_USER 
GO
ALTER DATABASE [MusicFarmer] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MusicFarmer] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MusicFarmer] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MusicFarmer] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MusicFarmer] SET DELAYED_DURABILITY = DISABLED 
GO
USE [MusicFarmer]
GO
/****** Object:  Table [dbo].[Album]    Script Date: 2017/07/11 8:03:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Album](
	[AlbumId] [int] IDENTITY(1,1) NOT NULL,
	[AlbumName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_album] PRIMARY KEY CLUSTERED 
(
	[AlbumId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Artist]    Script Date: 2017/07/11 8:03:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Artist](
	[ArtistId] [int] IDENTITY(1,1) NOT NULL,
	[ArtistName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_artist] PRIMARY KEY CLUSTERED 
(
	[ArtistId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AuditLog]    Script Date: 2017/07/11 8:03:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditLog](
	[AuditLogId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nchar](100) NOT NULL,
	[EventDateUTC] [datetime] NOT NULL,
	[EventType] [int] NOT NULL,
	[TableName] [nchar](100) NOT NULL,
	[RecordId] [int] NOT NULL,
 CONSTRAINT [PK_AuditLogs] PRIMARY KEY CLUSTERED 
(
	[AuditLogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AuditLogDetail]    Script Date: 2017/07/11 8:03:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditLogDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ColumnName] [nchar](100) NOT NULL,
	[OriginalValue] [nchar](255) NOT NULL,
	[NewValue] [nchar](255) NOT NULL,
	[AuditLogId] [int] NOT NULL,
 CONSTRAINT [PK_AuditLogDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comment]    Script Date: 2017/07/11 8:03:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentId] [int] IDENTITY(1,1) NOT NULL,
	[PlayHistoryId] [int] NOT NULL,
	[CommentText] [varchar](255) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_comments] PRIMARY KEY CLUSTERED 
(
	[CommentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Favourite]    Script Date: 2017/07/11 8:03:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favourite](
	[FavouriteId] [int] IDENTITY(1,1) NOT NULL,
	[TrackId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Favourite] PRIMARY KEY CLUSTERED 
(
	[FavouriteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PlayHistory]    Script Date: 2017/07/11 8:03:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlayHistory](
	[PlayHistoryId] [int] IDENTITY(1,1) NOT NULL,
	[TrackId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[TimePlayed] [timestamp] NOT NULL,
	[PlayCompleted] [bit] NOT NULL CONSTRAINT [DF_play_history_play_completed]  DEFAULT ((0)),
	[IsPlaying] [bit] NOT NULL CONSTRAINT [DF_PlayHistory_IsPlaying]  DEFAULT ((0)),
 CONSTRAINT [PK_play_history] PRIMARY KEY CLUSTERED 
(
	[PlayHistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SettingValue]    Script Date: 2017/07/11 8:03:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SettingValue](
	[SettingValueId] [int] NOT NULL,
	[SettingName] [varchar](50) NOT NULL,
	[SettingValue] [int] NOT NULL,
	[DataType] [int] NOT NULL CONSTRAINT [DF_SettingValue_DataType]  DEFAULT ((1)),
	[Active] [bit] NOT NULL CONSTRAINT [DF_SettingValue_Active]  DEFAULT ((1)),
 CONSTRAINT [PK_SettingValue] PRIMARY KEY CLUSTERED 
(
	[SettingValueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Track]    Script Date: 2017/07/11 8:03:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Track](
	[TrackId] [int] IDENTITY(1,1) NOT NULL,
	[TrackName] [varchar](100) NOT NULL,
	[ArtistId] [int] NULL,
	[AlbumId] [int] NULL,
	[TrackURL] [varchar](255) NULL,
	[UploadTime] [timestamp] NULL,
 CONSTRAINT [PK_track] PRIMARY KEY CLUSTERED 
(
	[TrackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 2017/07/11 8:03:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](255) NOT NULL,
	[Active] [bit] NOT NULL CONSTRAINT [DF_users_active]  DEFAULT ((1)),
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vote]    Script Date: 2017/07/11 8:03:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vote](
	[VoteId] [int] IDENTITY(1,1) NOT NULL,
	[VoteValue] [bit] NOT NULL,
	[UserId] [int] NOT NULL,
	[PlayHistoryId] [int] NOT NULL,
 CONSTRAINT [PK_votes] PRIMARY KEY CLUSTERED 
(
	[VoteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AuditLogDetail]  WITH CHECK ADD  CONSTRAINT [FK_AuditLogDetails_AuditLogs] FOREIGN KEY([AuditLogId])
REFERENCES [dbo].[AuditLog] ([AuditLogId])
GO
ALTER TABLE [dbo].[AuditLogDetail] CHECK CONSTRAINT [FK_AuditLogDetails_AuditLogs]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_comments_play_history] FOREIGN KEY([PlayHistoryId])
REFERENCES [dbo].[PlayHistory] ([PlayHistoryId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_comments_play_history]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_comments_users] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_comments_users]
GO
ALTER TABLE [dbo].[Favourite]  WITH CHECK ADD  CONSTRAINT [FK_Favourite_Track] FOREIGN KEY([TrackId])
REFERENCES [dbo].[Track] ([TrackId])
GO
ALTER TABLE [dbo].[Favourite] CHECK CONSTRAINT [FK_Favourite_Track]
GO
ALTER TABLE [dbo].[Favourite]  WITH CHECK ADD  CONSTRAINT [FK_Favourite_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Favourite] CHECK CONSTRAINT [FK_Favourite_User]
GO
ALTER TABLE [dbo].[PlayHistory]  WITH CHECK ADD  CONSTRAINT [FK_play_history_track] FOREIGN KEY([TrackId])
REFERENCES [dbo].[Track] ([TrackId])
GO
ALTER TABLE [dbo].[PlayHistory] CHECK CONSTRAINT [FK_play_history_track]
GO
ALTER TABLE [dbo].[PlayHistory]  WITH CHECK ADD  CONSTRAINT [FK_play_history_users] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[PlayHistory] CHECK CONSTRAINT [FK_play_history_users]
GO
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK_track_album] FOREIGN KEY([AlbumId])
REFERENCES [dbo].[Album] ([AlbumId])
ON UPDATE SET NULL
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK_track_album]
GO
ALTER TABLE [dbo].[Track]  WITH CHECK ADD  CONSTRAINT [FK_track_artist] FOREIGN KEY([ArtistId])
REFERENCES [dbo].[Artist] ([ArtistId])
ON UPDATE SET NULL
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Track] CHECK CONSTRAINT [FK_track_artist]
GO
ALTER TABLE [dbo].[Vote]  WITH CHECK ADD  CONSTRAINT [FK_Vote_PlayHistory] FOREIGN KEY([PlayHistoryId])
REFERENCES [dbo].[PlayHistory] ([PlayHistoryId])
GO
ALTER TABLE [dbo].[Vote] CHECK CONSTRAINT [FK_Vote_PlayHistory]
GO
ALTER TABLE [dbo].[Vote]  WITH CHECK ADD  CONSTRAINT [FK_votes_users] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Vote] CHECK CONSTRAINT [FK_votes_users]
GO
/****** Object:  StoredProcedure [dbo].[JukeBoxTracks]    Script Date: 2017/07/11 8:03:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[JukeBoxTracks]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT t.TrackId,t.TrackName, COALESCE(sum(CASE WHEN v.VoteValue=1 THEN 1 ELSE CASE WHEN v.VoteValue=0 THEN -1 END END),0) as Votes, count(f.TrackId) As Favourites, count(ph.PlayHistoryId) as Played
  From Track t
  LEFT JOIN PlayHistory ph on ph.TrackId = t.TrackId
  LEFT JOIN vote v on v.PlayHistoryId = ph.PlayHistoryId
  LEFT JOIN Favourite f on f.TrackId = t.TrackId
  GROUP BY t.TrackId,t.TrackName
  ORDER BY COALESCE(sum(CASE WHEN v.VoteValue=1 THEN 1 ELSE CASE WHEN v.VoteValue=0 THEN -1 END END),0) DESC, count(f.TrackId) DESC, count(ph.PlayHistoryId)
END


GO
/****** Object:  StoredProcedure [dbo].[StopAllTracksFromPlaying]    Script Date: 2017/07/11 8:03:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[StopAllTracksFromPlaying]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update playhistory set IsPlaying = 0, PlayCompleted = 1
END


GO
USE [master]
GO
ALTER DATABASE [MusicFarmer] SET  READ_WRITE 
GO
