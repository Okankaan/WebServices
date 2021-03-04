# WebServices
***Web services examples:***

***1-ProgrammingApp Project(.Net Framework Web Api)***
-
____________________________________________________________

--A MsSQL Database with the name "ProgrammingDb" created.
---
____________________________________________________________
--"Languages" table is created with following SQLquery
---
```
USE [ProgrammingDb]
GO

/****** Object:  Table [dbo].[Languages]    Script Date: 04.03.2021 23:04:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Languages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Language] [nvarchar](50) NOT NULL,
	[Founder] [nvarchar](50) NOT NULL,
	[Year] [date] NOT NULL,
	[IsPopular] [bit] NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
```
____________________________________________________________
--"Users" table is created with following SQLquery
---
```
USE [ProgrammingDb]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 04.03.2021 23:13:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserKey] [uniqueidentifier] NULL,
	[Name] [nvarchar](50) NULL,
	[Role] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_UserKey]  DEFAULT (newid()) FOR [UserKey]
GO
```
____________________________________________________________
--"Languages" table Rows added
---
```
ID   | Language   | Founder           | Year       | IsPopular
1    | CSharp     |Anders Hejsberg    |2000-01-01  | True
2    | Delphi     |Anders Hejsberg    |1995-01-01  | False
3    | Java       |James Gosling      |1995-01-01  | True
4    | C          |Dennis Ritchie     |1972-01-01  | True
5    | C++        |Bjarne Stroustrup  |2000-01-01  | True
```
____________________________________________________________
--"Users" table Rows added
---
```
UserId   | UserKey                                 | Name    | Role       
1        | CF24D6C4-F3CA-4D70-A170-FB242AD996B7    | Okan    | A 
2        | AED63F69-A30E-4AD4-884B-39840C58236B    | Kaan    | U
```
