USE [master]
GO
/****** Object:  Database [WellnessManagementFrameworkDB]    Script Date: 01/24/2015 20:06:02 ******/
CREATE DATABASE [WellnessManagementFrameworkDB] ON  PRIMARY 
( NAME = N'WellnessManagementSystemDB2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\WellnessManagementSystemDB2.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'WellnessManagementSystemDB2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\WellnessManagementSystemDB2_log.LDF' , SIZE = 504KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
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
ALTER DATABASE [WellnessManagementFrameworkDB] SET AUTO_CLOSE ON
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
ALTER DATABASE [WellnessManagementFrameworkDB] SET  ENABLE_BROKER
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
ALTER DATABASE [WellnessManagementFrameworkDB] SET  READ_WRITE
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
/****** Object:  Table [dbo].[CategoryMaster]    Script Date: 01/24/2015 20:06:03 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CategoryMaster] ON
INSERT [dbo].[CategoryMaster] ([CategoryID], [CategoryName]) VALUES (1, N'All Sports')
INSERT [dbo].[CategoryMaster] ([CategoryID], [CategoryName]) VALUES (2, N'Shooter')
INSERT [dbo].[CategoryMaster] ([CategoryID], [CategoryName]) VALUES (3, N'WeightLifter')
INSERT [dbo].[CategoryMaster] ([CategoryID], [CategoryName]) VALUES (4, N'Archer')
INSERT [dbo].[CategoryMaster] ([CategoryID], [CategoryName]) VALUES (5, N'Swimmer')
INSERT [dbo].[CategoryMaster] ([CategoryID], [CategoryName]) VALUES (6, N'Boxer')
INSERT [dbo].[CategoryMaster] ([CategoryID], [CategoryName]) VALUES (7, N'Sprinter')
SET IDENTITY_INSERT [dbo].[CategoryMaster] OFF
/****** Object:  Table [dbo].[OccupationMaster]    Script Date: 01/24/2015 20:06:03 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[OccupationMaster] ON
INSERT [dbo].[OccupationMaster] ([OccupationID], [OccupationName]) VALUES (1, N'Physiotherapist')
INSERT [dbo].[OccupationMaster] ([OccupationID], [OccupationName]) VALUES (2, N'Nutritionist')
INSERT [dbo].[OccupationMaster] ([OccupationID], [OccupationName]) VALUES (3, N'Dentist')
INSERT [dbo].[OccupationMaster] ([OccupationID], [OccupationName]) VALUES (4, N'Dietician')
INSERT [dbo].[OccupationMaster] ([OccupationID], [OccupationName]) VALUES (5, N'Physicist')
INSERT [dbo].[OccupationMaster] ([OccupationID], [OccupationName]) VALUES (6, N'Athlete')
SET IDENTITY_INSERT [dbo].[OccupationMaster] OFF
/****** Object:  Table [dbo].[ReportTypeMaster]    Script Date: 01/24/2015 20:06:03 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ReportTypeMaster] ON
INSERT [dbo].[ReportTypeMaster] ([ReportTypeID], [ReportTypeName]) VALUES (1, N'LabReport')
INSERT [dbo].[ReportTypeMaster] ([ReportTypeID], [ReportTypeName]) VALUES (2, N'DietPlanReport')
INSERT [dbo].[ReportTypeMaster] ([ReportTypeID], [ReportTypeName]) VALUES (3, N'PhysicalConditionReport')
SET IDENTITY_INSERT [dbo].[ReportTypeMaster] OFF
/****** Object:  Table [dbo].[User]    Script Date: 01/24/2015 20:06:03 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON
INSERT [dbo].[User] ([UserId], [UserName], [UserPhone], [UserAddress], [Password], [OccupationID]) VALUES (1, N'Nikhil', N'9833385473', N'Mumbai', N'123', 5)
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  Table [dbo].[ReportFieldMaster]    Script Date: 01/24/2015 20:06:03 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ReportFieldMaster] ON
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
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (19, N'BMI', 2)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (20, N'Diet Plan', 2)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (21, N'Early Morning', 2)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (22, N'Breakfast', 2)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (23, N'Mid Morning', 2)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (24, N'Lunch', 2)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (25, N'Tea', 2)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (26, N'Evening', 2)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (27, N'Dinner', 2)
INSERT [dbo].[ReportFieldMaster] ([ReportFieldID], [ReportFieldName], [ReportTypeID]) VALUES (31, N'23', 2)
SET IDENTITY_INSERT [dbo].[ReportFieldMaster] OFF
/****** Object:  Table [dbo].[UserReportField]    Script Date: 01/24/2015 20:06:03 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[UserReportField] ON
INSERT [dbo].[UserReportField] ([UserReportFieldID], [UserID], [ReportFieldID]) VALUES (1, 1, 3)
SET IDENTITY_INSERT [dbo].[UserReportField] OFF
/****** Object:  Table [dbo].[OccupationReportField]    Script Date: 01/24/2015 20:06:03 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 01/24/2015 20:06:03 ******/
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
	[Notes] [nvarchar](max) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Client] ON
