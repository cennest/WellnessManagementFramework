USE [master]
GO
/****** Object:  Database [WellnessManagementFrameworkDB]    Script Date: 12/27/2014 3:38:04 PM ******/
CREATE DATABASE [WellnessManagementFrameworkDB] ON  PRIMARY 
( NAME = N'WellnessManagementFrameworkDB', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\WellnessManagementFrameworkDB.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WellnessManagementFrameworkDB_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\WellnessManagementFrameworkDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WellnessManagementFrameworkDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET  MULTI_USER 
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET DB_CHAINING OFF 
GO
USE [WellnessManagementFrameworkDB]
GO
/****** Object:  Table [dbo].[CategoryMaster]    Script Date: 12/27/2014 3:38:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryMaster](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_CategoryMaster] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Client]    Script Date: 12/27/2014 3:38:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Client](
	[ClientID] [int] IDENTITY(1,1) NOT NULL,
	[ClientName] [nvarchar](200) NOT NULL,
	[ClientPhone] [varchar](15) NULL,
	[ClientAddress] [nvarchar](max) NULL,
	[UserID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DietPlanReport]    Script Date: 12/27/2014 3:38:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DietPlanReport](
	[DietPlanReportID] [int] IDENTITY(1,1) NOT NULL,
	[TestDate] [date] NOT NULL,
	[ClientID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Suggestions] [nvarchar](max) NULL,
	[Morning] [nvarchar](max) NULL,
	[Afternoon] [nvarchar](max) NULL,
	[Evening] [nvarchar](max) NULL,
	[BMI] [int] NULL,
 CONSTRAINT [PK_DietPlanReport] PRIMARY KEY CLUSTERED 
(
	[DietPlanReportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LabReport]    Script Date: 12/27/2014 3:38:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LabReport](
	[LabReportID] [int] IDENTITY(1,1) NOT NULL,
	[TestDate] [date] NOT NULL,
	[ReportFieldID] [int] NOT NULL,
	[ReportFieldValue] [nvarchar](max) NOT NULL,
	[ClientID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Remark1] [nvarchar](max) NULL,
	[Remark2] [nvarchar](max) NULL,
 CONSTRAINT [PK_LabReport] PRIMARY KEY CLUSTERED 
(
	[LabReportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OccupationMaster]    Script Date: 12/27/2014 3:38:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OccupationMaster](
	[OccupationID] [int] IDENTITY(1,1) NOT NULL,
	[OccupationName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_OccupationMaster] PRIMARY KEY CLUSTERED 
(
	[OccupationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OccupationReportField]    Script Date: 12/27/2014 3:38:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OccupationReportField](
	[OccupationReportFieldID] [int] IDENTITY(1,1) NOT NULL,
	[OccupationID] [int] NOT NULL,
	[ReportFieldID] [int] NOT NULL,
 CONSTRAINT [PK_OccupationReportField] PRIMARY KEY CLUSTERED 
(
	[OccupationReportFieldID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhysicalConditionReport]    Script Date: 12/27/2014 3:38:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhysicalConditionReport](
	[PhysicalConditionReportID] [int] IDENTITY(1,1) NOT NULL,
	[TestDate] [date] NOT NULL,
	[ClientID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[MSKAssessmentImpressions] [nvarchar](max) NULL,
	[Advice] [nvarchar](max) NULL,
 CONSTRAINT [PK_PhysicalConditionReport] PRIMARY KEY CLUSTERED 
(
	[PhysicalConditionReportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReportFieldMaster]    Script Date: 12/27/2014 3:38:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportFieldMaster](
	[ReportFieldID] [int] IDENTITY(1,1) NOT NULL,
	[ReportFieldName] [nvarchar](200) NOT NULL,
	[ReportTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ReportField] PRIMARY KEY CLUSTERED 
(
	[ReportFieldID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReportTypeMaster]    Script Date: 12/27/2014 3:38:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportTypeMaster](
	[ReportTypeID] [int] IDENTITY(1,1) NOT NULL,
	[ReportTypeName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ReportTypeMaster] PRIMARY KEY CLUSTERED 
(
	[ReportTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 12/27/2014 3:38:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](200) NOT NULL,
	[UserPhone] [varchar](15) NULL,
	[UserAddress] [nvarchar](max) NULL,
	[Password] [nvarchar](200) NOT NULL,
	[OccupationID] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserReportField]    Script Date: 12/27/2014 3:38:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserReportField](
	[UserReportFieldID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[ReportFieldID] [int] NOT NULL,
 CONSTRAINT [PK_UserReportField] PRIMARY KEY CLUSTERED 
(
	[UserReportFieldID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[CategoryMaster] ON 

INSERT [dbo].[CategoryMaster] ([CategoryID], [CategoryName]) VALUES (1, N'Shooter')
INSERT [dbo].[CategoryMaster] ([CategoryID], [CategoryName]) VALUES (2, N'WeightLifter')
INSERT [dbo].[CategoryMaster] ([CategoryID], [CategoryName]) VALUES (3, N'Archer')
INSERT [dbo].[CategoryMaster] ([CategoryID], [CategoryName]) VALUES (4, N'Swimmer')
INSERT [dbo].[CategoryMaster] ([CategoryID], [CategoryName]) VALUES (5, N'Boxer')
INSERT [dbo].[CategoryMaster] ([CategoryID], [CategoryName]) VALUES (6, N'Sprinter')
SET IDENTITY_INSERT [dbo].[CategoryMaster] OFF
SET IDENTITY_INSERT [dbo].[OccupationMaster] ON 

INSERT [dbo].[OccupationMaster] ([OccupationID], [OccupationName]) VALUES (1, N'Physiotherapist')
INSERT [dbo].[OccupationMaster] ([OccupationID], [OccupationName]) VALUES (2, N'Nutritionist')
INSERT [dbo].[OccupationMaster] ([OccupationID], [OccupationName]) VALUES (3, N'Dentist')
INSERT [dbo].[OccupationMaster] ([OccupationID], [OccupationName]) VALUES (4, N'Dietician')
INSERT [dbo].[OccupationMaster] ([OccupationID], [OccupationName]) VALUES (5, N'Physicist')
INSERT [dbo].[OccupationMaster] ([OccupationID], [OccupationName]) VALUES (6, N'Psychotherapist')
SET IDENTITY_INSERT [dbo].[OccupationMaster] OFF
SET IDENTITY_INSERT [dbo].[ReportFieldMaster] ON 

INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (1, N'Athelete Name', 1)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (3, N'Vit B12', 1)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (4, N'Vit D', 1)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (5, N'Vit D Low', 1)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (6, N'Vit D High', 1)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (7, N'Cal', 1)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (8, N'HB', 1)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (9, N'BGRP', 1)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (11, N'RBC', 1)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (12, N'Hemato', 1)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (13, N'WBC', 1)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (14, N'Platelet', 1)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (15, N'Thyroid', 1)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (16, N'Athelete Name', 2)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (19, N'BMI', 2)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (20, N'Diet Plan', 2)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (21, N'Early Morning', 2)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (22, N'Breakfast', 2)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (23, N'Mid Morning', 2)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (24, N'Lunch', 2)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (25, N'Tea', 2)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (26, N'Evening', 2)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (27, N'Dinner', 2)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (28, N'Athelete Name', 3)
SET IDENTITY_INSERT [dbo].[ReportFieldMaster] OFF
SET IDENTITY_INSERT [dbo].[ReportTypeMaster] ON 

INSERT [dbo].[ReportTypeMaster] ([ReportTypeID], [ReportTypeName]) VALUES (1, N'LabReport')
INSERT [dbo].[ReportTypeMaster] ([ReportTypeID], [ReportTypeName]) VALUES (2, N'DietPlanReport')
INSERT [dbo].[ReportTypeMaster] ([ReportTypeID], [ReportTypeName]) VALUES (3, N'PhysicalConditionReport')
SET IDENTITY_INSERT [dbo].[ReportTypeMaster] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [UserName], [UserPhone], [UserAddress], [Password], [OccupationID]) VALUES (1, N'nikhil', N'9815154114', N'mumbai', N'123', 1)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_CategoryMaster] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[CategoryMaster] ([CategoryID])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_CategoryMaster]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_User]
GO
ALTER TABLE [dbo].[DietPlanReport]  WITH CHECK ADD  CONSTRAINT [FK_DietPlanReport_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[DietPlanReport] CHECK CONSTRAINT [FK_DietPlanReport_Client]
GO
ALTER TABLE [dbo].[DietPlanReport]  WITH CHECK ADD  CONSTRAINT [FK_DietPlanReport_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[DietPlanReport] CHECK CONSTRAINT [FK_DietPlanReport_User]
GO
ALTER TABLE [dbo].[LabReport]  WITH CHECK ADD  CONSTRAINT [FK_LabReport_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[LabReport] CHECK CONSTRAINT [FK_LabReport_Client]
GO
ALTER TABLE [dbo].[LabReport]  WITH CHECK ADD  CONSTRAINT [FK_LabReport_ReportField] FOREIGN KEY([ReportFieldID])
REFERENCES [dbo].[ReportFieldMaster] ([ReportFieldID])
GO
ALTER TABLE [dbo].[LabReport] CHECK CONSTRAINT [FK_LabReport_ReportField]
GO
ALTER TABLE [dbo].[LabReport]  WITH CHECK ADD  CONSTRAINT [FK_LabReport_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[LabReport] CHECK CONSTRAINT [FK_LabReport_User]
GO
ALTER TABLE [dbo].[OccupationReportField]  WITH CHECK ADD  CONSTRAINT [FK_OccupationReportField_OccupationMaster] FOREIGN KEY([OccupationID])
REFERENCES [dbo].[OccupationMaster] ([OccupationID])
GO
ALTER TABLE [dbo].[OccupationReportField] CHECK CONSTRAINT [FK_OccupationReportField_OccupationMaster]
GO
ALTER TABLE [dbo].[OccupationReportField]  WITH CHECK ADD  CONSTRAINT [FK_OccupationReportField_ReportField] FOREIGN KEY([ReportFieldID])
REFERENCES [dbo].[ReportFieldMaster] ([ReportFieldID])
GO
ALTER TABLE [dbo].[OccupationReportField] CHECK CONSTRAINT [FK_OccupationReportField_ReportField]
GO
ALTER TABLE [dbo].[PhysicalConditionReport]  WITH CHECK ADD  CONSTRAINT [FK_PhysicalConditionReport_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[PhysicalConditionReport] CHECK CONSTRAINT [FK_PhysicalConditionReport_Client]
GO
ALTER TABLE [dbo].[PhysicalConditionReport]  WITH CHECK ADD  CONSTRAINT [FK_PhysicalConditionReport_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[PhysicalConditionReport] CHECK CONSTRAINT [FK_PhysicalConditionReport_User]
GO
ALTER TABLE [dbo].[ReportFieldMaster]  WITH CHECK ADD  CONSTRAINT [FK_ReportField_ReportTypeMaster] FOREIGN KEY([ReportTypeID])
REFERENCES [dbo].[ReportTypeMaster] ([ReportTypeID])
GO
ALTER TABLE [dbo].[ReportFieldMaster] CHECK CONSTRAINT [FK_ReportField_ReportTypeMaster]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_OccupationMaster] FOREIGN KEY([OccupationID])
REFERENCES [dbo].[OccupationMaster] ([OccupationID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_OccupationMaster]
GO
ALTER TABLE [dbo].[UserReportField]  WITH CHECK ADD  CONSTRAINT [FK_UserReportField_ReportField] FOREIGN KEY([ReportFieldID])
REFERENCES [dbo].[ReportFieldMaster] ([ReportFieldID])
GO
ALTER TABLE [dbo].[UserReportField] CHECK CONSTRAINT [FK_UserReportField_ReportField]
GO
ALTER TABLE [dbo].[UserReportField]  WITH CHECK ADD  CONSTRAINT [FK_UserReportField_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserReportField] CHECK CONSTRAINT [FK_UserReportField_User]
GO
USE [master]
GO
ALTER DATABASE [WellnessManagementFrameworkDB] SET  READ_WRITE 
GO
