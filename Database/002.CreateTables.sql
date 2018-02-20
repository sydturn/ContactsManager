USE [MijemTest]
GO

/****** Object:  Table [dbo].[Contacts]    Script Date: 19/02/2018 8:30:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Contacts](
	[ContactID] [int] IDENTITY(1,1) NOT NULL,
	[ContactName] [varchar](255) NOT NULL,
	[PhoneNumber] [varchar](255) NULL,
	[BirthDate] [date] NOT NULL,
	[ContactType] [int] NOT NULL,
	[Description] [varchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ContactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
CREATE TABLE [dbo].[ContactTypes](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contacts]  WITH CHECK ADD  CONSTRAINT [FK_Contacts_ContactTypes] FOREIGN KEY([ContactType])
REFERENCES [dbo].[ContactTypes] ([TypeID])
GO

ALTER TABLE [dbo].[Contacts] CHECK CONSTRAINT [FK_Contacts_ContactTypes]
GO


