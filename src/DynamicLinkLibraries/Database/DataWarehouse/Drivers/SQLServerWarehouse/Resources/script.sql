USE [master]
GO
/****** Object:  Database [AstronomyExpress]    Script Date: 1/17/2022 7:46:01 PM ******/
CREATE DATABASE [AstronomyExpress]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AstronomyExpress', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\AstronomyExpress.mdf' , SIZE = 100032KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AstronomyExpress_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\AstronomyExpress_1.ldf' , SIZE = 29504KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AstronomyExpress] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AstronomyExpress].[dbo].[sp_fulltext_database] @action = 'disable'
end
GO
ALTER DATABASE [AstronomyExpress] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AstronomyExpress] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AstronomyExpress] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AstronomyExpress] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AstronomyExpress] SET ARITHABORT OFF 
GO
ALTER DATABASE [AstronomyExpress] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AstronomyExpress] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AstronomyExpress] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AstronomyExpress] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AstronomyExpress] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AstronomyExpress] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AstronomyExpress] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AstronomyExpress] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AstronomyExpress] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AstronomyExpress] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AstronomyExpress] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AstronomyExpress] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AstronomyExpress] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AstronomyExpress] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AstronomyExpress] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AstronomyExpress] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AstronomyExpress] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AstronomyExpress] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AstronomyExpress] SET  MULTI_USER 
GO
ALTER DATABASE [AstronomyExpress] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AstronomyExpress] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AstronomyExpress] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AstronomyExpress] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [AstronomyExpress] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AstronomyExpress] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [AstronomyExpress] SET QUERY_STORE = OFF
GO
USE [AstronomyExpress]
GO
/****** Object:  Table [dbo].[BinaryTable]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BinaryTable](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[ParentId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](300) NOT NULL,
	[Data] [image] NOT NULL,
	[Length] [nvarchar](30) NOT NULL,
	[Ext] [varchar](10) NOT NULL,
 CONSTRAINT [PK_BinaryTable] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[ViewBinaryTableInfo]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewBinaryTableInfo]
AS
SELECT Id, ParentId, Name, Description, Ext
FROM     dbo.BinaryTable
GO
/****** Object:  View [dbo].[ViewBinaryTreeId]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewBinaryTreeId]
AS
SELECT Id, ParentId, Name, Description, Ext
FROM     dbo.BinaryTable
GO
/****** Object:  View [dbo].[ViewBinaryTableId]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ViewBinaryTableId]
AS
SELECT     Id
FROM         dbo.BinaryTable
GO
/****** Object:  Table [dbo].[BinaryTree]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BinaryTree](
	[Id] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[ParentId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](300) NOT NULL,
	[ext] [char](10) NOT NULL,
 CONSTRAINT [PK_BinaryTree] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BinaryTable] ADD  CONSTRAINT [DF_BinaryTable_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[BinaryTree] ADD  CONSTRAINT [DF_BinaryTree_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[BinaryTable]  WITH CHECK ADD  CONSTRAINT [FK_BinaryTable_BinaryTree] FOREIGN KEY([ParentId])
REFERENCES [dbo].[BinaryTree] ([Id])
GO
ALTER TABLE [dbo].[BinaryTable] CHECK CONSTRAINT [FK_BinaryTable_BinaryTree]
GO
ALTER TABLE [dbo].[BinaryTree]  WITH CHECK ADD  CONSTRAINT [FK_BinaryTree_BinaryTree] FOREIGN KEY([ParentId])
REFERENCES [dbo].[BinaryTree] ([Id])
GO
ALTER TABLE [dbo].[BinaryTree] CHECK CONSTRAINT [FK_BinaryTree_BinaryTree]
GO
/****** Object:  StoredProcedure [dbo].[DeleteBinary]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteBinary]
(
	@Id UNIQUEIDENTIFIER
)
AS
BEGIN
DELETE FROM BinaryTable WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteBinaryTree]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteBinaryTree]
(
	@Id UNIQUEIDENTIFIER
)
AS
BEGIN
DELETE FROM BinaryTree WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[InsertBinary]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertBinary]
	(
	@ParentId UNIQUEIDENTIFIER,
	@Name NVARCHAR(50),
	@Description NVARCHAR(300),
	@Data IMAGE,
	@Ext CHAR(10)
	)
AS
BEGIN
DECLARE @TID AS UNIQUEIDENTIFIER
SET @TID = NEWID()
IF (SELECT COUNT(*) FROM BinaryTable WHERE @ParentID = ParentID AND @Name = Name) > 0
RETURN(1)
INSERT INTO BinaryTable (Id, ParentId, Name, Description, Data, Length, ext) VALUES(@TID, @ParentId, @Name, @Description, @Data, DATALENGTH(@Data), @Ext) 
SELECT Id FROM ViewBinaryTableId WHERE @TID = Id

END
GO
/****** Object:  StoredProcedure [dbo].[InsertBinaryInterface]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertBinaryInterface] 
	(
	@ParentId UNIQUEIDENTIFIER,
	@Name NVARCHAR(50),
	@Description NVARCHAR(300),
	@Data IMAGE,
	@Length INTEGER,
	@Ext CHAR(10),
	@InterfaceName varchar(100)
	)
AS
BEGIN
	IF NOT dbo.CheckInterface(@Data, @InterfaceName) = 0 
	BEGIN
		EXECUTE dbo.InsertBinary @ParentId, @Name, @Description, @Data , @Length, @Ext
		RETURN 0
	END
	ELSE
	BEGIN
		RETURN 1
	END	
END
GO
/****** Object:  StoredProcedure [dbo].[InsertBinaryNode]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertBinaryNode]
(
@ParentId UNIQUEIDENTIFIER,
@NAME NVARCHAR(50),
@Description NVARCHAR(300),
@ext CHAR(10)
)
AS
BEGIN
DECLARE @TID AS UNIQUEIDENTIFIER

SET @TID = NEWID()

IF (SELECT COUNT(*) FROM BinaryTree WHERE @ParentID = ParentID AND @Name = Name) > 0
RETURN(1)
INSERT INTO BinaryTree (Id, ParentId, Name, Description, ext) VALUES(@TID, @ParentId, @Name, @Description, @Ext) 
SELECT Id FROM ViewBinaryTreeId WHERE @TID = Id


END
GO
/****** Object:  StoredProcedure [dbo].[InsertTree]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertTree]
	(
	@ParentId UNIQUEIDENTIFIER,
	@Name NVARCHAR(50),
	@Description NVARCHAR(300),
	@Ext CHAR(10)
	)
AS
BEGIN
DECLARE @TID AS UNIQUEIDENTIFIER
SET @TID = NEWID()
IF (SELECT COUNT(*) FROM BinaryTree WHERE @ParentID = ParentID AND @Name = Name) > 0
RETURN(1)
INSERT INTO BinaryTree (Id, ParentId, Name, Description, ext) VALUES(@TID, @ParentId, @Name, @Description,  @Ext) 
SELECT Id FROM ViewBinaryTreeId WHERE @TID = Id
END
GO
/****** Object:  StoredProcedure [dbo].[SelectBinary]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectBinary]
(
@Id UNIQUEIDENTIFIER
)

AS
BEGIN
SELECT Data, Ext FROM BinaryTable where Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[SelectBinaryContents]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectBinaryContents]
	(
	@Ext varchar(10)
	)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id, Name, Description, Length FROM BinaryTable WHERE Ext = @Ext
END
GO
/****** Object:  StoredProcedure [dbo].[SelectBinaryTable]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectBinaryTable]
AS
BEGIN
SELECT Id, ParentId, Name, Description, Ext FROM BinaryTable
END
GO
/****** Object:  StoredProcedure [dbo].[SelectBinaryTree]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SelectBinaryTree]
AS
BEGIN
SELECT * FROM BinaryTree
END
GO
/****** Object:  StoredProcedure [dbo].[sp_alterdiagram]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_alterdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null,
		@version 	int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId 			int
		declare @retval 		int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @ShouldChangeUID	int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid ARG', 16, 1)
			return -1
		end
	
		execute as caller
		select @theId = DATABASE_PRINCIPAL_ID()	 
		select @IsDbo = IS_MEMBER(N'db_owner') 
		if(@owner_id is null)
			select @owner_id = @theId
		revert
	
		select @ShouldChangeUID = 0
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		
		if(@DiagId IS NULL or (@IsDbo = 0 and @theId <> @UIDFound))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end
	
		if(@IsDbo <> 0)
		begin
			if(@UIDFound is null or USER_NAME(@UIDFound) is null) -- invalid principal_id
			begin
				select @ShouldChangeUID = 1 ;
			end
		end

		-- update dds data			
		update dbo.sysdiagrams set definition = @definition where diagram_id = @DiagId ;

		-- change owner
		if(@ShouldChangeUID = 1)
			update dbo.sysdiagrams set principal_id = @theId where diagram_id = @DiagId ;

		-- update dds version
		if(@version is not null)
			update dbo.sysdiagrams set version = @version where diagram_id = @DiagId ;

		return 0
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_creatediagram]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_creatediagram]
	(
		@diagramname 	sysname,
		@owner_id		int	= null, 	
		@version 		int,
		@definition 	varbinary(max)
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
	
		declare @theId int
		declare @retval int
		declare @IsDbo	int
		declare @userName sysname
		if(@version is null or @diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller
		select @theId = DATABASE_PRINCIPAL_ID() 
		select @IsDbo = IS_MEMBER(N'db_owner')
		revert 
		
		if @owner_id is null
		begin
			select @owner_id = @theId;
		end
		else
		begin
			if @theId <> @owner_id
			begin
				if @IsDbo = 0
				begin
					RAISERROR (N'E_INVALIDARG', 16, 1);
					return -1
				end
				select @theId = @owner_id
			end
		end
		-- next 2 line only for test, will be removed after define name unique
		if EXISTS(select diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @diagramname)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end
	
		insert into dbo.sysdiagrams(name, principal_id , version, definition)
				VALUES(@diagramname, @theId, @version, @definition) ;
		
		select @retval = @@IDENTITY 
		return @retval
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_dropdiagram]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_dropdiagram]
	(
		@diagramname 	sysname,
		@owner_id	int	= null
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
	
		if(@diagramname is null)
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER
		select @theId = DATABASE_PRINCIPAL_ID()	-- UNDONE: more work 
		select @IsDbo = IS_MEMBER(N'db_owner') 
		if(@owner_id is null)
			select @owner_id = @theId
		REVERT 
		
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		delete from dbo.sysdiagrams where diagram_id = @DiagId;
	
		return 0;
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_helpdiagramdefinition]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_helpdiagramdefinition]
	(
		@diagramname 	sysname,
		@owner_id	int	= null 		
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		set nocount on

		declare @theId 		int
		declare @IsDbo 		int
		declare @DiagId		int
		declare @UIDFound	int
	
		if(@diagramname is null)
		begin
			RAISERROR (N'E_INVALIDARG', 16, 1);
			return -1
		end
	
		execute as caller
		select @theId = DATABASE_PRINCIPAL_ID()
		select @IsDbo = IS_MEMBER(N'db_owner')
		if(@owner_id is null)
			select @owner_id = @theId
		revert 
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname;
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId ))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);
			return -3
		end

		select version, definition FROM dbo.sysdiagrams where diagram_id = @DiagId ; 
		return 0
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_helpdiagrams]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_helpdiagrams]
	(
		@diagramname sysname = NULL,
		@owner_id int = NULL
	)
	WITH EXECUTE AS N'dbo'
	AS
	BEGIN
		DECLARE @user sysname
		DECLARE @dboLogin bit
		EXECUTE AS CALLER
			SET @user = USER_NAME()
			SET @dboLogin = CONVERT(bit,IS_MEMBER('db_owner'))
		REVERT
		SELECT
			[Database] = DB_NAME(),
			[Name] = name,
			[ID] = diagram_id,
			[Owner] = USER_NAME(principal_id),
			[OwnerID] = principal_id
		FROM
			sysdiagrams
		WHERE
			(@dboLogin = 1 OR USER_NAME(principal_id) = @user) AND
			(@diagramname IS NULL OR name = @diagramname) AND
			(@owner_id IS NULL OR principal_id = @owner_id)
		ORDER BY
			4, 5, 1
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_renamediagram]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_renamediagram]
	(
		@diagramname 		sysname,
		@owner_id		int	= null,
		@new_diagramname	sysname
	
	)
	WITH EXECUTE AS 'dbo'
	AS
	BEGIN
		set nocount on
		declare @theId 			int
		declare @IsDbo 			int
		
		declare @UIDFound 		int
		declare @DiagId			int
		declare @DiagIdTarg		int
		declare @u_name			sysname
		if((@diagramname is null) or (@new_diagramname is null))
		begin
			RAISERROR ('Invalid value', 16, 1);
			return -1
		end
	
		EXECUTE AS CALLER
		select @theId = DATABASE_PRINCIPAL_ID()
		select @IsDbo = IS_MEMBER(N'db_owner') 
		if(@owner_id is null)
			select @owner_id = @theId
		REVERT
	
		select @u_name = USER_NAME(@owner_id)
	
		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 
		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))
		begin
			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)
			return -3
		end
	
		-- if((@u_name is not null) and (@new_diagramname = @diagramname))	-- nothing will change
		--	return 0;
	
		if(@u_name is null)
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @new_diagramname
		else
			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @owner_id and name = @new_diagramname
	
		if((@DiagIdTarg is not null) and  @DiagId <> @DiagIdTarg)
		begin
			RAISERROR ('The name is already used.', 16, 1);
			return -2
		end		
	
		if(@u_name is null)
			update dbo.sysdiagrams set [name] = @new_diagramname, principal_id = @theId where diagram_id = @DiagId
		else
			update dbo.sysdiagrams set [name] = @new_diagramname where diagram_id = @DiagId
		return 0
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_upgraddiagrams]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_upgraddiagrams]
	AS
	BEGIN
		IF OBJECT_ID(N'dbo.sysdiagrams') IS NOT NULL
			return 0;
	
		CREATE TABLE dbo.sysdiagrams
		(
			name sysname NOT NULL,
			principal_id int NOT NULL,	-- we may change it to varbinary(85)
			diagram_id int PRIMARY KEY IDENTITY,
			version int,
	
			definition varbinary(max)
			CONSTRAINT UK_principal_name UNIQUE
			(
				principal_id,
				name
			)
		);


		/* Add this if we need to have some form of extended properties for diagrams */
		/*
		IF OBJECT_ID(N'dbo.sysdiagram_properties') IS NULL
		BEGIN
			CREATE TABLE dbo.sysdiagram_properties
			(
				diagram_id int,
				name sysname,
				value varbinary(max) NOT NULL
			)
		END
		*/

		IF OBJECT_ID(N'dbo.dtproperties') IS NOT NULL
		begin
			insert into dbo.sysdiagrams
			(
				[name],
				[principal_id],
				[version],
				[definition]
			)
			select	 
				convert(sysname, dgnm.[uvalue]),
				DATABASE_PRINCIPAL_ID(N'dbo'),			-- will change to the sid of sa
				0,							-- zero for old format, dgdef.[version],
				dgdef.[lvalue]
			from dbo.[dtproperties] dgnm
				inner join dbo.[dtproperties] dggd on dggd.[property] = 'DtgSchemaGUID' and dggd.[objectid] = dgnm.[objectid]	
				inner join dbo.[dtproperties] dgdef on dgdef.[property] = 'DtgSchemaDATA' and dgdef.[objectid] = dgnm.[objectid]
				
			where dgnm.[property] = 'DtgSchemaNAME' and dggd.[uvalue] like N'_EA3E6268-D998-11CE-9454-00AA00A3F36E_' 
			return 2;
		end
		return 1;
	END
