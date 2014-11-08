create database WellnessManagementSystemDB

USE [WellnessManagementSystemDB]
GO
/****** Object:  Table [dbo].[CategoryMaster]    Script Date: 11/08/2014 11:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryMaster](
	[CategoryID] [int] NOT NULL,
	[CategoryName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_CategoryMaster] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OccupationMaster]    Script Date: 11/08/2014 11:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OccupationMaster](
	[OccupationID] [int] NOT NULL,
	[OccupationName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_OccupationMaster] PRIMARY KEY CLUSTERED 
(
	[OccupationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportTypeMaster]    Script Date: 11/08/2014 11:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportTypeMaster](
	[ReportTypeID] [int] NOT NULL,
	[ReportTypeName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ReportTypeMaster] PRIMARY KEY CLUSTERED 
(
	[ReportTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportFieldMaster]    Script Date: 11/08/2014 11:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportFieldMaster](
	[ReportFieldID] [int] NOT NULL,
	[ReportFieldName] [nvarchar](200) NOT NULL,
	[ReportTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ReportField] PRIMARY KEY CLUSTERED 
(
	[ReportFieldID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/08/2014 11:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] NOT NULL,
	[UserName] [nvarchar](200) NOT NULL,
	[UserPhone] [varchar](15) NULL,
	[UserAddress] [nvarchar](max) NULL,
	[Password] [nvarchar](200) NOT NULL,
	[OccupationID] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserReportField]    Script Date: 11/08/2014 11:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserReportField](
	[UserReportFieldID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[ReportFieldID] [int] NOT NULL,
 CONSTRAINT [PK_UserReportField] PRIMARY KEY CLUSTERED 
(
	[UserReportFieldID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OccupationReportField]    Script Date: 11/08/2014 11:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OccupationReportField](
	[OccupationReportFieldID] [int] NOT NULL,
	[OccupationID] [int] NOT NULL,
	[ReportFieldID] [int] NOT NULL,
 CONSTRAINT [PK_OccupationReportField] PRIMARY KEY CLUSTERED 
(
	[OccupationReportFieldID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 11/08/2014 11:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Client](
	[ClientID] [int] NOT NULL,
	[ClientName] [nvarchar](200) NOT NULL,
	[ClientPhone] [varchar](15) NULL,
	[ClientAddress] [nvarchar](max) NULL,
	[UserID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhysicalConditionReport]    Script Date: 11/08/2014 11:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhysicalConditionReport](
	[PhysicalConditionReportID] [int] NOT NULL,
	[TestDate] [date] NOT NULL,
	[ReportFieldID] [int] NOT NULL,
	[ReportFieldName] [nvarchar](200) NOT NULL,
	[ReportFieldValue] [nvarchar](max) NOT NULL,
	[ClientID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_PhysicalConditionReport] PRIMARY KEY CLUSTERED 
(
	[PhysicalConditionReportID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LabReport]    Script Date: 11/08/2014 11:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LabReport](
	[LabReportID] [int] NOT NULL,
	[TestDate] [date] NOT NULL,
	[ReportFieldID] [int] NOT NULL,
	[ReportFieldName] [nvarchar](200) NOT NULL,
	[ReportFieldValue] [nvarchar](max) NOT NULL,
	[NextTestDate] [date] NULL,
	[ClientID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_LabReport] PRIMARY KEY CLUSTERED 
(
	[LabReportID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DietPlanReport]    Script Date: 11/08/2014 11:44:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DietPlanReport](
	[DietPlanReportID] [int] NOT NULL,
	[TestDate] [date] NOT NULL,
	[ReportFieldID] [int] NOT NULL,
	[ReportFieldName] [nvarchar](200) NOT NULL,
	[ReportFieldValue] [nvarchar](max) NOT NULL,
	[ClientID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
 CONSTRAINT [PK_DietPlanReport] PRIMARY KEY CLUSTERED 
(
	[DietPlanReportID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Client_CategoryMaster]    Script Date: 11/08/2014 11:44:34 ******/
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_CategoryMaster] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[CategoryMaster] ([CategoryID])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_CategoryMaster]
GO
/****** Object:  ForeignKey [FK_Client_User]    Script Date: 11/08/2014 11:44:34 ******/
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_User]
GO
/****** Object:  ForeignKey [FK_DietPlanReport_Client]    Script Date: 11/08/2014 11:44:34 ******/
ALTER TABLE [dbo].[DietPlanReport]  WITH CHECK ADD  CONSTRAINT [FK_DietPlanReport_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[DietPlanReport] CHECK CONSTRAINT [FK_DietPlanReport_Client]
GO
/****** Object:  ForeignKey [FK_DietPlanReport_ReportField]    Script Date: 11/08/2014 11:44:34 ******/
ALTER TABLE [dbo].[DietPlanReport]  WITH CHECK ADD  CONSTRAINT [FK_DietPlanReport_ReportField] FOREIGN KEY([ReportFieldID])
REFERENCES [dbo].[ReportFieldMaster] ([ReportFieldID])
GO
ALTER TABLE [dbo].[DietPlanReport] CHECK CONSTRAINT [FK_DietPlanReport_ReportField]
GO
/****** Object:  ForeignKey [FK_DietPlanReport_User]    Script Date: 11/08/2014 11:44:34 ******/
ALTER TABLE [dbo].[DietPlanReport]  WITH CHECK ADD  CONSTRAINT [FK_DietPlanReport_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[DietPlanReport] CHECK CONSTRAINT [FK_DietPlanReport_User]
GO
/****** Object:  ForeignKey [FK_LabReport_Client]    Script Date: 11/08/2014 11:44:34 ******/
ALTER TABLE [dbo].[LabReport]  WITH CHECK ADD  CONSTRAINT [FK_LabReport_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[LabReport] CHECK CONSTRAINT [FK_LabReport_Client]
GO
/****** Object:  ForeignKey [FK_LabReport_ReportField]    Script Date: 11/08/2014 11:44:34 ******/
ALTER TABLE [dbo].[LabReport]  WITH CHECK ADD  CONSTRAINT [FK_LabReport_ReportField] FOREIGN KEY([ReportFieldID])
REFERENCES [dbo].[ReportFieldMaster] ([ReportFieldID])
GO
ALTER TABLE [dbo].[LabReport] CHECK CONSTRAINT [FK_LabReport_ReportField]
GO
/****** Object:  ForeignKey [FK_LabReport_User]    Script Date: 11/08/2014 11:44:34 ******/
ALTER TABLE [dbo].[LabReport]  WITH CHECK ADD  CONSTRAINT [FK_LabReport_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[LabReport] CHECK CONSTRAINT [FK_LabReport_User]
GO
/****** Object:  ForeignKey [FK_OccupationReportField_OccupationMaster]    Script Date: 11/08/2014 11:44:34 ******/
ALTER TABLE [dbo].[OccupationReportField]  WITH CHECK ADD  CONSTRAINT [FK_OccupationReportField_OccupationMaster] FOREIGN KEY([OccupationID])
REFERENCES [dbo].[OccupationMaster] ([OccupationID])
GO
ALTER TABLE [dbo].[OccupationReportField] CHECK CONSTRAINT [FK_OccupationReportField_OccupationMaster]
GO
/****** Object:  ForeignKey [FK_OccupationReportField_ReportField]    Script Date: 11/08/2014 11:44:34 ******/
ALTER TABLE [dbo].[OccupationReportField]  WITH CHECK ADD  CONSTRAINT [FK_OccupationReportField_ReportField] FOREIGN KEY([ReportFieldID])
REFERENCES [dbo].[ReportFieldMaster] ([ReportFieldID])
GO
ALTER TABLE [dbo].[OccupationReportField] CHECK CONSTRAINT [FK_OccupationReportField_ReportField]
GO
/****** Object:  ForeignKey [FK_PhysicalConditionReport_Client]    Script Date: 11/08/2014 11:44:34 ******/
ALTER TABLE [dbo].[PhysicalConditionReport]  WITH CHECK ADD  CONSTRAINT [FK_PhysicalConditionReport_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[PhysicalConditionReport] CHECK CONSTRAINT [FK_PhysicalConditionReport_Client]
GO
/****** Object:  ForeignKey [FK_PhysicalConditionReport_ReportField]    Script Date: 11/08/2014 11:44:34 ******/
ALTER TABLE [dbo].[PhysicalConditionReport]  WITH CHECK ADD  CONSTRAINT [FK_PhysicalConditionReport_ReportField] FOREIGN KEY([ReportFieldID])
REFERENCES [dbo].[ReportFieldMaster] ([ReportFieldID])
GO
ALTER TABLE [dbo].[PhysicalConditionReport] CHECK CONSTRAINT [FK_PhysicalConditionReport_ReportField]
GO
/****** Object:  ForeignKey [FK_PhysicalConditionReport_User]    Script Date: 11/08/2014 11:44:34 ******/
ALTER TABLE [dbo].[PhysicalConditionReport]  WITH CHECK ADD  CONSTRAINT [FK_PhysicalConditionReport_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[PhysicalConditionReport] CHECK CONSTRAINT [FK_PhysicalConditionReport_User]
GO
/****** Object:  ForeignKey [FK_ReportField_ReportTypeMaster]    Script Date: 11/08/2014 11:44:34 ******/
ALTER TABLE [dbo].[ReportFieldMaster]  WITH CHECK ADD  CONSTRAINT [FK_ReportField_ReportTypeMaster] FOREIGN KEY([ReportTypeID])
REFERENCES [dbo].[ReportTypeMaster] ([ReportTypeID])
GO
ALTER TABLE [dbo].[ReportFieldMaster] CHECK CONSTRAINT [FK_ReportField_ReportTypeMaster]
GO
/****** Object:  ForeignKey [FK_User_OccupationMaster]    Script Date: 11/08/2014 11:44:34 ******/
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_OccupationMaster] FOREIGN KEY([OccupationID])
REFERENCES [dbo].[OccupationMaster] ([OccupationID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_OccupationMaster]
GO
/****** Object:  ForeignKey [FK_UserReportField_ReportField]    Script Date: 11/08/2014 11:44:34 ******/
ALTER TABLE [dbo].[UserReportField]  WITH CHECK ADD  CONSTRAINT [FK_UserReportField_ReportField] FOREIGN KEY([ReportFieldID])
REFERENCES [dbo].[ReportFieldMaster] ([ReportFieldID])
GO
ALTER TABLE [dbo].[UserReportField] CHECK CONSTRAINT [FK_UserReportField_ReportField]
GO
/****** Object:  ForeignKey [FK_UserReportField_User]    Script Date: 11/08/2014 11:44:34 ******/
ALTER TABLE [dbo].[UserReportField]  WITH CHECK ADD  CONSTRAINT [FK_UserReportField_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserReportField] CHECK CONSTRAINT [FK_UserReportField_User]
GO
