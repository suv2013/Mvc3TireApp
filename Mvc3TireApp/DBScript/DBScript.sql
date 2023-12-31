USE [MvcTestingDb]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 04-03-2019 04:04:20 PM ******/
DROP TABLE [dbo].[Users]
GO
/****** Object:  StoredProcedure [dbo].[Update_Users]    Script Date: 04-03-2019 04:04:20 PM ******/
DROP PROCEDURE [dbo].[Update_Users]
GO
/****** Object:  StoredProcedure [dbo].[Select_Users]    Script Date: 04-03-2019 04:04:20 PM ******/
DROP PROCEDURE [dbo].[Select_Users]
GO
/****** Object:  StoredProcedure [dbo].[Insert_Users]    Script Date: 04-03-2019 04:04:20 PM ******/
DROP PROCEDURE [dbo].[Insert_Users]
GO
/****** Object:  StoredProcedure [dbo].[Delete_Users]    Script Date: 04-03-2019 04:04:20 PM ******/
DROP PROCEDURE [dbo].[Delete_Users]
GO
USE [master]
GO
/****** Object:  Database [MvcTestingDb]    Script Date: 04-03-2019 04:04:20 PM ******/
DROP DATABASE [MvcTestingDb]
GO
/****** Object:  Database [MvcTestingDb]    Script Date: 04-03-2019 04:04:20 PM ******/
CREATE DATABASE [MvcTestingDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MvcTestingDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\MvcTestingDb.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MvcTestingDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\MvcTestingDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MvcTestingDb] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MvcTestingDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MvcTestingDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MvcTestingDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MvcTestingDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MvcTestingDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MvcTestingDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [MvcTestingDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MvcTestingDb] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [MvcTestingDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MvcTestingDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MvcTestingDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MvcTestingDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MvcTestingDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MvcTestingDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MvcTestingDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MvcTestingDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MvcTestingDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MvcTestingDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MvcTestingDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MvcTestingDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MvcTestingDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MvcTestingDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MvcTestingDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MvcTestingDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MvcTestingDb] SET RECOVERY FULL 
GO
ALTER DATABASE [MvcTestingDb] SET  MULTI_USER 
GO
ALTER DATABASE [MvcTestingDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MvcTestingDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MvcTestingDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MvcTestingDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'MvcTestingDb', N'ON'
GO
USE [MvcTestingDb]
GO
/****** Object:  StoredProcedure [dbo].[Delete_Users]    Script Date: 04-03-2019 04:04:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Delete_Users] (
@UserName nvarchar(50)
)
as
Begin
		begin try
		begin tran
			Delete from [dbo].[Users] where UserName = @UserName
			commit
		Select 'Success'
		end try

	begin catch
		 rollback tran
		 select ERROR_MESSAGE()
	end catch
		End
	

GO
/****** Object:  StoredProcedure [dbo].[Insert_Users]    Script Date: 04-03-2019 04:04:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Insert_Users] (
@UserName nvarchar(5)
,@Password nvarchar(5)
,@Name  nvarchar(50)
,@MailId  nvarchar(50)
)
as
begin
	
	begin try
	begin tran
		
				insert into dbo.Users (UserName,Password,Name,MailId) values
				(@UserName ,@Password, @Name, @MailId )

	commit
	Select 'Success'
	end try

	begin catch
	 rollback tran
	 select ERROR_MESSAGE()
	end catch
end

GO
/****** Object:  StoredProcedure [dbo].[Select_Users]    Script Date: 04-03-2019 04:04:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Select_Users] (
@UserName nvarchar(50)
)
as
begin
	
	if(@UserName != NULL)
		Begin
			Select * from [dbo].[Users] where UserName = @UserName
		End
	Else
		Begin
			Select * from [dbo].[Users] 
		End

end

GO
/****** Object:  StoredProcedure [dbo].[Update_Users]    Script Date: 04-03-2019 04:04:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[Update_Users] (
@UserName nvarchar(5)
,@Password nvarchar(5)
,@Name  nvarchar(50)
,@MailId  nvarchar(50)
)
as
begin
	
	begin try
	begin tran
		
				update dbo.Users set Password=@Password,Name=@Name,MailId=@MailId  where UserName=@UserName
	commit
	Select 'Success'
	end try

	begin catch
	 rollback tran
	 select ERROR_MESSAGE()
	end catch
end

GO
/****** Object:  Table [dbo].[Users]    Script Date: 04-03-2019 04:04:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[rowid] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](500) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[MailId] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

GO
INSERT [dbo].[Users] ([rowid], [UserName], [Password], [Name], [MailId]) VALUES (1, N'Suv', N'123', N'Subhra', N's@a.com')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
USE [master]
GO
ALTER DATABASE [MvcTestingDb] SET  READ_WRITE 
GO