GO
/****** Object:  StoredProcedure [dbo].[UpdateBinaryData]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateBinaryData]
(
@Id UNIQUEIDENTIFIER,
@Data IMAGE
)
AS
BEGIN
	UPDATE BinaryTable SET Data = @Data, Length = DATALENGTH(@Data) WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateBinaryTableDescription]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateBinaryTableDescription] 
@Id UNIQUEIDENTIFIER,
@Description NVARCHAR(300)
AS
BEGIN
	UPDATE BinaryTable SET Description = @Description WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateBinaryTableName]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateBinaryTableName]
(
	@Id UNIQUEIDENTIFIER,
	@Name NVARCHAR(50)	
)
AS
BEGIN
	UPDATE BinaryTable SET Name = @Name WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateBinaryTreeDescription]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateBinaryTreeDescription] 
	@Id UNIQUEIDENTIFIER,
	@Description NVARCHAR(300)
AS
BEGIN
	UPDATE BinaryTree SET Description = @Description WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateBinaryTreeName]    Script Date: 1/17/2022 7:46:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateBinaryTreeName] 
	@Id UNIQUEIDENTIFIER,
	@Name NVARCHAR(50)
AS
BEGIN
	UPDATE BinaryTree SET Name = @Name WHERE Id = @Id
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "BinaryTable"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 3
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewBinaryTableInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewBinaryTableInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "BinaryTable"
            Begin Extent = 
               Top = 7
               Left = 48
               Bottom = 170
               Right = 242
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewBinaryTreeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ViewBinaryTreeId'
GO
USE [master]
GO
ALTER DATABASE [AstronomyExpress] SET  READ_WRITE 
GO
