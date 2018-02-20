USE [MijemTest]
GO

/****** Object:  StoredProcedure [dbo].[UpdateContactType]    Script Date: 19/02/2018 8:50:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateContactType] @Id int, @Name varchar(255)
AS
BEGIN

    -- Insert statements for procedure here
	UPDATE ContactTypes SET TypeName = @Name
	WHERE TypeID = @Id
END
GO

CREATE PROCEDURE [dbo].[UpdateContactInfo] @Id int, @Name varchar(255), @Phone varchar(255) = NULL, @Birthday Date, @TypeId int, @Description varchar(8000)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Contacts SET ContactName = @Name, PhoneNumber = @Phone, BirthDate = @Birthday, ContactType = @TypeId , Description = @Description
	WHERE ContactID = @Id
END
GO

CREATE PROCEDURE [dbo].[GetTypeById] @Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM ContactTypes WHERE TypeID = @Id
END
GO

CREATE PROCEDURE [dbo].[GetContactById] @Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Contacts WHERE ContactID = @Id
END
GO

CREATE PROCEDURE [dbo].[GetAllTypes]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM ContactTypes
END
GO


CREATE PROCEDURE [dbo].[GetAllContacts]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Contacts
END
GO


CREATE PROCEDURE [dbo].[DeleteTypeById] @Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM ContactTypes WHERE TypeID = @Id
END
GO


CREATE PROCEDURE [dbo].[DeleteContactById] @Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DELETE FROM Contacts WHERE ContactID = @Id
END
GO


CREATE PROCEDURE [dbo].[CreateContact] @Id int, @Name varchar(255), @Phone varchar(255) = NULL, @Birthday Date, @TypeId int, @Description varchar(8000)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Contacts (ContactName, PhoneNumber, BirthDate, ContactType, Description) VALUES (@Name, @Phone, @Birthday, @TypeId, @Description)
END
GO