INSERT [dbo].[Client] ([ClientID], [ClientName], [ClientPhone], [ClientAddress], [UserID], [CategoryID], [Notes]) VALUES (3, N'Gagan Narang', N'9833386573', N'Mumbai', 1, 2, N'{\rtf1\ansi\ansicpg1252\uc1\htmautsp\deff2{\fonttbl{\f0\fcharset0 Times New Roman;}{\f2\fcharset0 Calibri(Body);}{\f3\fcharset0 Calibri;}}{\colortbl\red0\green0\blue0;\red255\green255\blue255;}\loch\hich\dbch\pard\plain\ltrpar\itap0{\lang1033\fs24\f3\cf0 \cf0\ql{\f3 {\ltrch dfgs }{\b\ltrch sfsadfs }{\ltrch df sadfsadf   }{\i\ltrch sadfsdfsdfdsdfsadf   }{\b\i\ltrch sdfasdfsdsdfsdf}\li0\ri0\sa0\sb0\fi0\ql\par}
{\f3 \li0\ri0\sa0\sb0\fi0\ql\par}
{\f3 {\ltrch sadfbasdfhvasdhf}\li0\ri0\sa0\sb0\fi0\ql\par}
{\f3 \li0\ri0\sa0\sb0\fi0\ql\par}
{\f3 {\b\i\ltrch asdfasdbfasdbfsb}\li0\ri0\sa0\sb0\fi0\ql\par}
}
}')
INSERT [dbo].[Client] ([ClientID], [ClientName], [ClientPhone], [ClientAddress], [UserID], [CategoryID], [Notes]) VALUES (5, N'Marry Kom', N'9833385473', N'Delhi', 1, 3, N'{\rtf1\ansi\ansicpg1252\uc1\htmautsp\deff2{\fonttbl{\f0\fcharset0 Times New Roman;}{\f2\fcharset0 Calibri(Body);}{\f3\fcharset0 Calibri;}}{\colortbl\red0\green0\blue0;\red255\green255\blue255;}\loch\hich\dbch\pard\plain\ltrpar\itap0{\lang1033\fs24\f3\cf0 \cf0\ql{\f3 {\ltrch sadfbsahdfbs sf sdfbsadf gsdafghsadgf hgasdfghg}\li0\ri0\sa0\sb0\fi0\ql\par}
{\f3 {\ltrch asjdvasjdvajsdvajsd jhaghjgashdgasd}\li0\ri0\sa0\sb0\fi0\ql\par}
{\f3 {\ltrch sadfjasdfsdbfhsdhf   iusyduifhsadjfhjsdhfjhiashdfjkhsjdfhjsakfhjaksh}\li0\ri0\sa0\sb0\fi0\ql\par}
}
}')
INSERT [dbo].[Client] ([ClientID], [ClientName], [ClientPhone], [ClientAddress], [UserID], [CategoryID], [Notes]) VALUES (6, N'Annu Raj', N'9833385473', N'Banglore', 1, 4, NULL)
INSERT [dbo].[Client] ([ClientID], [ClientName], [ClientPhone], [ClientAddress], [UserID], [CategoryID], [Notes]) VALUES (7, N'Pooja Ghatkar', N'9833385473', N'Panjab', 1, 5, NULL)
INSERT [dbo].[Client] ([ClientID], [ClientName], [ClientPhone], [ClientAddress], [UserID], [CategoryID], [Notes]) VALUES (8, N'Sweta Choudhary', N'9833385473', N'Kerla', 1, 6, NULL)
INSERT [dbo].[Client] ([ClientID], [ClientName], [ClientPhone], [ClientAddress], [UserID], [CategoryID], [Notes]) VALUES (9, N'Shiv Thapa', N'9833385473', N'Rajsthan', 1, 7, NULL)
INSERT [dbo].[Client] ([ClientID], [ClientName], [ClientPhone], [ClientAddress], [UserID], [CategoryID], [Notes]) VALUES (10, N'Shiv Keshawan', N'9833385473', N'Karnataka', 1, 2, NULL)
INSERT [dbo].[Client] ([ClientID], [ClientName], [ClientPhone], [ClientAddress], [UserID], [CategoryID], [Notes]) VALUES (11, N'Virat Kohli', N'9833385473', N'Hariyana', 1, 3, NULL)
INSERT [dbo].[Client] ([ClientID], [ClientName], [ClientPhone], [ClientAddress], [UserID], [CategoryID], [Notes]) VALUES (12, N'Sachin', N'9833385473', N'Mumbai', 1, 4, NULL)
INSERT [dbo].[Client] ([ClientID], [ClientName], [ClientPhone], [ClientAddress], [UserID], [CategoryID], [Notes]) VALUES (13, N'MS Dhoni', N'9833385473', N'Ranchi', 1, 5, NULL)
INSERT [dbo].[Client] ([ClientID], [ClientName], [ClientPhone], [ClientAddress], [UserID], [CategoryID], [Notes]) VALUES (14, N'Ambati Raydu', N'9833385473', N'Mumbai', 1, 6, NULL)
INSERT [dbo].[Client] ([ClientID], [ClientName], [ClientPhone], [ClientAddress], [UserID], [CategoryID], [Notes]) VALUES (15, N'Ishant Sharma', N'9833385473', N'Mumbai', 1, 7, NULL)
INSERT [dbo].[Client] ([ClientID], [ClientName], [ClientPhone], [ClientAddress], [UserID], [CategoryID], [Notes]) VALUES (16, N'Bret Lee', N'9833385473', N'Australia', 1, 2, NULL)
INSERT [dbo].[Client] ([ClientID], [ClientName], [ClientPhone], [ClientAddress], [UserID], [CategoryID], [Notes]) VALUES (18, N'Ricky pointing', N'9833385473', N'Australia', 1, 3, NULL)
INSERT [dbo].[Client] ([ClientID], [ClientName], [ClientPhone], [ClientAddress], [UserID], [CategoryID], [Notes]) VALUES (19, N'Mathew Haiden', N'9833385473', N'Australia', 1, 4, NULL)
INSERT [dbo].[Client] ([ClientID], [ClientName], [ClientPhone], [ClientAddress], [UserID], [CategoryID], [Notes]) VALUES (20, N'Peter Siddle', N'9833385473', N'Australia', 1, 5, NULL)
INSERT [dbo].[Client] ([ClientID], [ClientName], [ClientPhone], [ClientAddress], [UserID], [CategoryID], [Notes]) VALUES (21, N'Shane Watson', N'9833385473', N'Australia', 1, 6, NULL)
SET IDENTITY_INSERT [dbo].[Client] OFF
/****** Object:  Table [dbo].[PhysicalConditionReport]    Script Date: 01/24/2015 20:06:03 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PhysicalConditionReport] ON
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (2, CAST(0x5A390B00 AS Date), 3, 1, N'123', N'123')
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (3, CAST(0x3C390B00 AS Date), 3, 1, N'123', N'123')
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (4, CAST(0x1D390B00 AS Date), 3, 1, N'123', N'123')
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (5, CAST(0xFF380B00 AS Date), 3, 1, N'123', N'123')
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (6, CAST(0xE0380B00 AS Date), 3, 1, N'123', N'123')
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (7, CAST(0xC1380B00 AS Date), 3, 1, N'123', N'123')
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (8, CAST(0xA3380B00 AS Date), 3, 1, N'123', N'123')
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (9, CAST(0x84380B00 AS Date), 3, 1, N'123', N'123')
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (10, CAST(0x66380B00 AS Date), 3, 1, N'123', N'123')
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (11, CAST(0x47380B00 AS Date), 3, 1, N'123', N'123')
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (12, CAST(0x0C380B00 AS Date), 3, 1, N'123', N'123')
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (13, CAST(0x5B390B00 AS Date), 3, 1, N'123', N'123')
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (14, CAST(0x5C390B00 AS Date), 3, 1, N'123', N'123')
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (15, CAST(0x5D390B00 AS Date), 3, 1, N'123', N'123')
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (16, CAST(0x5E390B00 AS Date), 3, 1, N'123', N'123')
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (17, CAST(0x5F390B00 AS Date), 3, 1, N'123', N'123')
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (18, CAST(0x60390B00 AS Date), 3, 1, N'123', N'123')
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (19, CAST(0x61390B00 AS Date), 3, 1, N'123', N'123')
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (20, CAST(0x62390B00 AS Date), 3, 1, N'123', N'123')
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (21, CAST(0x63390B00 AS Date), 3, 1, N'123', N'123')
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (22, CAST(0x64390B00 AS Date), 3, 1, N'123', N'123')
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (23, CAST(0x65390B00 AS Date), 3, 1, N'Everything Fine', N'123')
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (24, CAST(0x77390B00 AS Date), 3, 1, N'Hello World', NULL)
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (25, CAST(0x77390B00 AS Date), 3, 1, N'Assessment needed', NULL)
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (26, CAST(0x77390B00 AS Date), 3, 1, N'wwewewewee', NULL)
INSERT [dbo].[PhysicalConditionReport] ([PhysicalConditionReportID], [TestDate], [ClientID], [UserID], [MSKAssessmentImpressions], [Advice]) VALUES (27, CAST(0x7E390B00 AS Date), 3, 1, N'MNMNMNM', N'MNMNM')
SET IDENTITY_INSERT [dbo].[PhysicalConditionReport] OFF
/****** Object:  Table [dbo].[LabReport]    Script Date: 01/24/2015 20:06:03 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[LabReport] ON
INSERT [dbo].[LabReport] ([LabReportID], [TestDate], [ReportFieldID], [ReportFieldValue], [ClientID], [UserID], [Remark1], [Remark2]) VALUES (2, CAST(0xDE380B00 AS Date), 4, N'2', 3, 1, NULL, NULL)
INSERT [dbo].[LabReport] ([LabReportID], [TestDate], [ReportFieldID], [ReportFieldValue], [ClientID], [UserID], [Remark1], [Remark2]) VALUES (4, CAST(0x93380B00 AS Date), 4, N'3', 3, 1, NULL, NULL)
INSERT [dbo].[LabReport] ([LabReportID], [TestDate], [ReportFieldID], [ReportFieldValue], [ClientID], [UserID], [Remark1], [Remark2]) VALUES (5, CAST(0x3A390B00 AS Date), 4, N'4', 3, 1, NULL, NULL)
INSERT [dbo].[LabReport] ([LabReportID], [TestDate], [ReportFieldID], [ReportFieldValue], [ClientID], [UserID], [Remark1], [Remark2]) VALUES (6, CAST(0x5D390B00 AS Date), 4, N'4', 5, 1, NULL, NULL)
INSERT [dbo].[LabReport] ([LabReportID], [TestDate], [ReportFieldID], [ReportFieldValue], [ClientID], [UserID], [Remark1], [Remark2]) VALUES (7, CAST(0x3B390B00 AS Date), 4, N'4', 6, 1, NULL, NULL)
INSERT [dbo].[LabReport] ([LabReportID], [TestDate], [ReportFieldID], [ReportFieldValue], [ClientID], [UserID], [Remark1], [Remark2]) VALUES (8, CAST(0x7A380B00 AS Date), 4, N'4', 8, 1, NULL, NULL)
INSERT [dbo].[LabReport] ([LabReportID], [TestDate], [ReportFieldID], [ReportFieldValue], [ClientID], [UserID], [Remark1], [Remark2]) VALUES (9, CAST(0x6E390B00 AS Date), 4, N'4', 11, 1, NULL, NULL)
INSERT [dbo].[LabReport] ([LabReportID], [TestDate], [ReportFieldID], [ReportFieldValue], [ClientID], [UserID], [Remark1], [Remark2]) VALUES (10, CAST(0xF5380B00 AS Date), 4, N'4', 5, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[LabReport] OFF
/****** Object:  Table [dbo].[DietPlanReport]    Script Date: 01/24/2015 20:06:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DietPlanReport](
	[DietPlanReportID] [int] IDENTITY(1,1) NOT NULL,
	[TestDate] [date] NOT NULL,
	[ClientID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Morning] [nvarchar](max) NULL,
	[Afternoon] [nvarchar](max) NULL,
	[Evening] [nvarchar](max) NULL,
	[Night] [nvarchar](max) NULL,
	[BMI] [nchar](10) NULL,
 CONSTRAINT [PK_DietPlanReport] PRIMARY KEY CLUSTERED 
(
	[DietPlanReportID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DietPlanReport] ON
INSERT [dbo].[DietPlanReport] ([DietPlanReportID], [TestDate], [ClientID], [UserID], [Morning], [Afternoon], [Evening], [Night], [BMI]) VALUES (7, CAST(0x00000000 AS Date), 3, 1, N'asdasdasdas', N'Hello World', N'Hello World', N'Hello World', N'10.2      ')
INSERT [dbo].[DietPlanReport] ([DietPlanReportID], [TestDate], [ClientID], [UserID], [Morning], [Afternoon], [Evening], [Night], [BMI]) VALUES (8, CAST(0x00000000 AS Date), 3, 1, N'Hello World', N'Hello World', N'Hello World', N'Hello World', N'10.2      ')
INSERT [dbo].[DietPlanReport] ([DietPlanReportID], [TestDate], [ClientID], [UserID], [Morning], [Afternoon], [Evening], [Night], [BMI]) VALUES (9, CAST(0x00000000 AS Date), 3, 1, N'Hello World', N'Hello World', N'Hello World', N'Hello World', N'10.2      ')
INSERT [dbo].[DietPlanReport] ([DietPlanReportID], [TestDate], [ClientID], [UserID], [Morning], [Afternoon], [Evening], [Night], [BMI]) VALUES (10, CAST(0x00000000 AS Date), 3, 1, N'Hello World', N'opiopioop', N'=-o[po[pop[o', N'o-i0oikp[kipo', N'10.2      ')
INSERT [dbo].[DietPlanReport] ([DietPlanReportID], [TestDate], [ClientID], [UserID], [Morning], [Afternoon], [Evening], [Night], [BMI]) VALUES (11, CAST(0x00000000 AS Date), 3, 1, N'Hello World', N'Hello World', N'Hello World', N'Hello World', N'10.2      ')
INSERT [dbo].[DietPlanReport] ([DietPlanReportID], [TestDate], [ClientID], [UserID], [Morning], [Afternoon], [Evening], [Night], [BMI]) VALUES (12, CAST(0x00000000 AS Date), 3, 1, N'Hello World', N'Hello World', N'Hello World', N'Hello World', N'10.2      ')
INSERT [dbo].[DietPlanReport] ([DietPlanReportID], [TestDate], [ClientID], [UserID], [Morning], [Afternoon], [Evening], [Night], [BMI]) VALUES (13, CAST(0x00000000 AS Date), 3, 1, N'Hello World', N'Hello World', N'Hello World', N'Hello World', N'10.2      ')
INSERT [dbo].[DietPlanReport] ([DietPlanReportID], [TestDate], [ClientID], [UserID], [Morning], [Afternoon], [Evening], [Night], [BMI]) VALUES (14, CAST(0x00000000 AS Date), 3, 1, N'Hello World', N'Hello World', N'Hello World', N'Hello World', N'10.2      ')
INSERT [dbo].[DietPlanReport] ([DietPlanReportID], [TestDate], [ClientID], [UserID], [Morning], [Afternoon], [Evening], [Night], [BMI]) VALUES (15, CAST(0x00000000 AS Date), 3, 1, N'Hello World', N'Hello World', N'Hello World', N'Hello World', N'10.2      ')
INSERT [dbo].[DietPlanReport] ([DietPlanReportID], [TestDate], [ClientID], [UserID], [Morning], [Afternoon], [Evening], [Night], [BMI]) VALUES (16, CAST(0x00000000 AS Date), 3, 1, N'Hello World', N'Hello World', N'Hello World', N'Hello World', N'10.2      ')
INSERT [dbo].[DietPlanReport] ([DietPlanReportID], [TestDate], [ClientID], [UserID], [Morning], [Afternoon], [Evening], [Night], [BMI]) VALUES (17, CAST(0x01380B00 AS Date), 3, 1, N'oipoipoipoi', N'joijuioujiouiou', N'Hello World', N'Hello World', N'10.2      ')
INSERT [dbo].[DietPlanReport] ([DietPlanReportID], [TestDate], [ClientID], [UserID], [Morning], [Afternoon], [Evening], [Night], [BMI]) VALUES (18, CAST(0x01380B00 AS Date), 3, 1, N'Hello World', N'Hello World', N'Hello World', N'Hello World', N'10.2      ')
INSERT [dbo].[DietPlanReport] ([DietPlanReportID], [TestDate], [ClientID], [UserID], [Morning], [Afternoon], [Evening], [Night], [BMI]) VALUES (19, CAST(0x01380B00 AS Date), 3, 1, N'Hello World', N'Hello World', N'Hello World', N'Hello World', N'10.2      ')
SET IDENTITY_INSERT [dbo].[DietPlanReport] OFF
/****** Object:  ForeignKey [FK_User_OccupationMaster]    Script Date: 01/24/2015 20:06:03 ******/
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_OccupationMaster] FOREIGN KEY([OccupationID])
REFERENCES [dbo].[OccupationMaster] ([OccupationID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_OccupationMaster]
GO
/****** Object:  ForeignKey [FK_ReportField_ReportTypeMaster]    Script Date: 01/24/2015 20:06:03 ******/
ALTER TABLE [dbo].[ReportFieldMaster]  WITH CHECK ADD  CONSTRAINT [FK_ReportField_ReportTypeMaster] FOREIGN KEY([ReportTypeID])
REFERENCES [dbo].[ReportTypeMaster] ([ReportTypeID])
GO
ALTER TABLE [dbo].[ReportFieldMaster] CHECK CONSTRAINT [FK_ReportField_ReportTypeMaster]
GO
/****** Object:  ForeignKey [FK_UserReportField_ReportField]    Script Date: 01/24/2015 20:06:03 ******/
ALTER TABLE [dbo].[UserReportField]  WITH CHECK ADD  CONSTRAINT [FK_UserReportField_ReportField] FOREIGN KEY([ReportFieldID])
REFERENCES [dbo].[ReportFieldMaster] ([ReportFieldID])
GO
ALTER TABLE [dbo].[UserReportField] CHECK CONSTRAINT [FK_UserReportField_ReportField]
GO
/****** Object:  ForeignKey [FK_UserReportField_User]    Script Date: 01/24/2015 20:06:03 ******/
ALTER TABLE [dbo].[UserReportField]  WITH CHECK ADD  CONSTRAINT [FK_UserReportField_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserReportField] CHECK CONSTRAINT [FK_UserReportField_User]
GO
/****** Object:  ForeignKey [FK_OccupationReportField_OccupationMaster]    Script Date: 01/24/2015 20:06:03 ******/
ALTER TABLE [dbo].[OccupationReportField]  WITH CHECK ADD  CONSTRAINT [FK_OccupationReportField_OccupationMaster] FOREIGN KEY([OccupationID])
REFERENCES [dbo].[OccupationMaster] ([OccupationID])
GO
ALTER TABLE [dbo].[OccupationReportField] CHECK CONSTRAINT [FK_OccupationReportField_OccupationMaster]
GO
/****** Object:  ForeignKey [FK_OccupationReportField_ReportField]    Script Date: 01/24/2015 20:06:03 ******/
ALTER TABLE [dbo].[OccupationReportField]  WITH CHECK ADD  CONSTRAINT [FK_OccupationReportField_ReportField] FOREIGN KEY([ReportFieldID])
REFERENCES [dbo].[ReportFieldMaster] ([ReportFieldID])
GO
ALTER TABLE [dbo].[OccupationReportField] CHECK CONSTRAINT [FK_OccupationReportField_ReportField]
GO
/****** Object:  ForeignKey [FK_Client_CategoryMaster]    Script Date: 01/24/2015 20:06:03 ******/
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_CategoryMaster] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[CategoryMaster] ([CategoryID])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_CategoryMaster]
GO
/****** Object:  ForeignKey [FK_Client_User]    Script Date: 01/24/2015 20:06:03 ******/
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_User]
GO
/****** Object:  ForeignKey [FK_PhysicalConditionReport_Client]    Script Date: 01/24/2015 20:06:03 ******/
ALTER TABLE [dbo].[PhysicalConditionReport]  WITH CHECK ADD  CONSTRAINT [FK_PhysicalConditionReport_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[PhysicalConditionReport] CHECK CONSTRAINT [FK_PhysicalConditionReport_Client]
GO
/****** Object:  ForeignKey [FK_PhysicalConditionReport_User]    Script Date: 01/24/2015 20:06:03 ******/
ALTER TABLE [dbo].[PhysicalConditionReport]  WITH CHECK ADD  CONSTRAINT [FK_PhysicalConditionReport_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[PhysicalConditionReport] CHECK CONSTRAINT [FK_PhysicalConditionReport_User]
GO
/****** Object:  ForeignKey [FK_LabReport_Client]    Script Date: 01/24/2015 20:06:03 ******/
ALTER TABLE [dbo].[LabReport]  WITH CHECK ADD  CONSTRAINT [FK_LabReport_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[LabReport] CHECK CONSTRAINT [FK_LabReport_Client]
GO
/****** Object:  ForeignKey [FK_LabReport_ReportField]    Script Date: 01/24/2015 20:06:03 ******/
ALTER TABLE [dbo].[LabReport]  WITH CHECK ADD  CONSTRAINT [FK_LabReport_ReportField] FOREIGN KEY([ReportFieldID])
REFERENCES [dbo].[ReportFieldMaster] ([ReportFieldID])
GO
ALTER TABLE [dbo].[LabReport] CHECK CONSTRAINT [FK_LabReport_ReportField]
GO
/****** Object:  ForeignKey [FK_LabReport_User]    Script Date: 01/24/2015 20:06:03 ******/
ALTER TABLE [dbo].[LabReport]  WITH CHECK ADD  CONSTRAINT [FK_LabReport_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[LabReport] CHECK CONSTRAINT [FK_LabReport_User]
GO
/****** Object:  ForeignKey [FK_DietPlanReport_Client]    Script Date: 01/24/2015 20:06:03 ******/
ALTER TABLE [dbo].[DietPlanReport]  WITH CHECK ADD  CONSTRAINT [FK_DietPlanReport_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ClientID])
GO
ALTER TABLE [dbo].[DietPlanReport] CHECK CONSTRAINT [FK_DietPlanReport_Client]
GO
/****** Object:  ForeignKey [FK_DietPlanReport_User]    Script Date: 01/24/2015 20:06:03 ******/
ALTER TABLE [dbo].[DietPlanReport]  WITH CHECK ADD  CONSTRAINT [FK_DietPlanReport_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[DietPlanReport] CHECK CONSTRAINT [FK_DietPlanReport_User]
GO
